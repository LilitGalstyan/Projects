using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Blocnote
    {
        public Blocnote()
        {

        }
        public void Start(string message=null)
        {
            Console.Clear();
            Console.WriteLine(message);
            User myUser = null;
            try
            {
                myUser = LogIn();
            }
            catch (WrongLogin ex)
            {

                this.Start(ex.Message);
            }

            this.LogIn(myUser);


        }

        private void LogIn(User myUser, string message = null)
        {
            Console.Clear();

            Console.WriteLine(message);
            bool exit = false;
            Console.WriteLine();
            Console.WriteLine("Print All Contacts ______ Press 1");
            Console.WriteLine("Add Contact _____________ Press 2");
            Console.WriteLine("Remove Contact __________ Press 3");
            Console.WriteLine("Edit Contact ____________ Press 4");
            Console.WriteLine("Exit ____________________ Press 5");
            Console.WriteLine();
            string a = Console.ReadLine();
            try
            {
                switch (a)
                {
                    case "1":
                        GetAllContacts(myUser);
                        break;
                    case "2":
                        Add(myUser);
                        break;
                    case "3":
                        Remove(myUser);
                        break;
                    case "4":
                        Edit(myUser);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        throw new WrongInput("The number, that You entered, is wrong");
                }
            }
            catch (WrongInput e)
            {
                LogIn(myUser, e.Message);
            }

            if (exit)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            this.LogIn(myUser);
        }
        private void GetAllContacts(User user)
        {
            int i = 1;
            bool cond;
            while (true)
            {
                Console.Clear();
                cond = false;
                Console.WriteLine(user.PhoneBook.GetPage(i, 2000000));
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (i != 1)
                        {
                            i--;
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if ((i) * 5 < user.PhoneBook.Count)
                        {
                            i++;
                        }

                        break;
                    case ConsoleKey.Enter:
                        cond = true;
                        break;
                }
                if (cond)
                    break;

            }
        }
        private void ViewAllContacts(User user)
        {
            int index = 1;
            Console.Clear();
            foreach (var item in user.PhoneBook)
            {
                Console.WriteLine($"{index} | {item}");
                index++;
            }
        }

        private void Add(User user)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            while (name == null)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 3);

                Console.WriteLine("Your input is empty");
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine();
            while (surname == null)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 3);

                Console.WriteLine("Your input is empty");
                Console.WriteLine("Surname: ");
                surname = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("Phone numbers (for ending _____ Type '!')");
            List<string> phones = new List<string>();
            AskForInput(phones);
            Console.WriteLine();
            Console.WriteLine("Emails (for ending _____ Type '!')");
            List<string> emails = new List<string>();
            AskForInput(emails);

            Console.WriteLine("Contact is added");
            user.PhoneBook.Add(name, surname, phones, emails);

        }
        private void AskForInput(List<string> phones)
        {
            string ans = null;
            Console.WriteLine();
            while (true)
            {

                ans = Console.ReadLine();
                if (ans.Contains('!'))
                {
                    break;
                }

                if (ans == null)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.WriteLine("Your input was wrong");
                    continue;
                }

                phones.Add(ans);
                Console.WriteLine();

            }

        }
        private void Edit(User user)
        {
            Console.WriteLine();
            GetAllContacts(user);
            int ind = BrowseItem();
            Console.Clear();

            var (name, surname, phone, emails) = user.PhoneBook.GetAllContact(ind);


            string f = TakeInputForUpdate("Name you might want to change", name);
            string l = TakeInputForUpdate("Surname you might want to change", surname);

            List<string> p = ManageData(phone.ToList(), "Phone number, that you might want to remove or change");

            List<string> e = ManageData(emails.ToList(), "Email, that you might want to remove or change");

            Console.WriteLine("Contact is edited");
            user.PhoneBook.EditContact(ind, f, l, p, e);
        }
        private List<string> ManageData(List<string> col, string message)
        {
            List<string> p = new List<string>();

            string ph = null;
            foreach (string item in col)
            {
                ph = TakeInputForUpdate(message, item);
                if (item != null)
                {
                    p.Add(ph);
                }
            }
            Console.Clear();
            Console.WriteLine("Add more? Yes : No");

            string ans = Console.ReadLine();
            while (!ans.ToUpper().Contains('N') && !ans.ToUpper().Contains('Y'))
            {
                Console.Clear();
                Console.WriteLine("Add more ? Yes : No");
                ans = Console.ReadLine();
            }
            if (ans.ToUpper().Contains('Y'))
            {
                AskForInput(p);
            }

            return p;
        }
        private string TakeInputForUpdate(string text, string info)
        {
            Console.WriteLine(text);
            Console.WriteLine(info);
            Console.WriteLine();
            string ans = Console.ReadLine();

            if (ans == "R")
            {
                return null;
            }

            if (ans == null)
            {
                return info;
            }

            while (ans == null)
            {
                Console.Clear();
                Console.WriteLine(text);
                Console.WriteLine(info);
                ans = Console.ReadLine();
            }
            Console.WriteLine();
            return ans;

        }
        private void Remove(User user)
        {
            GetAllContacts(user);
            Console.WriteLine("Enter index of contact for remove");
            int a = BrowseItem();
            if (a == -1)
                return;
            try
            {
                user.PhoneBook.Remove(a);
                Console.WriteLine();
                Console.WriteLine("Contact is deleted");
            }
            catch (ItemNotFound e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Remove(user);
            }

        }
        private int BrowseItem()
        {
            int a = 0;
            string ans = null;
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine();
                ans = Console.ReadLine();

                if (ans.ToLower() == "exit")
                    return -1;

                if (ans == null || !int.TryParse(ans, out a) || a <= 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 3);
                    Console.WriteLine("Wrong input");
                    continue;
                }
                else
                    break;
            }

            return a;
        }
        private User LogIn()
        {
            Console.WriteLine("\t**********Welcome to your Phonebook**********");
            Console.WriteLine();

            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            if (login == null || password == null)
            {
                throw new WrongLogin("Login or/and Passowrd is/are empty!!");
            }

            using (StreamReader reader = new StreamReader("users.txt"))
            {
                string line;
                string[] arr;
                while ((line = reader.ReadLine()) != null)
                {
                    arr = line.Split(',');
                    if (arr[0] == login && arr[1] == password)
                    {
                        return new User(login, password);
                    }
                }
            }

            throw new WrongLogin("Login Or/And Password is/are wrong");
        }
    }
}