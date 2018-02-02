using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebService
{
    class SqrFunc
    {
        public double actual;
        public double expected;

        public void Set(double bases)
        {
            try
            { 
                //actual = calc.sqr(bases);
                expected = Math.Pow(bases,2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CheckSpec(double expected, double actual)
        {
            Assert.AreNotEqual(expected, actual);
        }

        public void Check(double expected, double actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
