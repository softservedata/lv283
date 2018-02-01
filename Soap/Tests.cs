using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Soap
{

    [TestFixture]
    public class Tests : Data
    {

        [Test, TestCaseSource(nameof(Data.PositiveData))]
        public void Positive(double num1, double num2, double sum)
        {
            Check(num1, num2, sum);
        }


        [Test, TestCaseSource(nameof(Data.NegativeData))]
        public void Negative(double num1, double num2, double sum)
        {
            Check(num1, num2, sum);
        }

        [Test, TestCaseSource(nameof(Data.PositiveAndNegativeData))]
        public void PositiveAndNegative(double num1, double num2, double sum)
        {
            Check(num1, num2, sum);
        }


        public void Check(double num1, double num2, double sum)
        {
            Assert.AreEqual(sum, client.add(num1, num2), 0.00001);
        }
    }
}
