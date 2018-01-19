using System;
using OpenQA;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
    public abstract class RunOpenCartTests
    {
        protected IWebDriver driver;

        [SetUp]
        public void BeforeAllMethods()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            options.AddArguments("--ignore-certificate-errors");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://zewer.beget.tech");
        }

        [TearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void Logging()
        {
            IWebElement searchSpan = driver.FindElement(By.ClassName("caret"));
            searchSpan.Click();

            IWebElement search = driver.FindElement(By.LinkText("Login"));
            search.Click();

            IWebElement email = driver.FindElement(By.Id("input-email"));
            email.SendKeys("u1557328@mvrht.net");

            IWebElement password = driver.FindElement(By.Id("input-password"));
            password.SendKeys("qwerty");

            IWebElement loginButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            loginButton.Click();
        }
    }
}
