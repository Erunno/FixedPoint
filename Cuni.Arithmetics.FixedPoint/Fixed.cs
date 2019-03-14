using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<T> where T : QFormat, new()
    {
        private static int FractionalBitsCount;
        static Fixed()
        {
            FractionalBitsCount = (new T()).GetNumOfFractionalBits();
        } 

        private int theNumber;

        public Fixed(int number)
        {
            theNumber = number << FractionalBitsCount;
        }

        public Fixed<T> Add(Fixed<T> num)
        {
            return new Fixed<T>() { theNumber = theNumber + num.theNumber };
        }

        public Fixed<T> Subtract(Fixed<T> num)
        {
            return new Fixed<T>() { theNumber = theNumber + num.theNumber };
        }

        public Fixed<T> Multiply(Fixed<T> num)
        {
            long result = (long)theNumber * (long)num.theNumber;
            result = result >> FractionalBitsCount;

            return new Fixed<T>() { theNumber = (int)result };
        }

        public Fixed<T> Divide(Fixed<T> num)
        {
            long result = ((long)theNumber << FractionalBitsCount) / num.theNumber;

            return new Fixed<T>() { theNumber = (int)result };
        }

        public static implicit operator Fixed<T>(int num) => new Fixed<T>(num);

        public override string ToString()
        {
            double result = theNumber;

            for (int i = 0; i < FractionalBitsCount; i++)
                result /= 2;

            return result.ToString();
        }
    }
}
