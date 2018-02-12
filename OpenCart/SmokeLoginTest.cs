using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;

namespace OpenCart
{
    [TestFixture]
    public class SmokeLoginTest : TestRunner
    {
        private static readonly object[] CData =
        {
            new object[] { "U" }
        };

        [Test, TestCaseSource(nameof(CData))]
        public void CheckChangeCurrency(string c)
        {
            //driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")).Click();
            //driver.FindElement(By.Name(currencyName)).Click();
            //IWebElement actualPrice = driver.FindElement(By.XPath("//a[text()='"
            //    + itemName + "']/../../p[@class='price']"));
            //Console.WriteLine("actual string: " + actualPrice.Text.Trim());
            //Assert.True(actualPrice.Text.Trim().Contains(expectedPrice));
            //Console.WriteLine("CheckChangeCurrency done, currency = " + currencyName);
            //Thread.Sleep(1000);
        }
    }
}
