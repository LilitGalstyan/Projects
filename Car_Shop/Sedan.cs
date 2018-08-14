using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Sedan : Car
    {
        public int MaxSpeed { get => maxSpeed; }

        public int SeatCount
        {
            get => seatCount;
            private set
            {
                if (value > 4)
                {
                    seatCount = 4;
                }
                seatCount = value;
            }
        }

        public Sedan(int maxSpeed, int maxCapacity, int seatCount, string model, double petrol, double coefficient)
            :base(maxCapacity, model, petrol, coefficient)
        {
            this.maxSpeed = maxSpeed;
            this.SeatCount = seatCount;
        }
    }
}
