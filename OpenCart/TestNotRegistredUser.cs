using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenCart.pages;

namespace OpenCart
{
    public class TestNotRegistredUser: TestRunner
    {
        [Test, Order(1)]
        public void AddShoppingCart()
        {
            MainPage MainPage = new MainPage(driver);
            MainPage.OpenCartBtn.Click();
            MainPage.AddToCartMac.Click();
            Thread.Sleep(1000);
            MainPage.ShopCartList.Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']//a[text() = 'MacBook']"));
            Assert.AreEqual("MacBook", cart.Text);


        }

        [Test, Order(2)]
        public void CheckOutShoppingCart()
        {
            MainPage MainPage = new MainPage(driver);
            MainPage.CheckOut.Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']/h1"));
            Assert.AreEqual("Checkout", cart.Text);
            MainPage.ShopCartList.Click();
        }

        [Test, Order(3)]
        public void DeleteShoppingCart()
        {
            MainPage MainPage = new MainPage(driver);
            MainPage.Delete.Click();
            Thread.Sleep(1000);
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']/p"));
            Assert.AreEqual("Your shopping cart is empty!", cart.Text);
        }
    }
}
