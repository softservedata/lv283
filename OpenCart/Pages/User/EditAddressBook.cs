using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class EditAddressBook // : AColumnRightUserComponent // TODO
    {
        protected ISearch Search { get; private set; }

        public IWebElement AddressBook
        { get { return Search.XPath("//a[contains(@href, '/address')]"); } }

        public IWebElement EditAddressBookButton
        { get { return Search.Css("a.btn.btn-info"); } }

        public IWebElement EditFirstNameField
        { get { return Search.Id("input-firstname"); } }
        
        public IWebElement EditLastNameField
        { get { return Search.Id("input-lastname"); } }

        public IWebElement EditDefaultAddressField
        { get { return Search.Id("input-address-1"); } }

        public IWebElement EditAdditionalAddressField
        { get { return Search.Id("input-address-2"); } }

        public IWebElement EditCityField
        { get { return Search.Id("input-city"); } }

        public IWebElement EditPostCodeField
        { get { return Search.Id("input-postcode"); } }



        /*
            Todo in test`s
            OpenQA.Selenium.Support.UI.SelectElement selectCountryEdit = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-country")));
            selectCountryEdit.SelectByText("Ireland");

            OpenQA.Selenium.Support.UI.SelectElement selectStateEdit = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-zone")));
            selectStateEdit.SelectByText("Dublin");

            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

            //Verify
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully updated", actual.Text);
         */
    }
}
