using OpenQA;
using System;
using OpenCart.Tools;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class AddAdditionalAddress  : AColumnRightUserComponent // TODO
    {
        //protected ISearch Search { get; private set; }

        public IWebElement AddToAddressBookButton
        { get { return Search.CssSelector("a.btn.btn-primary"); } }

        public IWebElement EmailField
        { get { return Search.Id("input-email"); } }

        public IWebElement InputFirstNameField
        { get { return Search.Id("input-firstname"); } }

        public IWebElement InputLastNameField
        { get { return Search.Id("input-lastname"); } }

        public IWebElement InputCompanyField
        { get { return Search.Id("input-company"); } }

        public IWebElement InputDefaultAddressField
        { get { return Search.Id("input-address-1"); } }

        public IWebElement InputAdditionalAddressField
        { get { return Search.Id("input-address-2"); } }

        public IWebElement InputCityField
        { get { return Search.Id("input-city"); } }

        public IWebElement InputPostCodeField
        { get { return Search.Id("input-postcode"); } }

        public IWebElement SelectCountryList
        { get { return Search.Id("input-country"); } }

        public IWebElement SelectStateList
        { get { return Search.Id("input-zone"); } }

        public IWebElement ContinueButton
        { get { return Search.CssSelector("input.btn.btn-primary"); } }

        public void ClickAddToAddressBookButton()
        {
            AddToAddressBookButton.Click();
        }

        public void ClearEmailField()
        {
            EmailField.Clear();
        }

        public void ClearInputFirstNameField()
        {
            InputFirstNameField.Clear();
        }

        public void ClearInputLastNameField()
        {
            InputLastNameField.Clear();
        }

        public void ClearInputCompanyField()
        {
            InputCompanyField.Clear();
        }

        public void ClearInputDefaultAddressFiled()
        {
            InputDefaultAddressField.Clear();
        }

        public void ClearInputAdditionalAddressField()
        {
            InputAdditionalAddressField.Clear();
        }

        public void ClearInputCityField()
        {
            InputCityField.Clear();
        }

        public void ClearInputPostCodeField()
        {
            InputPostCodeField.Clear();
        }
        
        //TODO in test`s

        ////Verify
        //IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
        //Assert.AreEqual("Your address has been successfully inserted", actual.Text);
    }
}
