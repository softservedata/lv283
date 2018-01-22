using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Base;

namespace OpenCart
{
    [TestFixture]
    public class CurrencyTest : TestRunner
    {
        private static readonly object[] CurrencyData =
        {
            new object[] { "EUR", "MacBook", "560.94" },
            new object[] { "GBP", "MacBook", "487.62" },
            new object[] { "USD", "MacBook", "602.00" }
        };

        [Test, TestCaseSource(nameof(CurrencyData))]
        public void CheckChangeCurrency(string currencyName, string itemName, string expectedPrice)
        {
            driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")).Click();
            driver.FindElement(By.Name(currencyName)).Click();
            IWebElement actualPrice = driver.FindElement(By.XPath("//a[text()='"
                + itemName + "']/../../p[@class='price']"));
            Console.WriteLine("actual string: " + actualPrice.Text.Trim());
            Assert.True(actualPrice.Text.Trim().Contains(expectedPrice));
            Console.WriteLine("CheckChangeCurrency done, currency = " + currencyName);
            Thread.Sleep(1000);
        }
    }
}
