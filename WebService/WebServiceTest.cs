using System;
using WebService.ServiceReference1;
using NUnit.Framework;
using NUnit;

namespace WebService
{
    [TestFixture]
    public class WebServiceTest : CalcSEIClient
    {
        [Test, Order(1)]
        public void infinityIsTrueTestDiv()
        {
            bool expectedResultIsInfinity = true;
            Assert.AreEqual(expectedResultIsInfinity, double.IsInfinity(div(12, 0)));
        }

        [Test, Order(2)]
        public void valueDivideWithFirstArgumentBigger()
        {
            double expectedResultOfDividing = 8.0;
            Assert.AreEqual(expectedResultOfDividing, div(16, 2));
        }

        [Test, Order(3)]
        public void valueDivideWithSecondArgumentLower()
        {
            double expectedResult = 0.5;
            Assert.AreEqual(expectedResult, div(1, 2));
        }

        [Test, Order(4)]
        public void valueWithNegativeDivide()
        {
            double expectedNegativeValue = -1.5;
            Assert.AreEqual(expectedNegativeValue, div(-3, 2));
        }

        [Test, Order(5)]
        public void valueWithInvalidDivide()
        {
            double expectedResultIsZero = 0;
            Assert.AreEqual(expectedResultIsZero, div(0, 2));
        }
    }
}
