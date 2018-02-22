using OpenCart.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class EditAddressBook  : AColumnRightUserComponent //TODO
    {
        //protected ISearch Search { get; private set; }

        public IWebElement EditAddressBookButton
        { get { return Search.CssSelector("a.btn.btn-info"); } }

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

        public IWebElement SelectCountryList
        { get { return Search.Id("input-country"); } }

        public IWebElement SelectStateList
        { get { return Search.Id("input-zone"); } }

        public IWebElement EditButton
        { get { return Search.CssSelector("input.btn.btn-primary"); } }

        public void ClickEditAddressBookButton()
        {
            EditAddressBookButton.Click();
        }

        public void ClearEditFirstNameField()
        {
            EditFirstNameField.Clear();
        }

        public void ClearEditLastNameField()
        {
            EditLastNameField.Clear();
        }

        public void ClearEditDefaultAddressField()
        {
            EditDefaultAddressField.Clear();
        }

        public void ClearEditAdditionalAddressField()
        {
            EditAdditionalAddressField.Clear();
        }

        public void ClearEditCityField()
        {
            EditCityField.Clear();
        }

        public void ClearEditPostCodeField()
        {
            EditPostCodeField.Clear();
        }

        /*
            Todo in test`s        
            //Verify
            IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
            Assert.AreEqual("Your address has been successfully updated", actual.Text);
         */
    }
}
