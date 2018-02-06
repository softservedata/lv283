using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using WebServTests.CalcService;

namespace WebServTests
{
    [TestFixture]
    public class WebService
    {
        private static readonly object[] TestData =
        {
            new object[] {0.7},
            new object[] {-3.3 },
            new object[] {0}
        };

        private static readonly object[] ExceptionData =
        {
            new object[] { Double.MaxValue},
           
            new object[] {Double.MaxValue/2 },
            new object[] { Double.MinValue },
           
            new object[] {Double.MinValue/2 }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void TestSqrValid(double argument)
        {
            CalcSEIClient client = new CalcSEIClient();
            Console.WriteLine(client.sqr(argument));
            double actual = client.sqr(argument);
            double expected = client.sqr(argument);
            Assert.AreEqual(expected, actual);
        }


        [Test, TestCaseSource(nameof(ExceptionData))]
        public void TestSqrInvlid(double argument)
        {
            CalcSEIClient client = new CalcSEIClient();
            double actual = 0.0;
            double expected = 0.0;
            Console.WriteLine(client.sqr(argument));
            try
            {
                actual = client.sqr(argument);
                expected = client.sqr(argument);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreEqual(expected, actual);
        }
    }

}
