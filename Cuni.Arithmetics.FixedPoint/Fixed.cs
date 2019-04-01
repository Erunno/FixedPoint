using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<Q> : IComparable<Fixed<Q>> where Q : QFormat<Q>
    {
        private readonly int theNumber;
        private static int fractionalBits;
        
        //Constructors

        static Fixed()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(Q).TypeHandle);
            fractionalBits = QFormat<Q>.FractionalBits;
        } 

        public Fixed(int number)
        {
            theNumber = number << fractionalBits;
        }

        private Fixed(int rawInt, bool uselessArgument_JustToDistinguishBetweenConstructors = true) 
        {
            theNumber = rawInt;
        }

        //Arithmetic methods

        public Fixed<Q> Add(Fixed<Q> num)
        {
            return new Fixed<Q>(rawInt: theNumber + num.theNumber);
        }

        public Fixed<Q> Subtract(Fixed<Q> num)
        {
            return new Fixed<Q>(rawInt: theNumber - num.theNumber);
        }

        public Fixed<Q> Multiply(Fixed<Q> num)
        {
            long result = ((long)theNumber * (long)num.theNumber) >> fractionalBits;

            return new Fixed<Q>(rawInt: (int)result);
        }

        public Fixed<Q> Divide(Fixed<Q> num)
        {
            long result = ((long)theNumber << fractionalBits) / num.theNumber;

            return new Fixed<Q>(rawInt: (int)result );
        }

        public bool IsZero(Fixed<Q> delta) => theNumber < delta.theNumber && theNumber > -delta.theNumber;

        //Operators

        public static Fixed<Q> operator +(Fixed<Q> f1, Fixed<Q> f2) => f1.Add(f2);
        public static Fixed<Q> operator -(Fixed<Q> f1, Fixed<Q> f2) => f1.Subtract(f2);
        public static Fixed<Q> operator *(Fixed<Q> f1, Fixed<Q> f2) => f1.Multiply(f2);
        public static Fixed<Q> operator /(Fixed<Q> f1, Fixed<Q> f2) => f1.Divide(f2);
        public static Fixed<Q> operator -(Fixed<Q> f) => new Fixed<Q>(rawInt: -f.theNumber);

        public int CompareTo(Fixed<Q> other) => theNumber - other.theNumber;
        public static bool operator <(Fixed<Q> f1, Fixed<Q> f2)  => f1.theNumber < f2.theNumber;
        public static bool operator >(Fixed<Q> f1, Fixed<Q> f2)  => f1.theNumber > f2.theNumber;
        public static bool operator <=(Fixed<Q> f1, Fixed<Q> f2) => f1.theNumber <= f2.theNumber;
        public static bool operator >=(Fixed<Q> f1, Fixed<Q> f2) => f1.theNumber >= f2.theNumber;
        public static bool operator ==(Fixed<Q> f1, Fixed<Q> f2) => f1.theNumber == f2.theNumber;
        public static bool operator !=(Fixed<Q> f1, Fixed<Q> f2) => f1.theNumber != f2.theNumber;


        public static Fixed<Q> operator >>(Fixed<Q> f, int bits) => new Fixed<Q>(rawInt: f.theNumber >> bits);
        public static Fixed<Q> operator <<(Fixed<Q> f, int bits) => new Fixed<Q>(rawInt: f.theNumber << bits);
        public static Fixed<Q> operator &(Fixed<Q> f, int mask) => new Fixed<Q>(rawInt: f.theNumber & mask);
        public static Fixed<Q> operator |(Fixed<Q> f, int mask) => new Fixed<Q>(rawInt: f.theNumber | mask);
        public static Fixed<Q> operator ^(Fixed<Q> f, int mask) => new Fixed<Q>(rawInt: f.theNumber ^ mask);

        public static implicit operator Fixed<Q>(int num) => new Fixed<Q>(num);
        public static explicit operator double(Fixed<Q> num) => num.ToDouble();

        public static explicit operator Fixed<Q24_8>(Fixed<Q> num)  => Convert<Q, Q24_8>(num);
        public static explicit operator Fixed<Q16_16>(Fixed<Q> num) => Convert<Q, Q16_16>(num);
        public static explicit operator Fixed<Q8_24>(Fixed<Q> num)  => Convert<Q, Q8_24>(num);

        private static Fixed<To> Convert<From,To>(Fixed<From> num) where To : QFormat<To> where From: QFormat<From>
        {
            int newNumber = Fixed<To>.fractionalBits > Fixed<From>.fractionalBits 
                ? num.theNumber << (Fixed<To>.fractionalBits - Fixed<From>.fractionalBits) 
                : num.theNumber >> (Fixed<From>.fractionalBits - Fixed<To>.fractionalBits);
            return new Fixed<To>(rawInt: newNumber);
        }

        public double ToDouble() => ((double)theNumber / (1 << fractionalBits));
        public override string ToString() => ToDouble().ToString();

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
