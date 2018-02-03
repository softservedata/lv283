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
            driver.Navigate().GoToUrl("http://283-taqc.ml/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [SetUp]
        public void SetUp()
        {
            
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();

        }
    }
}
