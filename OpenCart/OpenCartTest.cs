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
            IWebElement addressBook = driver.FindElement(By.XPath("//a[contains(@href, '/address')]"));
            addressBook.Click();

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='content']//tr[2]/td[2]/a[2]"));
            deleteButton.Click();

            //Check
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully deleted", actual.Text);

            IWebElement backButton = driver.FindElement(By.CssSelector("a.btn.btn-default"));
            backButton.Click();
        }

        [Test, Order(1)]
        public void TestAddingAditionalAddress()
        {
            IWebElement addressBook = driver.FindElement(By.XPath("//a[contains(@href, '/address')]"));
            addressBook.Click();

            IWebElement newAddressButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            newAddressButton.Click();

            IWebElement nameTextBox = driver.FindElement(By.Id("input-firstname"));
            nameTextBox.SendKeys("Marc");

            IWebElement lastnameTextBox = driver.FindElement(By.Id("input-lastname"));
            lastnameTextBox.SendKeys("Rockfeler");

            IWebElement company = driver.FindElement(By.Id("input-company"));
            company.SendKeys("Global Development Inc.");

            IWebElement address = driver.FindElement(By.Id("input-address-1"));
            address.SendKeys("Green Street");

            IWebElement aditionalAddress = driver.FindElement(By.Id("input-address-2"));
            aditionalAddress.SendKeys("Lindon Johnson Square");

            IWebElement city = driver.FindElement(By.Id("input-city"));
            city.SendKeys("London");

            IWebElement postcode = driver.FindElement(By.Id("input-postcode"));
            postcode.SendKeys("88015");


            OpenQA.Selenium.Support.UI.SelectElement selectCountry = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-country")));
            selectCountry.SelectByText("United Kingdom");


            OpenQA.Selenium.Support.UI.SelectElement selectState = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-zone")));
            selectState.SelectByText("Greater London");

            IWebElement continueButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            continueButton.Click();

            //Check
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully inserted", actual.Text);
        }

        [Test, Order(3)]
        public void TestEditAddressButton()
        {
            IWebElement addressBook = driver.FindElement(By.XPath("//a[contains(@href, '/address')]"));
            addressBook.Click();

            IWebElement editButton = driver.FindElement(By.CssSelector("a.btn.btn-info"));
            editButton.Click();

            IWebElement nameTextBox = driver.FindElement(By.Id("input-firstname"));
            nameTextBox.Clear();
            nameTextBox.SendKeys("David");

            IWebElement lastnameTextBox = driver.FindElement(By.Id("input-lastname"));
            lastnameTextBox.Clear();
            lastnameTextBox.SendKeys("O`Conner");

            IWebElement address = driver.FindElement(By.Id("input-address-1"));
            address.Clear();
            address.SendKeys("Independence Square");

            IWebElement aditionalAddress = driver.FindElement(By.Id("input-address-2"));
            aditionalAddress.Clear();

            IWebElement city = driver.FindElement(By.Id("input-city"));
            city.Clear();
            city.SendKeys("Dublin");

            IWebElement postcode = driver.FindElement(By.Id("input-postcode"));
            postcode.Clear();
            postcode.SendKeys("33167");

            OpenQA.Selenium.Support.UI.SelectElement selectCountryEdit = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-country")));
            selectCountryEdit.SelectByText("Ireland");

            OpenQA.Selenium.Support.UI.SelectElement selectStateEdit = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-zone")));
            selectStateEdit.SelectByText("Dublin");

            IWebElement continueButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            continueButton.Click();

            //Check
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
