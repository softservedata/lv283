using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
    //[TestClass]
    [TestFixture]
    public class CurrencyTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://zewer.beget.tech/");
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("adelyna.emrie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("input-password")).Submit();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://zewer.beget.tech/");
        }

        [TearDown]
        public void TearDown()
        {

        }

        private static readonly object[] LikedData =
        {
            new object[] { "MacBook" },
            new object[] { "iPhone" }
        };

        [Test, Order(1), TestCaseSource(nameof(LikedData))]
        public void VerifyAddingToWishList(string itemName)
        {
            driver.FindElement(By.XPath("//div[@class='product-thumb transition']//a[text()='"
                + itemName + "']/../../../div[@class='button-group']/button[2]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.NotNull(driver.FindElement(By.XPath("//a[text()='" + itemName + "']")));
        }

        [Test, Order(2), TestCaseSource(nameof(LikedData))]////////kkjkj
        public void VerifyRemovingFromWishList(string itemName)
        {
            driver.FindElement(By.Id("wishlist-total")).Click();
            driver.FindElement(By.XPath("//a[text()='" + itemName + "']/../..//a[@class='btn btn-danger']")).Click();
            IReadOnlyCollection<IWebElement> iweb = driver.FindElements(By.XPath("//a[text()='" + itemName + "']"));
            Assert.IsTrue(iweb.Count == 0);
        }
    }
}