using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.ObjectModel;

namespace OpenCart
{
    [TestFixture]
    public class FunctionalTest1
    {
        private IWebDriver driver;


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://283-taqc.ml/");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Thread.Sleep(3000);
            driver.Quit();

        }

        //[Test]
        public void CheckEmptyDropDown()
        {
            driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            IWebElement cart = driver.FindElement(By.CssSelector(".dropdown-menu.pull-right"));
            Assert.AreEqual("Your shopping cart is empty!", cart.Text);
        }

        //[Test]
        public void CheckDropDown1Item()
        {
            driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text() = 'MacBook']"));
            Assert.AreEqual("MacBook", cart.Text);
        }

        //[Test]
        public void CheckDropDown2Items()
        {
            driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
            driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text() = 'MacBook']"));
            Assert.AreEqual("MacBook", cart.Text);
            cart = driver.FindElement(By.XPath("//*[@id='cart']//td[text() = 'x 2']"));
            Assert.AreEqual("x 2", cart.Text);
        }


        [Test]
        public void CheckShoppingCart()
        {
            driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[text()='iPhone']/../../../div[@class='button-group']/button[1]")).Click();
            Thread.Sleep(1000);

            IWebElement dropdown = driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle"));
            dropdown.Click();
            IWebElement cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text() = 'MacBook']"));
            Assert.AreEqual("MacBook", cart.Text);
            cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text()='iPhone']"));
            Assert.AreEqual("iPhone", cart.Text);

            cart = driver.FindElement(By.XPath("//*[@id='cart']//td[@class='text-center']/button"));
            cart.Click();
            Thread.Sleep(1000);
            dropdown.Click();
            cart = driver.FindElement(By.XPath("//*[@id='cart']//td[@class='text-center']/button"));
            cart.Click();
            cart = driver.FindElement(By.CssSelector(".dropdown-menu.pull-right"));
            Thread.Sleep(1000);
            dropdown.Click();
            Assert.AreEqual("Your shopping cart is empty!", cart.Text);

        }

    }
}
