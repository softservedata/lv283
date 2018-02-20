using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Data.Users;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Pages.User
{
    public class RegisterAccountPage : ARightComponent
    {
        public IWebElement FirstName
        { get { return Search.Name("firstname"); } }

        public IWebElement LastName
        { get { return Search.Name("lastname"); } }

        public IWebElement Email
        { get { return Search.Name("email"); } }

        public IWebElement Telephone
        { get { return Search.Name("telephone"); } }

        public IWebElement Fax
        { get { return Search.Name("fax"); } }

        public IWebElement Company
        { get { return Search.Name("company"); } }

        public IWebElement Address1
        { get { return Search.Name("address_1"); } }

        public IWebElement Address2
        { get { return Search.Name("address_2"); } }

        public IWebElement City
        { get { return Search.Name("city"); } }

        public IWebElement PostCode
        { get { return Search.Name("postcode"); } }

        public IWebElement Country
        { get { return Search.Name("country_id"); } }

        public IWebElement Region
        { get { return Search.Name("zone_id"); } }

        public IWebElement Password
        { get { return Search.Name("password"); } }

        public IWebElement ConfirmPassword
        { get { return Search.Name("confirm"); } }

        public ICollection<IWebElement> Subscribe
        { get { return Search.Names("newsletter"); } }

        public IWebElement PrivacyPolicy
        { get { return Search.Name("agree"); } }

        public IWebElement ContinueButton
        { get { return Search.CssSelector(".btn.btn-primary"); } }

        // Fields for select options
        private SelectElement selectCountry;
        private SelectElement selectRegion;

        public RegisterAccountPage() : base()
        {
            selectCountry = new SelectElement(Country);
            selectRegion = new SelectElement(Region);
        }

        //FirstName
        public void ClearFirstName()
        {
            FirstName.Clear();
        }

        public void SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
        }

        //LastName
        public void ClearLastName()
        {
            LastName.Clear();
        }

        public void SetLastName(string lastName)
        {
            LastName.SendKeys(lastName);
        }

        //Email
        public void ClearEmail()
        {
            Email.Clear();
        }

        public void SetEmail(string email)
        {
            Email.SendKeys(email);
        }

        //Telephone
        public void ClearTelephone()
        {
            Telephone.Clear();
        }

        public void SetTelephone(string telephone)
        {
            Telephone.SendKeys(telephone);
        }

        //Fax
        public void ClearFax()
        {
            Fax.Clear();
        }

        public void SetFax(string fax)
        {
            Fax.SendKeys(fax);
        }

        //Company
        public void ClearCompany()
        {
            Company.Clear();
        }

        public void SetCompany(string company)
        {
            Fax.SendKeys(company);
        }

        //Address1
        public void ClearAddress1()
        {
            Address1.Clear();
        }

        public void SetAddress1(string address1)
        {
            Address1.SendKeys(address1);
        }

        //Address2
        public void ClearAddress2()
        {
            Address2.Clear();
        }

        public void SetAddress2(string address2)
        {
            Address2.SendKeys(address2);
        }

        //City
        public void ClearCity()
        {
            City.Clear();
        }

        public void SetCity(string city)
        {
            City.SendKeys(city);
        }

        //PostCode
        public void ClearPostCode()
        {
            PostCode.Clear();
        }

        public void SetPostCode(string postCode)
        {
            PostCode.SendKeys(postCode);
        }

        //Country
        public void SetCountry(string country)
        {
            selectCountry.SelectByText(country);
        }

        //Region
        public void SetRegion(string region)
        {
            selectRegion.SelectByText(region);
        }

        //Password
        public void ClearPassword()
        {
            Password.Clear();
        }

        public void SetPassword(string password)
        {
            Password.SendKeys(password);
        }

        //ConfirmPassword
        public void ClearConfirmPassword()
        {
            ConfirmPassword.Clear();
        }

        public void SetConfirmPassword(string confirmPassword)
        {
            ConfirmPassword.SendKeys(confirmPassword);
        }

        //Subscribe
        private void SetSubscribeYes()
        {
            Subscribe.ElementAt(0).Click();
        }
        private void SetSubscribeNo()
        {
            Subscribe.ElementAt(1).Click();
        }

        public void SetSubscribe(bool isSubscribed)
        {
            if (Convert.ToInt32(isSubscribed) == 1)
            {
                SetSubscribeYes();
            }
            else
            {
                SetSubscribeNo();
            }
        }

        //PrivacyPolicy
        public void ClickPrivacyPolicy()
        {
            PrivacyPolicy.Click();
        }

        //ContinueButton
        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        // Business Logic
        public void RegisterUser(IUser user)
        {
            SetFirstName(user.GetFirstname());
            SetLastName(user.GetLastname());
            SetEmail(user.GetEmail());
            SetTelephone(user.GetPhone());
            SetFax(user.GetFax());
            SetCompany(user.GetCompany());
            SetAddress1(user.GetAddressMain());
            SetAddress2(user.GetAddressAdd());
            SetCity(user.GetCity());
            SetPostCode(user.GetPostcode());
            SetCountry(user.GetCoutry());
            SetRegion(user.GetRegionState());
            SetPassword(user.GetPassword());
            SetConfirmPassword(user.GetPassword());
            SetSubscribe(user.GetSubscribe());
            ClickPrivacyPolicy();
            ClickContinueButton();
        }

    }
}
