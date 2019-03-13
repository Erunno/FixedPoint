﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<T> where T : QFormat
    {
        private int theNumber;

        public Fixed(int number)
        {
            theNumber = number;
        }

        public Fixed<T> Add(Fixed<T> num)
        {
            return theNumber + num.theNumber;
        }

        public Fixed<T> Subtract(Fixed<T> num)
        {
            return theNumber - num.theNumber;
        }

        public Fixed<T> Multiply(Fixed<T> num)
        {
            throw new NotImplementedException();
        }

        public Fixed<T> Divide(Fixed<T> num)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Fixed<T>(int num) => new Fixed<T>(num);
    }

}
