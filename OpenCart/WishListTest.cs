using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace OpenCart
{
    [TestFixture]
    public class CurrencyTest : TestRunner
    {
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
            Thread.Sleep(2000);
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.NotNull(driver.FindElement(By.XPath("//a[text()='" + itemName + "']")));
        }

        [Test, Order(2), TestCaseSource(nameof(LikedData))]
        public void VerifyRemovingFromWishList(string itemName)
        {
            driver.FindElement(By.Id("wishlist-total")).Click();
            driver.FindElement(By.XPath("//a[text()='" + itemName + "']/../..//a[@class='btn btn-danger']")).Click();
            IReadOnlyCollection<IWebElement> iweb = driver.FindElements(By.XPath("//a[text()='" + itemName + "']"));
            Assert.IsTrue(iweb.Count == 0);
        }

        [Test, Order(2)]
        public void VerifyAccessToWishList()
        {
            AccessToAccount access = new AccessToAccount(driver);
            access.LogOut();
            driver.Navigate().GoToUrl("http://zewer.beget.tech/");
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.IsNotNull(driver.FindElement(By.Id("input-password")));
            access.LogIn(email, password);
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.IsNotNull(driver.FindElement(By.XPath("//h2[text()='My Wish List']")));
        }
    }
}