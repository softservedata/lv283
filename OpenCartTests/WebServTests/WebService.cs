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
            new object[] {0.7, "0.49" },
            new object[] {-3.3, "10.89" },
            new object[] {0, "0" },
        };

        private static readonly object[] ExceptionData =
        {
            new object[] { Double.MaxValue,  "NaN, Infinity" },
            new object[] { Double.MaxValue + 1 , "NaN, Infinity" },
            new object[] {Double.MaxValue/2 ,"NaN, Infinity"},
            new object[] { Double.MinValue, "NaN, Infinity" },
            new object[] { Double.MinValue - 1 , "NaN, Infinity" },
            new object[] {Double.MinValue/2 , "NaN, Infinity"},
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void TestSqrValid(double argument, string expected)
        {
            CalcSEIClient client = new CalcSEIClient();
            Console.WriteLine(client.sqr(argument));
            double actual = client.sqr(argument);
            Assert.AreEqual(expected, actual.ToString());
        }


        [Test, TestCaseSource(nameof(ExceptionData))]
        public void TestSqrInvlid(double argument, string expected)
        {
            CalcSEIClient client = new CalcSEIClient();
            Console.WriteLine(client.sqr(argument));
            double actual = client.sqr(argument);
            Assert.IsTrue(expected.Contains(actual.ToString()));
        }
    }

}
