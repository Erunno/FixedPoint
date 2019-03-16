using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuni.Arithmetics.FixedPoint;

namespace Fixed.Tests
{
    [TestClass]
    public class Fixed_Q8_24
    {
        [TestMethod]
        public void Add_additionOfSimpleNumbers_SideTestOfToString()
        {
            //Arrange
            Fixed<Q8_24> a = new Fixed<Q8_24>(24);
            Fixed<Q8_24> b = new Fixed<Q8_24>(42);

            //Act
            var result = a.Add(b);

            //Assert
            Assert.AreEqual("66", result.ToString()); //result test

            //I dont have to test whether a or b is not changed since Fixed<T> is struct 
        }

        [TestMethod]
        public void Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString()
        {
            //Arrange
            Fixed<Q8_24> a = new Fixed<Q8_24>(24);
            Fixed<Q8_24> b = new Fixed<Q8_24>(42);

            //Act
            var result = a.Subtract(b);

            //Assert
            Assert.AreEqual((24 - 42).ToString(), result.ToString()); //result test
        }

        [TestMethod]
        public void Multiply_multiplicationOfnumbers_SideTestOfToString()
        {
            //Arrange
            Fixed<Q8_24> a = new Fixed<Q8_24>(3);
            Fixed<Q8_24> b = new Fixed<Q8_24>(42);

            //Act
            var result = a.Multiply(b);

            //Assert
            Assert.AreEqual((3 * 42).ToString(), result.ToString()); //result test
        }

        [TestMethod]
        public void Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString()
        {
            //Arrange
            Fixed<Q8_24> a = new Fixed<Q8_24>(3);
            Fixed<Q8_24> b = new Fixed<Q8_24>(-42);

            //Act
            var result = a.Multiply(b);

            //Assert
            Assert.AreEqual((3 * -42).ToString(), result.ToString()); //result test
        }

        [TestMethod]
        public void Divide_divisionOfSimpleNumbers_SideTestOfToString()
        {
            //Arrange
            Fixed<Q8_24> a = new Fixed<Q8_24>(24);
            Fixed<Q8_24> b = new Fixed<Q8_24>(42);

            //Act
            var result = b.Divide(a);

            //Assert
            Assert.AreEqual((42.0 / 24.0).ToString(), result.ToString()); //result test
        }
    }
}
