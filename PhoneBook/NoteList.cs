using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    class NoteList : IEnumerable<string>, IDisposable
    {
        private StreamReader reader;
        private StreamWriter writer;
        private FileStream file;
        public long Count { get; private set; }
        private string Path;
        private bool disposed = false;

        public NoteList(string filePath)
        {
            file = new FileStream(filePath + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            reader = new StreamReader(file);
            writer = new StreamWriter(file);
            this.Path = filePath;
            GetCount();
        }

        private void GetCount()
        {
            Refresh();
            string line;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                i++;
            }
            Count = i;
            Refresh();
        }

        private void Refresh()
        {
            file.Position = 0;
            reader.DiscardBufferedData();
            writer.Flush();
        }

        public void Add(string first, string last, IList<string> PhoneNumbers, IList<string> Emails)
        {
            Validate(first, last, PhoneNumbers, Emails);

            AddLine((new Contact(first, last, PhoneNumbers, Emails)).Encocde());
            Count++;
        }

        private void AddLine(string contact)
        {
            Refresh();
            string line;
            while ((line = reader.ReadLine()) != null)
            {

            }
            writer.WriteLine(contact);
            writer.Flush();
        }

        public void Remove(int index)
        {
            ValidateIndex(index);

            EditLine(index, null);

            Count--;
        }

        

        public (string name, string surname, IList<string> phone, IList<string> email) GetAllContact(int index)
        {
            ValidateIndex(index);

            Refresh();

            Contact myContact = null;

            myContact = new Contact(GetLine(index));

            return (myContact.Name, myContact.Surname, myContact.PhoneNumbers, myContact.Emails);
        }

        public string GetPage(int index, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            Refresh();
            long start = (index - 1) * pageSize;



            long ind = 1;

            long end = index * pageSize;


            if (start > Count || end < 1)
            {
                return null;
            }

            string line;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                i++;
                if (i > start && i <= end)
                {
                    sb.AppendLine(ind + " | " + (new Contact(line)).ToString());
                }

                ind++;
            }
            return sb.ToString();
        }

        private string GetLine(int index)
        {
            string l;
            int i = 0;
            while ((l = reader.ReadLine()) != null)
            {
                i++;
                if (i == index)
                {
                    return l;
                }
            }
            throw new WrongInput("The contact with this index, that you entered, couldn't found");
        }

        public void EditContact(int index, string first, string last, IList<string> phone, IList<string> email)
        {
            Validate(first, last, phone, email);

            Contact c = new Contact(first, last, phone, email);

            EditLine(index, c.Encocde());

        }

        private void EditLine(int index, string info)
        {
            Refresh();
            StreamWriter sw = new StreamWriter($"{Path}(1).txt");
            string line;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                i++;
                if (index == i)
                {
                    if (info == null)
                    {
                        continue;
                    }

                    line = info;
                }
                sw.WriteLine(line);
            }
            sw.Flush();
            sw.Close();
            file.Close();
            File.Delete($"{Path}.txt");
            File.Move($"{Path}(1).txt", $"{Path}.txt");
            file = new FileStream(Path + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            reader = new StreamReader(file);
            writer = new StreamWriter(file);
        }
        private void ValidateIndex(int index)
        {
            if (index <= 0)
            {
                throw new WrongInput("Wrong index");
            }

            if (index > Count)
            {
                throw new ItemNotFound("The contact with this index, that you entered, does not exist in this Phonebook!");
            }
        }

        private void Validate(string first, string last)
        {
            if (first == null || last == null)
            {
                throw new WrongInput("Name and/or Surname are/is empty!");
            }
        }

        private void Validate(IList<string> PhoneNumbers, IList<string> Emails)
        {
            if (PhoneNumbers == null || Emails == null)
            {
                throw new WrongInput("Phone Numbers or/and Emails collections are empty!");
            }
        }

        private void Validate(string first, string last, IList<string> PhoneNumbers, IList<string> Emails)
        {
            Validate(first, last);
            Validate(PhoneNumbers, Emails);
        }

        private void Validate(string number)
        {
            foreach (char item in number)
            {
                if (!Char.IsDigit(item) && item != ' ')
                {
                    throw new WrongInput("A phone number cannot include eight symbols or space");
                }
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                writer.Dispose();
                reader.Dispose();
                file.Dispose();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<string>).GetEnumerator();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            Refresh();
            string line;
            while ((line = reader.ReadLine()) != null)
            {

                yield return new Contact(line).ToString();
            }
        }


    }
}
