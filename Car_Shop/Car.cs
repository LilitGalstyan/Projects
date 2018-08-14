using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Car
    {
        protected int maxSpeed;
        protected int seatCount;

        public readonly int maxCapacity;
        public readonly string model;
        public readonly double coefficient;
        private double petrol;

        public Car(int maxCapacity, string model, double coefficient, double petrol) : this(100, maxCapacity, 4, model, petrol, 0.1)
        {

        }
        public Car(int maxSpeed, int maxCapacity, int seatCount, string model, double petrol, double coefficient)
        {
            this.maxSpeed = maxSpeed;
            this.maxCapacity = maxCapacity;
            this.seatCount = seatCount;
            this.model = model;
            this.Petrol = petrol;
            this.coefficient = coefficient;
        }

        public double Petrol
        {
            get => petrol;
            set
            {
                if (value > maxCapacity)
                {
                    petrol = maxCapacity;
                }

                petrol = value;

            }
        }

        public void FillPetrol(double sum)
        {
            if (sum > 0)
            {
                Petrol += sum;
            }
        }

        public void Trip(int velocity)
        {
            if (velocity < 0 || velocity > maxSpeed)
            {
                Console.WriteLine("Enter valid velocity");
                return;
            }

            if (this.Petrol < velocity * coefficient)
            {
                Console.WriteLine("You don't have enough petrol");
                return;
            }

            Petrol -= velocity * coefficient;
        }

        public void PrintStats()
        {
            Console.WriteLine($"Model - {model}: Seat Count - {seatCount}, Max Speed - {maxSpeed}, Max Capacity - {maxCapacity}, Coefficient - {coefficient}");
        }

    }
}
