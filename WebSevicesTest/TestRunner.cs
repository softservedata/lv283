using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSevicesTest.ServiceReference1;

namespace WebSevicesTest
{
    public class TestRunner
    {
        protected CalcSEIClient calculator;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            calculator = new CalcSEIClient();
        }
    }
}
