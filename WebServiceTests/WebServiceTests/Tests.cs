using System;
using WebServiceTests.ServiceReference1;
using NUnit.Framework;
using System.Collections;
using System.IO;

namespace WebServiceTests
{
    [TestFixture]
    public class Tests : Runner
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]        
        [TestCase(-1, 0/0.0)]
        public void SqrtTest(double input, double expected)
        {
            double actual;

            //check response from server
            Assert.IsTrue(Sqrt.GetSqrt(calc, input, out actual));

            //check result
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}
