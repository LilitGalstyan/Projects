using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Bus: Car
    {
        public int MaxSpeed
        {
            get => maxSpeed;
            private set
            {
                maxSpeed = value;
                if (value > 100)
                {
                    maxSpeed = 100;
                }

            }
        }
        public int SeatCount
        {
            get => seatCount;
            private set
            {
                seatCount = value;
                if (value < 9)
                    seatCount = 9;
            }
        }

        public Bus(int maxSpeed, int maxCapacity, int seatCount, string model, double petrol, double coefficient)
            : base(maxCapacity, model, petrol, coefficient)
        {
            this.MaxSpeed = maxSpeed;
            this.SeatCount = seatCount;
        }
    }
}
