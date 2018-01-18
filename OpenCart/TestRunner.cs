using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace OpenCart
{
    public class TestRunner
    {
        protected IWebDriver driver;


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://283-taqc.ml/");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Thread.Sleep(3000);
            driver.Quit();

        }
    }
}
