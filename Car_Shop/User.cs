using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class User
    {
        private MyCars myCars;
        public string Name { get; private set; }
        public double Money { get; private set; }

        public User(string Name, double Money, int NumberOfCars = 1)
        {
            this.Name = Name;
            this.Money = Money;
            myCars = new MyCars(NumberOfCars);

        }

        public bool Buy(Car car, double price)
        {
            if (this.Money < price)
            {
                return false;
            }

            if (!myCars.Add(car))
            {
                myCars.Expand(myCars.Size + 1);
                myCars.Add(car);

                Console.WriteLine(this.Money);
            }
            this.Money -= price;
            return true;
        }

        public void DisplayCars()
        {
            myCars.Display();
        }

    }
}
