using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenCart.Base;

namespace OpenCart
{
    [TestFixture]
    public class SearchTests : TestRunner
    {
        private static string[] positiveSearchData = new string[] { "mac", "5d", "30" };
        private static string[] negativeSearchData = new string[] { "$", "%", " ", "" };

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

        [Test, TestCaseSource("negativeSearchData")]
        public void NegativeSearchTest(string searchName)
        {
            driver.FindElement(By.Name("search")).SendKeys(searchName);
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();

            Assert.NotNull(driver.FindElement(By.XPath("//div[@id='content']/p[contains(text(), 'no product')]")));
        }

        [Test]
        public void TooLongSearchTextTest()
        {
            driver.FindElement(By.Name("search")).SendKeys("sumsungsumsungsumsungsumsungsumsungsumsungsumsungsumsungsumsungsumsungsumsungsumsung");
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();

            Assert.IsFalse((bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.documentElement.scrollWidth>document.documentElement.clientWidth;"));
        }

    }
}
