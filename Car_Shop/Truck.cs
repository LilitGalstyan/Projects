using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Truck: Car
    {
        public int MaxSpeed
        {
            get => maxSpeed;
            private set
            {                
                if (value > 50)
                {
                    maxSpeed = 50;
                }

                maxSpeed = value;
            }
        }

        public int SeatCount
        {
            get => seatCount;
            private set
            {
                if (value > 2)
                {
                    seatCount = 2;
                }

                seatCount = value;
            }
        }

        public Truck(int maxSpeed, int maxCapacity, int seatCount, string model, double petrol, double coefficient)
            :base(maxCapacity, model, petrol, coefficient)
        {
            this.MaxSpeed = maxSpeed;
            this.SeatCount = seatCount;
        }
    }
}
