using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    class MyCars
    {
        private Car[] myCars;
        public int Size { get=>myCars.Length; }
        public MyCars(int NumOfCars)
        {
            myCars = new Car[NumOfCars];
        }

        public bool Add(Car car)
        {
            for (int i = 0; i < myCars.Length; i++)
            {
                if (myCars[i] == null)
                {
                    myCars[i] = car;
                    return true;
                }
            }

            return false;
        }

        public void Expand(int newSize)
        {
            if (newSize < myCars.Length)
            {
                return;
            }

            Car[] hold = myCars;
            this.myCars = new Car[newSize];

            for (int i = 0; i < hold.Length; i++)
            {
                myCars[i] = hold[i];
            }
        }

        public void Display()
        {
            foreach (var item in myCars)
            {
                if (item != null)
                {
                    item.PrintStats();
                }
            }
        }
    }
}
