using System;
using System.Collections.Generic;
using System.Text;
using Cuni.Arithmetics.FixedPoint;
using NUnit.Framework;

namespace Fixed.NUnitTests
{
    [TestFixture(typeof(Q24_8))]
    [TestFixture(typeof(Q16_16))]
    [TestFixture(typeof(Q8_24))]
    class BitOperators<Q> where Q : QFormat<Q>
    {
        [TestCase(14, 3)]
        [TestCase(42, 32)]
        [TestCase(-14, 3)]
        [TestCase(42, 0)]
        [TestCase(1, 6)]
        public void OperatorShiftLeft(int left, int bits)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            double expected = (double)left * (1 << bits);

            //Act
            Fixed<Q> actual = (fixedLeft << bits);

            //Assert
            Assert.AreEqual(expected, actual.ToDouble(), delta: 0.01);
        }

        [TestCase(14, 3)]
        [TestCase(42, 32)]
        [TestCase(-14, 3)]
        [TestCase(42, 0)]
        [TestCase(1, 6)]
        public void OperatorShiftRight(int left, int bits)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            double expected = (double)left / (1 << bits);

            //Act
            Fixed<Q> actual = (fixedLeft >> bits);

            //Assert
            Assert.AreEqual(expected, actual.ToDouble(), delta: 0.01);
        }


        [TestCase(16, 0x0)]
        [TestCase(42, 0xFFF_FFFF)]
        [TestCase(-14, 0xFFFF)]
        [TestCase(42, 0xEAD_BEEF)]
        [TestCase(1, 0x1234)]
        public void OperatorAnd(int num, int mask)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(num);
            int shiftAmount = int.Parse(typeof(Q).ToString().Split('_')[1]); //num of fractional bits
            double expected = ((num << shiftAmount) & mask) / (double)(1 << shiftAmount);

            //Act
            Fixed<Q> actual = fixedLeft & mask;

            //Assert
            Assert.AreEqual(expected, actual.ToDouble(), delta: 0.01);
        }

        [TestCase(16, 0x0)]
        [TestCase(42, 0xFFF_FFFF)]
        [TestCase(-14, 0xFFFF)]
        [TestCase(42, 0xEAD_BEEF)]
        [TestCase(1, 0x1234)]
        public void OperatorOr(int num, int mask)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(num);
            int shiftAmount = int.Parse(typeof(Q).ToString().Split('_')[1]); //num of fractional bits
            double expected = ((num << shiftAmount) | mask) / (double)(1 << shiftAmount);

            //Act
            Fixed<Q> actual = fixedLeft | mask;

            //Assert
            Assert.AreEqual(expected, actual.ToDouble(), delta: 0.01);
        }

        [TestCase(16, 0x0)]
        [TestCase(42, 0xFFF_FFFF)]
        [TestCase(-14, 0xFFFF)]
        [TestCase(42, 0xEAD_BEEF)]
        [TestCase(1, 0x1234)]
        public void OperatorXor(int num, int mask)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(num);
            int shiftAmount = int.Parse(typeof(Q).ToString().Split('_')[1]); //num of fractional bits
            double expected = ((num << shiftAmount) ^ mask) / (double)(1 << shiftAmount);

            //Act
            Fixed<Q> actual = fixedLeft ^ mask;

            //Assert
            Assert.AreEqual(expected, actual.ToDouble(), delta: 0.01);
        }
    }
}
