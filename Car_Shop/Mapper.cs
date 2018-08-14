using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Mapper
    {
        public readonly Car Car;
        public double Price { get; private set; }

        public Mapper(Car Car, double Price)
        {
            this.Car = Car;
            this.Price = Price;
        }
    }
}
