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
        public static double GetSqrt(CalcSEIClient calc, double number)
        {
            double rez = 0;
            try
            {
                rez = calc.sqrt(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rez;
        }
    }
}
