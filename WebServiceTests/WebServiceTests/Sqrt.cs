using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTests.ServiceReference1;
using NUnit.Framework;

namespace WebServiceTests
{
    public static class Sqrt
    {
        public static bool GetSqrt(CalcSEIClient calc, double number, out double actual)
        {
            actual = 0xA;
            try
            {
                actual = calc.sqrt(number);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
