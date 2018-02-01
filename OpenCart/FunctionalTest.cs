using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.ObjectModel;

namespace OpenCart
{
    [TestFixture]
    public class FunctionalTest1 : TestRunner
    {


        private static readonly object[] CurrencyData =
        {
            new object[] { "MacBook","iPhone"},
            new object[] { "MacBook", "MacBook"}
        };

        //[Test]
        public void CheckEmptyDropDown()
        {
            driver.Navigate().GoToUrl("http://283-taqc.ml/");
            driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            IWebElement cart = driver.FindElement(By.CssSelector(".dropdown-menu.pull-right"));
            Assert.AreEqual("Your shopping cart is empty!", cart.Text);
        }

        ////[Test]
        //public void CheckDropDown1Item()
        //{
        //    driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
        //    Thread.Sleep(3000);
        //    driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
        //    IWebElement cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text() = 'MacBook']"));
        //    Assert.AreEqual("MacBook", cart.Text);
        //}

        ////[Test]
        //public void CheckDropDown2Items()
        //{
        //    driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
        //    driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]")).Click();
        //    driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
        //    IWebElement cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text() = 'MacBook']"));
        //    Assert.AreEqual("MacBook", cart.Text);
        //    cart = driver.FindElement(By.XPath("//*[@id='cart']//td[text() = 'x 2']"));
        //    Assert.AreEqual("x 2", cart.Text);
        //}


        //[Test, TestCaseSource(nameof(CurrencyData))]
        //public void DeleteDropDown2Items(string itemname1, string itemname2)
        //{
        //    driver.Navigate().GoToUrl("http://283-taqc.ml/");
        //    driver.FindElement(By.XPath("//a[text()='" + itemname1 + "']/../../../div[@class='button-group']/button[1]")).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.XPath("//a[text()='" + itemname2 + "']/../../../div[@class='button-group']/button[1]")).Click();
        //    Thread.Sleep(1000);


        //    IWebElement dropdown = driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle"));
        //    dropdown.Click();
        //    IWebElement cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text() = '" + itemname1 + "']"));
        //    Assert.AreEqual(itemname1, cart.Text);
        //    cart = driver.FindElement(By.XPath("//*[@id='cart']//a[text()='" + itemname2 + "']"));
        //    Assert.AreEqual(itemname2, cart.Text);


        //    driver.FindElement(By.XPath("//*[@id='cart']//td[@class='text-center']/button")).Click();
        //    Thread.Sleep(1000);
        //    dropdown.Click();

        //    if (itemname1 != itemname2)
        //    {
        //        driver.FindElement(By.XPath("//*[@id='cart']//td[@class='text-center']/button")).Click();
        //        dropdown.Click();
        //    }

        //    Thread.Sleep(2000);
        //    cart = driver.FindElement(By.XPath("//*[@id='cart']//p[text() = 'Your shopping cart is empty!']"));
            

        //    Assert.AreEqual("Your shopping cart is empty!", cart.Text);

        //}

    }
}
