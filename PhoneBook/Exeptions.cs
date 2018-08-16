using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class WrongLogin : ApplicationException
    {

        public WrongLogin(string message) : base(message)
        {

        }

    }
    class WrongInput : ApplicationException
    {
        public WrongInput(string message) : base(message)
        {

        }
    }
    class ItemNotFound : ApplicationException
    {
        public ItemNotFound(string message) : base(message)
        {

        }
    }
}
