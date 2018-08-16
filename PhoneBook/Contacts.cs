using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Contact
    {
        private IList<string> phones;
        private IList<string> emails;
        public IList<string> PhoneNumbers { get { return Copy(phones); } set { phones = Copy(value); } }
        public IList<string> Emails { get { return Copy(emails); } set { emails = Copy(value); } }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Contact(string name, string surname, IList<string> phones, IList<string> emails)
        {
            this.Name = name;
            this.Surname = surname;
            this.Emails = emails;
            this.PhoneNumbers = phones;
        }
        public Contact(string line)
        {
            string[] args = line.Split(',');

            this.Name = args[0].Trim();
            this.Surname = args[1].Trim();

            if (2 < args.Length)
            {
                phones = args[2].Split(',');
            }
            else
            {
                phones = new List<string>();
            }

            if (3 < args.Length)
            {
                emails = args[3].Split(',');
            }
            else
            {
                emails = new List<string>();
            }
        }
        private IList<string> Copy(IList<string> t)
        {
            List<string> k = new List<string>();

            foreach (string i in t)
            {
                k.Add(i);
            }

            return k;
        }

        public override string ToString()
        {
            StringBuilder ans = new StringBuilder();
            ans.Append(Name + "  " + Surname + "  ");

            foreach (string item in phones)
            {
                ans.Append(item + "  ");
            }

            foreach (string item in emails)
            {
                ans.Append(item + "  ");
            }

            return ans.ToString();
        }
        public string Encocde()
        {
            StringBuilder ans = new StringBuilder();
            ans.Append(Name + " " + Surname + ": ");

            foreach (string item in phones)
            {
                ans.Append(item + " ");
            }

            ans[ans.Length - 1] = ',';
            foreach (string item in emails)
            {
                ans.Append(item + " ");
            }

            ans[ans.Length - 1] = ',';

            return ans.ToString();
        }
    }
}
