using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Data.Users;

namespace OpenCart.Pages.User
{
    public class LoginAccountPage : ARightComponent
    {
        public IWebElement EMailField
        { get { return Search.CssSelector(""); } }

        public IWebElement PasswordField
        { get { return Search.CssSelector(""); } }

        public IWebElement LoginButton
        { get { return Search.CssSelector(""); } }

        public LoginAccountPage() : base() { }

        // EMailField
        public string GetEMailFieldText()
        {
            return EMailField.Text.Substring(0, 1);
        }

        public void SetEMailFieldText(string text)
        {
            EMailField.SendKeys(text);
        }

        public void ClearEMailField()
        {
            EMailField.Clear();
        }

        public void ClickEMailField()
        {
            EMailField.Click();
        }

        // PasswordField
        public string GetPasswordFieldText()
        {
            return PasswordField.Text.Substring(0, 1);
        }

        public void SetPasswordFieldText(string text)
        {
            PasswordField.SendKeys(text);
        }

        public void ClearPasswordField()
        {
            PasswordField.Clear();
        }

        public void ClickPasswordField()
        {
            PasswordField.Click();
        }

        // LoginButton
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        // Business Logic
        public void LoginUser(IUser user)
        {
            ClearEMailField();
            SetEMailFieldText(user.GetEmail());
            ClearPasswordField();
            SetPasswordFieldText(user.GetPassword());
            ClickLoginButton();
        }

    }
}
