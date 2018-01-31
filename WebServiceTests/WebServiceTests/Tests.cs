using System;
using WebServiceTests.ServiceReference1;
using NUnit.Framework;

namespace WebServiceTests
{
    [TestFixture]
    public class Tests : Runner
    {
        [Test]
        public void SqrtTest()
        {
            double number = 25;
            double expected = 5;

            double actual = Sqrt.GetSqrt(calc, number);

            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}
