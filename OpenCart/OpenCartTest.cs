using System;
using OpenQA;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
    [TestFixture]
    public class OpenCartTest : RunOpenCartTests
    {
        [Test, Order(2)]
        public void TestDeleteButton()
        {
            driver.FindElement(By.XPath("//a[contains(@href, '/address')]")).Click();
            driver.FindElement(By.XPath("//*[@id='content']//tr[2]/td[2]/a[2]")).Click();

            //Verify
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully deleted", actual.Text);

            IWebElement backButton = driver.FindElement(By.CssSelector("a.btn.btn-default"));
            backButton.Click();
        }

        [Test, Order(1)]
        public void TestAddingAditionalAddress()
        {
            driver.FindElement(By.XPath("//a[contains(@href, '/address')]")).Click();
            driver.FindElement(By.CssSelector("a.btn.btn-primary")).Click();
            driver.FindElement(By.Id("input-firstname")).SendKeys("Marc");
            driver.FindElement(By.Id("input-lastname")).SendKeys("Rockfeler");
            driver.FindElement(By.Id("input-company")).SendKeys("Global Development Inc.");
            driver.FindElement(By.Id("input-address-1")).SendKeys("Green Street");
            driver.FindElement(By.Id("input-address-2")).SendKeys("Lindon Johnson Square");
            driver.FindElement(By.Id("input-city")).SendKeys("London");
            driver.FindElement(By.Id("input-postcode")).SendKeys("88015");
            
            OpenQA.Selenium.Support.UI.SelectElement selectCountry = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-country")));
            selectCountry.SelectByText("United Kingdom");
            
            OpenQA.Selenium.Support.UI.SelectElement selectState = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-zone")));
            selectState.SelectByText("Greater London");

            IWebElement continueButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            continueButton.Click();

            //Verify
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully inserted", actual.Text);
        }

        [Test, Order(3)]
        public void TestEditAddressButton()
        {
            driver.FindElement(By.XPath("//a[contains(@href, '/address')]")).Click();
            driver.FindElement(By.CssSelector("a.btn.btn-info")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("David");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("O`Conner");
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("Independence Square");
            driver.FindElement(By.Id("input-address-2")).Clear();
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("Dublin");
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("33167");

            OpenQA.Selenium.Support.UI.SelectElement selectCountryEdit = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-country")));
            selectCountryEdit.SelectByText("Ireland");

            OpenQA.Selenium.Support.UI.SelectElement selectStateEdit = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-zone")));
            selectStateEdit.SelectByText("Dublin");

            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

            //Verify
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully updated", actual.Text);
        }

        [TearDown]
        public void LoggingOut()
        {
            IWebElement logout = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
        }
    }
}
