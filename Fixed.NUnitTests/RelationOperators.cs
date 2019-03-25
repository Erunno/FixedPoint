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
    class RelationOperators<Q> where Q : QFormat<Q>
    {
        [TestCase(45, 78)] //both positive
        [TestCase(-42, 42)] //neg + pos
        [TestCase(42, -42)] //pos + neg
        [TestCase(-24, -42)] //both negative
        [TestCase(0, 42)] //zero + pos
        [TestCase(42, 0)] //pos + neg
        [TestCase(0, -42)] //zero + neg
        [TestCase(-42, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorEqualTo(int left, int right)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            Fixed<Q> fixedRight = new Fixed<Q>(right);

            //Act
            bool actual = (fixedLeft == fixedRight);

            //Assert
            Assert.AreEqual(left == right, actual);
        }

        [TestCase(45, 78)] //both positive
        [TestCase(-42, 42)] //neg + pos
        [TestCase(42, -42)] //pos + neg
        [TestCase(-24, -42)] //both negative
        [TestCase(0, 42)] //zero + pos
        [TestCase(42, 0)] //pos + neg
        [TestCase(0, -42)] //zero + neg
        [TestCase(-42, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorNotEqualTo(int left, int right)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            Fixed<Q> fixedRight = new Fixed<Q>(right);

            //Act
            bool actual = (fixedLeft != fixedRight);

            //Assert
            Assert.AreEqual(left != right, actual);
        }

        [TestCase(45, 78)] //both positive
        [TestCase(-42, 42)] //neg + pos
        [TestCase(42, -42)] //pos + neg
        [TestCase(-24, -42)] //both negative
        [TestCase(0, 42)] //zero + pos
        [TestCase(42, 0)] //pos + neg
        [TestCase(0, -42)] //zero + neg
        [TestCase(-42, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorLessThan(int left, int right)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            Fixed<Q> fixedRight = new Fixed<Q>(right);

            //Act
            bool actual = (fixedLeft < fixedRight);

            //Assert
            Assert.AreEqual(left < right, actual);
        }

        [TestCase(45, 78)] //both positive
        [TestCase(-42, 42)] //neg + pos
        [TestCase(42, -42)] //pos + neg
        [TestCase(-24, -42)] //both negative
        [TestCase(0, 42)] //zero + pos
        [TestCase(42, 0)] //pos + neg
        [TestCase(0, -42)] //zero + neg
        [TestCase(-42, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorMoreThan(int left, int right)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            Fixed<Q> fixedRight = new Fixed<Q>(right);

            //Act
            bool actual = (fixedLeft > fixedRight);

            //Assert
            Assert.AreEqual(left > right, actual);
        }

        [TestCase(45, 78)] //both positive
        [TestCase(-42, 42)] //neg + pos
        [TestCase(42, -42)] //pos + neg
        [TestCase(-24, -42)] //both negative
        [TestCase(0, 42)] //zero + pos
        [TestCase(42, 0)] //pos + neg
        [TestCase(0, -42)] //zero + neg
        [TestCase(-42, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorLessThanOrEqualTo(int left, int right)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            Fixed<Q> fixedRight = new Fixed<Q>(right);

            //Act
            bool actual = (fixedLeft <= fixedRight);

            //Assert
            Assert.AreEqual(left <= right, actual);
        }

        [TestCase(45, 78)] //both positive
        [TestCase(-42, 42)] //neg + pos
        [TestCase(42, -42)] //pos + neg
        [TestCase(-24, -42)] //both negative
        [TestCase(0, 42)] //zero + pos
        [TestCase(42, 0)] //pos + neg
        [TestCase(0, -42)] //zero + neg
        [TestCase(-42, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorMoreThanOrEqualTo(int left, int right)
        {
            //Arrange
            Fixed<Q> fixedLeft = new Fixed<Q>(left);
            Fixed<Q> fixedRight = new Fixed<Q>(right);

            //Act
            bool actual = (fixedLeft >= fixedRight);

            //Assert
            Assert.AreEqual(left >= right, actual);
        }
    }
}
