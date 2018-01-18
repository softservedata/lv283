using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTest
{
    [TestFixture]
    public class SearchTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://283-taqc.ml/");
        }

        [TearDown]
        public void TearDown()
        {
        }

        private static string[] positiveSearchData = new string[] { "mac", "5d", "30" };

        [Test, TestCaseSource("positiveSearchData")]
        public void PositiveSearchTest(string searchName)
        {
            driver.FindElement(By.Name("search")).SendKeys(searchName);
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();

            IList<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='caption']//h4//a[contains(@href, '&search=')]"));

            foreach (IWebElement el in elements)
            {
                Assert.IsTrue(el.Text.ToUpper().Contains(searchName.ToUpper()));
            }
        }

        private static string[] negativeSearchData = new string[] { "$", " ", "" };

        [Test, TestCaseSource("negativeSearchData")]
        public void NegativeSearchTest(string searchName)
        {
            driver.FindElement(By.Name("search")).SendKeys(searchName);
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='content']/p[contains(text(), 'no product')]")).Text.Contains("no product"));
            
            //IList<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='caption']//h4//a[contains(@href, '&search=')]"));
            //Assert.AreEqual(0, elements.Count);

        }

        [Test]
        public void SearchExTaxItemsTes()
        {
            driver.FindElement(By.Name("search")).SendKeys("%");
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();

            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".price-tax"));

            foreach (IWebElement el in elements)
            {
                Assert.IsTrue(el.Text.Contains("Ex Tax: "));
            }

        }
    }
}
