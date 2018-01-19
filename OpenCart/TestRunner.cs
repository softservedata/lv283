using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;

        protected string email = "adelyna.emrie@arockee.com";

        protected string password = "qwerty";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://zewer.beget.tech/");
            AccessToAccount access = new AccessToAccount(driver);
            access.LogIn(email, password);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            AccessToAccount access = new AccessToAccount(driver);
            access.LogOut();
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://zewer.beget.tech/");
        }

    }
}

