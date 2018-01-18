using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace OpenCart
{
    [TestFixture]
    public class Login:TestRunner
    {
        
        [Test, Order(1)]
        public void login()
        {
            driver.Navigate().GoToUrl("http://283-taqc.ml/");
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@class='dropdown-toggle']")).Click();
            driver.FindElement(By.XPath("//*[@id='top-links']//a[text()='Login']")).Click();
            driver.FindElement(By.Name("email")).SendKeys("juwairiyah.bertie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("1111");
            driver.FindElement(By.XPath("//*[@id='content']//input[@class = 'btn btn-primary']")).Click();
        }

        //[Test]
        public void logout()
        {
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@class='dropdown-toggle']")).Click();
            driver.FindElement(By.XPath("//*[@id='top-links']//a[text()='Logout']")).Click();
        }

        [Test, Order(2)]
        public void AddShoppingCart()
        {
            driver.FindElement(By.XPath("//*[@id='logo']//img")).Click();
            driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@title='Shopping Cart']")).Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']//a[text() = 'MacBook']"));
            Assert.AreEqual("MacBook", cart.Text);
            

        }

        [Test, Order(3)]
        public void CheckOutShoppingCart()
        {
            driver.FindElement(By.XPath("//*[@id='content']//a[text() = 'Checkout']")).Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']/h1"));
            Assert.AreEqual("Checkout", cart.Text);
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@title='Shopping Cart']")).Click();
        }

        [Test, Order(4)]
        public void DeleteShoppingCart()
        {
            driver.FindElement(By.XPath("//*[@id='content']//button[2]")).Click();
            Thread.Sleep(1000);
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']/p"));
            Assert.AreEqual("Your shopping cart is empty!", cart.Text);
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@class='dropdown-toggle']")).Click();
            driver.FindElement(By.XPath("//*[@id='top-links']//a[text()='Logout']")).Click();
        }

        [Test, Order(5)]
        public void SaveShoppingCart()
        {
            login();

            driver.FindElement(By.XPath("//*[@id='menu']//a[text() = 'Tablets']")).Click();
            driver.FindElement(By.XPath("//*[@id='content']//div[@class = 'button-group']/button[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@title='Shopping Cart']")).Click();

            logout();

            login();

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='top-links']//a[@title='Shopping Cart']")).Click();
            Thread.Sleep(1000);
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']//a[text()='Samsung Galaxy Tab 10.1']"));
            Assert.AreEqual("Samsung Galaxy Tab 10.1", cart.Text);
        }
    }
}
