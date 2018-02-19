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
        { get { return Search.Name("email"); } }

        public IWebElement PasswordField
        { get { return Search.Name("password"); } }

        public IWebElement LoginButton
        { get { return Search.CssSelector(".btn.btn-primary:not(a)"); } }

        protected IWebElement DangerAlert
        { get { return Search.CssSelector(".alert.alert-danger"); } }

        //public const string MESSAGE_AFTER_BLOCK_USER = "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.";

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

        public string GetDangerAlertText()
        {
            return DangerAlert.Text;
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


        /*public bool LoginWrongUser(IUser invalidUser)
        {
            for (int i = 0; i < 6; i++)
            {
                ClearEMailField();
                SetEMailFieldText(invalidUser.GetEmail());
                ClearPasswordField();
                SetPasswordFieldText(invalidUser.GetPassword());
                ClickLoginButton();
            }
            return true;//BlockedUser.Text.Equals(MESSAGE_AFTER_BLOCK_USER);
        }*/

    }
}
