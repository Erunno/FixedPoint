using NUnit.Framework;
using Cuni.Arithmetics.FixedPoint;

namespace Tests
{
    [TestFixture(typeof(Q24_8))]
    [TestFixture(typeof(Q16_16))]
    [TestFixture(typeof(Q8_24))]
    public class FixedTests<T> where T : QFormat<T>
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
        public void OperatorPlus(int leftOp, int rightOp)
        {
            //Arrange
            Fixed<T> left = new Fixed<T>(leftOp);
            Fixed<T> right = new Fixed<T>(rightOp);
            double expectedResult = (double)leftOp + (double)rightOp;

            //Act
            Fixed<T> actualResult = left + right;

            //Assert
            Assert.AreEqual(expectedResult, actualResult.ToDouble());
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
        public void OperatorMinus(int leftOp, int rightOp)
        {
            //Arrange
            Fixed<T> left = new Fixed<T>(leftOp);
            Fixed<T> right = new Fixed<T>(rightOp);
            double expectedResult = (double)leftOp - (double)rightOp;

            //Act
            Fixed<T> actualResult = left - right;

            //Assert
            Assert.AreEqual(expectedResult, actualResult.ToDouble());
        }

        [TestCase(21, 3)] //both positive
        [TestCase(-5, 5)] //neg + pos
        [TestCase(5, -5)] //pos + neg
        [TestCase(-24, -5)] //both negative
        [TestCase(0, 5)] //zero + pos
        [TestCase(5, 0)] //pos + neg
        [TestCase(0, -5)] //zero + neg
        [TestCase(-5, 0)] //neg + neg
        [TestCase(0, 0)] //both zero
        public void OperatorTimes(int leftOp, int rightOp)
        {
            //Arrange
            Fixed<T> left = new Fixed<T>(leftOp);
            Fixed<T> right = new Fixed<T>(rightOp);
            double expectedResult = (double)leftOp * (double)rightOp;

            //Act
            Fixed<T> actualResult = left * right;

            //Assert
            Assert.AreEqual(expectedResult, actualResult.ToDouble(), delta: 0.01);
        }

        [TestCase(45, 7)] //both positive
        [TestCase(-5, 5)] //neg + pos
        [TestCase(5, -5)] //pos + neg
        [TestCase(-24, -5)] //both negative
        [TestCase(0, 5)] //zero + pos
        [TestCase(0, -5)] //zero + neg
        public void OperatorDivide(int leftOp, int rightOp)
        {
            //Arrange
            Fixed<T> left = new Fixed<T>(leftOp);
            Fixed<T> right = new Fixed<T>(rightOp);
            double expectedResult = (double)leftOp / (double)rightOp;

            //Act
            Fixed<T> actualResult = left / right;

            //Assert
            Assert.AreEqual(expectedResult, actualResult.ToDouble(), delta: 0.01);
        }
    }
}