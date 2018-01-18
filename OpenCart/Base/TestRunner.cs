using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Base
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            options.AddArguments("--ignore-certificate-errors");
            //options.BinaryLocation = @"C:\Users\yharasym\Downloads\ChromiumPortable\ChromiumPortable.exe";
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            //Thread.Sleep(1000);
            driver.Quit();
            //Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

    }

}
