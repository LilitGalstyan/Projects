using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Lilit", 200);
            Bus bus = new Bus(20, 50, 10, "Ford", 20, 0.01);
            Truck truck = new Truck(50, 50, 10, "Furz", 50, 0.01);
            Sedan sedan = new Sedan(50, 50, 10, "Ferrari", 50, 0.01);

            CarShop shop = new CarShop(20);
            shop.Add(bus, 50);
            shop.Add(truck, 60);
            shop.Add(sedan, 100);

            shop.Add(bus, 50);
            shop.Add(truck, 60);
            shop.Add(sedan, 100);

            shop.Add(bus, 50);
            shop.Add(truck, 60);
            shop.Add(sedan, 100);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Shop_______________ Type SHOP");
                Console.WriteLine("Garage_____________ Type GARAGE");
                Console.WriteLine("Exit_______________ Type EXIT");
                string ans = Console.ReadLine();

                Console.Clear();
                if (ans.ToUpper() == "SHOP")
                {
                    shop.Shopping(user);
                }
                else if (ans.ToUpper() == "GARAGE")
                {
                    user.DisplayCars();
                    Console.ReadKey();
                }

                else if (ans.ToUpper() == "EXIT")
                {
                    Console.WriteLine($"Thank You for shopping, {user.Name}");
                    break;
                }
            }
        }
    }
}
