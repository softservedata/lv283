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
    public class RegisterNewUserTest : TestRunner
    {
        private static readonly object[] UserData =
        {
            new object[] { UserRepository.Get().NewUser(), UserRepository.Get().AdminUser() },
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyRegisterNewUser(IUser newUser, IUser admin)
        {

            Assert.IsTrue(
                Application.Get().LoadHomeActions()
                .GotoRegisterAccountActions()
                .SuccessfulRegister(newUser)
                .GetLogout()
                .IsLoginDisplayed()
                );
            //Thread.Sleep(4000);

            Assert.IsTrue(
                Application.Get().LoadAdminActions().GetLoginPage(admin)
                .GetCustomers()
                .GetDeletedCustomer(newUser)
                .IsCloseDisplayed()
                );

            //Assert.IsTrue(
            //    Application.Get().LoadHomeActions().GetLoginPage()
            //    .SuccessfulLogin(validUser)
            //    .GetLogout()
            //    .IsLoginDisplayed()
            //    );
        }
    }
}
