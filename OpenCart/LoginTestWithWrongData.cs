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
    public class LoginTestWithWrongData : TestRunner
    {
        private static readonly object[] UserData =
        {
            //new object[] { UserRepository.Get().NewUser() },
            new object[] { UserRepository.Get().InvalidUser(), UserRepository.Get().AdminUser() },
            //new object[] { UserRepository.Get().AdminUser() }
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyBlockUserByIncorrectPassword(IUser user, IUser admin)
        {
            Assert.IsTrue(Application.Get().LoadLoginPage().IsUserBlocked(user.GetEmail(), user.GetPassword()));

            Assert.IsTrue(Application.Get().LoadAdminPage().GetLoginToAdminPanel(admin.GetEmail(), admin.GetPassword())
                .GetCustomers().GetUnlockCustomer(user.GetEmail()));

            //Application.Get().LoadAdminPage().GetLoginToAdminPanel(admin.GetEmail(), admin.GetPassword())
            //    .GetCustomers().GetDeletedCustomer(user.GetEmail()).GetAcceptPopUp();

            Thread.Sleep(1000);
        }
    }
}
