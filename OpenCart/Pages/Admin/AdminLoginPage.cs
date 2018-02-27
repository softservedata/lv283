using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;
using OpenCart.Pages.User;
using OpenCart.Data.Users;

namespace OpenCart.Pages.Admin
{
    public class AdminLoginPage
    {
        protected ISearch Search { get; private set; }
        //
        public IWebElement UserName
        { get { return Search.Name("username"); } }
        public IWebElement Password
        { get { return Search.Name("password"); } }
        public IWebElement Login
        { get { return Search.CssSelector(".btn.btn-primary"); } }

        public AdminLoginPage()
        {
            this.Search = Application.Get().Search;
        }

        //UserName field
        public void ClearUserNameField()
        {
            UserName.Clear();
        }

        public void SetUserNameField(string userName)
        {
            UserName.SendKeys(userName);
        }

        //Password field
        public void ClearPasswordField()
        {
            Password.Clear();
        }

        public void SetPasswordField(string password)
        {
            Password.SendKeys(password);
        }

        //Login Button
        public void ClickLogin()
        {
            Login.Click();
        }

        public void GetLoginToAdminPanel(IUser admin)
        {
            ClearUserNameField();
            SetUserNameField(admin.GetEmail());
            ClearPasswordField();
            SetPasswordField(admin.GetPassword());
            ClickLogin();
        }
    }
}