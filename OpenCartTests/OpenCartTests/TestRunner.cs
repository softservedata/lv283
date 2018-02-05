using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests
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
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void Preconditions()
        {
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("adelyna.emrie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("input-password")).Submit();
        }

        public void CreateReview(string review)
        {
            driver.FindElement(By.Id("input-review")).SendKeys(review);
            driver.FindElement(By.CssSelector("input[name=\"rating\"][value =\"3\"]")).Click();
            driver.FindElement(By.Id("button-review")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }

        public void MoveToReviewTab()
        {
            driver.FindElement(By.XPath(@"//a[text()='Components']")).Click();
            driver.FindElement(By.XPath(@"//a[text() = 'Monitors (2)']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'&product_id=42')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,\"#tab-review\")]")).Click();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://zewer.beget.tech/");
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

    }

}
