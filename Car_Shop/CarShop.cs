using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    enum CarType
    {
        Sedan,
        Bus,
        Truck,
        Invalid
    }

    class CarShop
    {
        Mapper[] list;

        public CarShop(int NumOfCars)
        {
            list = new Mapper[NumOfCars];
        }

        public bool Add(Car car, double price)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null)
                {
                    list[i] = new Mapper(car, price);
                    return true;
                }

            }

            Console.WriteLine("Not enough place for more cars");
            return false;
        }

        public void Shopping(User user)
        {
            Console.WriteLine("What type of cars are you looking for?");

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Your money balance: {user.Money}");
                Console.WriteLine();

                Console.Write("Enter Car type: ");
                string answer = Console.ReadLine();

                if (answer.ToUpper() == "SEDAN")
                {
                    LookForCar<Sedan>();
                }
                else if (answer.ToUpper() == "TRUCK")
                {
                    LookForCar<Truck>();
                }
                else if (answer.ToUpper() == "BUS")
                {
                    LookForCar<Bus>();
                }

                else
                {
                    Console.WriteLine("There is no result with your search");
                    continue;
                }

                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    this.Sell(user, i);
                }

                else
                {
                    Console.WriteLine("The ID, that you entered, is not valid");
                }

                Console.WriteLine("Looking for other's? YES : NO");
                if (Console.ReadLine().ToUpper().Contains('N'))
                {
                    break;
                }

                Console.Clear();

            }
        }

        private void LookForCar<T>()
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null)
                {
                    continue;
                }

                if (list[i].Car is T b)
                {
                    Console.Write($"{i}: ");
                    list[i].Car.PrintStats();
                    Console.WriteLine($"{list[i].Price}$");
                }
            }
        }

        private void Sell(User user, int id)
        {
            if (id > this.list.Length || this.list[id] == null)
            {
                Console.WriteLine("The ID, that you entered, is not valid");
            }

            else if (user.Buy(this.list[id].Car, this.list[id].Price))
            {
                Console.WriteLine("The car was bought successfully");
                this.list[id] = null;
                Console.Clear();

                Console.WriteLine("These are the cars, that you have");
                user.DisplayCars();
            }

            else
            {
                Console.WriteLine("You don't have enough money for this car");

            }
            Console.ReadLine();
        }
    }
}
