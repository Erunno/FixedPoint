using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<T> where T : QFormat<T>, new()
    {
        static Fixed()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        } 

        private int theNumber;

        public Fixed(int number)
        {
            theNumber = number << QFormat<T>.FractionalBits;
        }

        public Fixed<T> Add(Fixed<T> num)
        {
            return new Fixed<T>() { theNumber = theNumber + num.theNumber };
        }

        public Fixed<T> Subtract(Fixed<T> num)
        {
            return new Fixed<T>() { theNumber = theNumber - num.theNumber };
        }

        public Fixed<T> Multiply(Fixed<T> num)
        {
            long result = ((long)theNumber * (long)num.theNumber) >> QFormat<T>.FractionalBits;

            return new Fixed<T>() { theNumber = (int)result };
        }

        public Fixed<T> Divide(Fixed<T> num)
        {
            long result = ((long)theNumber << QFormat<T>.FractionalBits) / num.theNumber;

            return new Fixed<T>() { theNumber = (int)result };
        }

        public static implicit operator Fixed<T>(int num) => new Fixed<T>(num);

        public double ToDouble() => ((double)theNumber / (1 << QFormat<T>.FractionalBits));

        public override string ToString() => ToDouble().ToString();
    }
}
