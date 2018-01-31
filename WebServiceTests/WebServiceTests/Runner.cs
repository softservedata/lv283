using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTests.ServiceReference1;
using NUnit.Framework;

namespace WebServiceTests
{
    public abstract class Runner
    {
        protected CalcSEIClient calc;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            calc = new CalcSEIClient();
        }
    }
}
