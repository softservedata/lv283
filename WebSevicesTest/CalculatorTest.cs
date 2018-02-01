using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebSevicesTest
{
    [TestFixture]
    public class CalculatorTest : TestRunner
    {

        private static readonly object[] PositiveData =
        {
            new object[] { 0.0, 0.0 },
            new object[] { 1.0, 1.0 },
            new object[] { -1.0, -1.0 },
            new object[] { -1.0, 1.0 },
            new object[] { 1.0, -1.0 },
            new object[] { 1, 0 }
        };

        [Test, TestCaseSource(nameof(PositiveData))]
        public void VerifySubPositiveData(double firstNum, double secondNum)
        {
            try
            {
                calculator.sub(firstNum, secondNum);

                double expectedResult = firstNum - secondNum;
                double actualResult = calculator.sub(firstNum, secondNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static readonly object[] NegativeData =
        {
            new object[] { 0,0 , 0,0 },
            new object[] { "0.0", "0.0" },
            new object[] { 0.0m, 0.0m },
            new object[] { }
        };

        [Test, TestCaseSource(nameof(NegativeData))]
        public void VerifySubNegativeData(double firstNum, double secondNum)
        {
            try
            {
                calculator.sub(firstNum, secondNum);
            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception)
            {
                
            }
        }
    }
}
