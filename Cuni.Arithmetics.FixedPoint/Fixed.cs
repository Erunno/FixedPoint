using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<T> where T : QFormat<T>
    {
        private readonly int theNumber;

        //Constructors

        static Fixed()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        } 

        public Fixed(int number)
        {
            theNumber = number << QFormat<T>.FractionalBits;
        }

        private Fixed(int rawInt, bool uselessArgument_NowICanHaveTwoAlmostSameConstructors = true) 
        {
            theNumber = rawInt;
        }

        //Arithmetic methods

        public Fixed<T> Add(Fixed<T> num)
        {
            return new Fixed<T>(rawInt: theNumber + num.theNumber);
        }

        public Fixed<T> Subtract(Fixed<T> num)
        {
            return new Fixed<T>(rawInt: theNumber - num.theNumber);
        }

        public Fixed<T> Multiply(Fixed<T> num)
        {
            long result = ((long)theNumber * (long)num.theNumber) >> QFormat<T>.FractionalBits;

            return new Fixed<T>(rawInt: (int)result);
        }

        public Fixed<T> Divide(Fixed<T> num)
        {
            long result = ((long)theNumber << QFormat<T>.FractionalBits) / num.theNumber;

            return new Fixed<T>(rawInt: (int)result );
        }

        //Operators

        public static Fixed<T> operator +(Fixed<T> f1, Fixed<T> f2) => f1.Add(f2);
        public static Fixed<T> operator -(Fixed<T> f1, Fixed<T> f2) => f1.Subtract(f2);
        public static Fixed<T> operator *(Fixed<T> f1, Fixed<T> f2) => f1.Multiply(f2);
        public static Fixed<T> operator /(Fixed<T> f1, Fixed<T> f2) => f1.Divide(f2);

        public static implicit operator Fixed<T>(int num) => new Fixed<T>(num);
        public static explicit operator double(Fixed<T> num) => num.ToDouble();

        public double ToDouble() => ((double)theNumber / (1 << QFormat<T>.FractionalBits));

        public override string ToString() => ToDouble().ToString();
    }
}
