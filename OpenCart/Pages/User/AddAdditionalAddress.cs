using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class AddAdditionalAddress  //: AColumnRightUserComponent // TODO
    {
        protected ISearch Search { get; private set; }
        public IWebElement AddressBook
        { get { return Search.XPath("//a[contains(@href, '/address')]"); } }

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

        //TODO in test`s

        //OpenQA.Selenium.Support.UI.SelectElement selectCountry = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-country")));
        //selectCountry.SelectByText("United Kingdom");
            
        //OpenQA.Selenium.Support.UI.SelectElement selectState = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(By.Id("input-zone")));
        //selectState.SelectByText("Greater London");

        //IWebElement continueButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
        //continueButton.Click();

        ////Verify
        //IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
        //Assert.AreEqual("Your address has been successfully inserted", actual.Text);
    }
}
