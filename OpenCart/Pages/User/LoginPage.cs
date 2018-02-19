using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;

namespace OpenCart.Pages.User
{
    public class LoginPage
    {
        protected ISearch Search { get; private set; }

        protected IWebElement EmailAddress
        { get { return Search.Name("email"); } }

        protected IWebElement Password
        { get { return Search.Name("password"); } }

        protected IWebElement Login
        { get { return Search.CssSelector(".btn.btn-primary:not(a)"); } }

        protected IWebElement BlockedUser
        { get { return Search.CssSelector(".alert.alert-danger"); } }

        public const string MESSAGE_AFTER_BLOCK_USER = "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.";

        public LoginPage()
        {
            this.Search = Application.Get().Search;
        }

        //EmailAddress Field
        public void ClearEmailAddress()
        {
            EmailAddress.Clear();
        }

        public void SetEmailAddressField(string email)
        {
            EmailAddress.SendKeys(email);
        }

        //Password Field
        public void ClearPassword()
        {
            Password.Clear();
        }

        public void SetPasswordField(string password)
        {
            Password.SendKeys(password);
        }

        //Login Button
        public void ClickLoginButton()
        {
            Login.Click();
        }

        public bool IsUserBlocked(string email, string password)
        {
            for (int i = 0; i < 6; i++)
            {
                ClearEmailAddress();
                SetEmailAddressField(email);
                ClearPassword();
                SetPasswordField(password);
                ClickLoginButton();
            }
            return BlockedUser.Text.Equals(MESSAGE_AFTER_BLOCK_USER);
        }

        public MyAccountPage GetLoginUser(string email, string password)
        {
            ClearEmailAddress();
            SetEmailAddressField(email);
            ClearPassword();
            SetPasswordField(password);
            ClickLoginButton();
            return new MyAccountPage();
        }
    }
}
