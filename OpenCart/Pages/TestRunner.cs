using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Data;
using NLog;

namespace OpenCart.Pages
{
    public abstract class TestRunner
    {
        protected static Logger log = LogManager.GetCurrentClassLogger();
        protected bool isTestSuccess;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get(ApplicationSourceRepository.ChromeEpizy());
            //Application.Get(ApplicationSourceRepository.ChromeWithoutUIEpizy());
            //Application.Get(); // Default
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
        }

        [SetUp]
        public void SetUp()
        {
            isTestSuccess = false;
            // Navigate to Home Page
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            if (!isTestSuccess)
            {
                Application.Get().SaveCurrentState();
            }
            // Logout
            Application.Get().LogoutAction().GotoHomeActions();
            Console.WriteLine("[TearDown] TearDown()");
            Thread.Sleep(4000);
        }

    }
}
