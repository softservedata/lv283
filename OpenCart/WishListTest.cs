using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenCart.Data.Commodities;
using OpenQA.Selenium;

namespace OpenCart
{
    [TestFixture]
    public class CurrencyTest : TestRunner
    {
        private static readonly object[] LikedData =
        {
            new object[] { CommodityRepository.Get().MacBook() },
            new object[] { CommodityRepository.Get().IPhone() }
        };

        [Test, Order(1), TestCaseSource(nameof(LikedData))]
        public void VerifyAddingToWishList(Commodity item)
        {
            driver.FindElement(By.XPath("//div[@class='product-thumb transition']//a[text()='"
                + item.GetName() + "']/../../../div[@class='button-group']/button[2]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.NotNull(driver.FindElement(By.XPath("//a[text()='" + item.GetName() + "']")));
        }

        [Test, Order(2), TestCaseSource(nameof(LikedData))]
        public void VerifyRemovingFromWishList(Commodity item)
        {
            driver.FindElement(By.Id("wishlist-total")).Click();
            driver.FindElement(By.XPath("//a[text()='" + item.GetName() + "']/../..//a[@class='btn btn-danger']")).Click();
            IReadOnlyCollection<IWebElement> iweb = driver.FindElements(By.XPath("//a[text()='" + item.GetName() + "']"));
            Assert.IsTrue(iweb.Count == 0);
        }

        [Test]
        public void VerifyAccessToWishList()
        {
            AccessToAccount access = new AccessToAccount(driver);
            access.LogOut();
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.IsNotNull(driver.FindElement(By.Id("input-password")));
            access.LogIn(email, password);
            driver.FindElement(By.Id("wishlist-total")).Click();
            Assert.IsNotNull(driver.FindElement(By.XPath("//h2[text()='My Wish List']")));
        }
    }
}