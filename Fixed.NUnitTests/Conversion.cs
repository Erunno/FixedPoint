using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Cuni.Arithmetics.FixedPoint;

namespace Fixed.NUnitTests
{
    [TestFixture(typeof(Q24_8))]
    [TestFixture(typeof(Q16_16))]
    [TestFixture(typeof(Q8_24))]
    class FixedTests_Conersion<T> where T : QFormat<T>
    {
        [TestCase(42)] //positive number
        [TestCase(-42)] //negative number
        public void ConversionTo_Q24_8(int baseNum)
        {
            //Arrange
            Fixed<T> baseFixed = new Fixed<T>(baseNum);

            //Act
            Fixed<Q24_8> converted = (Fixed<Q24_8>)baseFixed;

            //Assert
            Assert.AreEqual(baseFixed.ToDouble(), converted.ToDouble());
        }

        [TestCase(42)] //positive number
        [TestCase(-42)] //negative number
        public void ConversionTo_Q16_16(int baseNum)
        {
            //Arrange
            Fixed<T> baseFixed = new Fixed<T>(baseNum);

            //Act
            Fixed<Q16_16> converted = (Fixed<Q16_16>)baseFixed;

            //Assert
            Assert.AreEqual(baseFixed.ToDouble(), converted.ToDouble());
        }

        [TestCase(42)] //positive number
        [TestCase(-42)] //negative number
        public void ConversionTo_Q8_24(int baseNum)
        {
            //Arrange
            Fixed<T> baseFixed = new Fixed<T>(baseNum);

            //Act
            Fixed<Q16_16> converted = (Fixed<Q16_16>)baseFixed;

            //Assert
            Assert.AreEqual(baseFixed.ToDouble(), converted.ToDouble());
        }

        [TestCase(42)] //positive number
        [TestCase(-42)] //negative number
        public void ImplicitToInt(int num)
        {
            //Arrange
            Fixed<T> actual;

            //Act
            actual = num;

            //Assert
            Assert.AreEqual((double)num, actual.ToDouble());
        }

        [TestCase(42)] //positive number
        [TestCase(-42)] //negative number
        public void ExplicitToDouble(int num)
        {
            //Arrange
            Fixed<T> testedFixed = new Fixed<T>(num);

            //Act
            double actual = (double)testedFixed;

            //Assert
            Assert.AreEqual((double)num, actual);
        }
    }
}
