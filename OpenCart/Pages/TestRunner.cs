using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages
{
    public abstract class TestRunner
    {
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

    }
}
