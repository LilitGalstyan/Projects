using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public NoteList PhoneBook { get; }

        public User(string username, string password)
        {
            this.Login = username;
            this.Password = password;
            this.PhoneBook = new NoteList(username);
        }
    }
}
