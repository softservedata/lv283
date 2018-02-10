using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenCart.pages;
using OpenCart.Data;

namespace OpenCart
{
    [TestFixture]
    public class TestLogedUser:TestRunner
    {
        
        [Test, Order(1)]
        public void login()
        {
            MainPage mainPage = new MainPage(driver);
            LoginPage loginPage = new LoginPage(driver);
            UserRepository users = UserRepository.Get();
            mainPage.MyAccountBtn.Click();
            mainPage.LoginBtn.Click();
            loginPage.LoginIntoShop(users.DBUser().GetEmail(),
                users.DBUser().GetPassword());
        }

        //[Test]
        public void logout()
        {
            HomePage homePage = new HomePage(driver);
            homePage.MyAccountBtn.Click();
            homePage.LogOutBtn.Click();
        }

        [Test, Order(2)]
        public void AddShoppingCart()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenCartBtn.Click();
            homePage.AddToCartMac.Click();
            Thread.Sleep(1000);
            homePage.ShopCartList.Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']//a[text() = 'MacBook']"));
            Assert.AreEqual("MacBook", cart.Text);
            

        }

        [Test, Order(3)]
        public void CheckOutShoppingCart()
        {
            HomePage homePage = new HomePage(driver);
            homePage.CheckOut.Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']/h1"));
            Assert.AreEqual("Checkout", cart.Text);
            
        }

        [Test, Order(4)]
        public void DeleteShoppingCart()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ShopCartList.Click();
            homePage.Delete.Click();
            Thread.Sleep(1000);
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']/p"));
            Assert.AreEqual("Your shopping cart is empty!", cart.Text);
            logout();
        }

        [Test, Order(5)]
        public void SaveShoppingCart()
        {
            HomePage homePage = new HomePage(driver);
            login();

            homePage.TabletsBtn.Click();
            driver.FindElement(By.XPath("//*[@id='content']//div[@class = 'button-group']/button[1]")).Click();
            Thread.Sleep(1000);
            homePage.ShopCartList.Click();

            logout();

            login();

            Thread.Sleep(1000);
            homePage.ShopCartList.Click();
            Thread.Sleep(1000);
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='content']//a[text()='Samsung Galaxy Tab 10.1']"));
            Assert.AreEqual("Samsung Galaxy Tab 10.1", cart.Text);
            homePage.Delete.Click();
        }
    }
}
