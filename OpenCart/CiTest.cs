using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace OpenCart
{
    [TestFixture]
    public class CiTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
        }

        [SetUp]
        public void SetUp()
        {
            //driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

        [Test]
        public void CheckRemoteServer()
        {
            //
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--headless");
            //options.AddArguments("--disable-extensions");
            //options.BinaryLocation = @"C:\Users\yharasym\Downloads\ChromiumPortable\ChromiumPortable.exe";
            driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.p
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            //
            driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")).Click();
            var currencyWebElements = driver.FindElements(By.CssSelector(".currency-select.btn.btn-link.btn-block"));
            foreach (IWebElement current in currencyWebElements)
            {
                Console.WriteLine("2 currency: " + current.Text.Substring(1));
            }
            Thread.Sleep(4000);
        }
    }
}
