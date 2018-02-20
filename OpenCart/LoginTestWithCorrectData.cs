using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Commons;
using OpenCart.Data.Products;
using OpenCart.Pages.User;
using OpenCart.Pages.AdminPanel;
using OpenCart.Data.Users;

namespace OpenCart
{
    [TestFixture]
    public class LoginTestWithCorrectData : TestRunner
    {
        private static readonly object[] UserData =
        {
            new object[] { UserRepository.Get().ValidUser() },
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyLogin(IUser ValidUser)
        {
            Assert.IsTrue(
                Application.Get().LoadHomeActions().GetLoginPage()
                .SuccessfulLogin(ValidUser)
                .GetLogout()
                .IsLoginDisplayed()
                );
        }
    }
}
