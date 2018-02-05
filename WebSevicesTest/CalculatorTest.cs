using System;
using NUnit.Framework;

namespace WebSevicesTest
{
    [TestFixture]
    public class CalculatorTest : TestRunner
    {

        private static readonly object[] PositiveData =
        {
            new object[] { 0.0, 0.0, 0.0},
            new object[] { 1.0, 1.0, 0.0 },
            new object[] { -1.0, -1.0, 0.0 },
            new object[] { -1.0, 1.0, -2.0},
            new object[] { 1.0, -1.0, 2.0 },
            new object[] { 1, 0, 1 }
        };

        [Test, TestCaseSource(nameof(PositiveData))]
        public void VerifySubPositiveData(double firstNum, double secondNum, double expectedResult)
        {
            double actualResult = calculator.sub(firstNum, secondNum);

            Assert.AreEqual(expectedResult, actualResult, 0.001);
        }
    }
}
