using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;
using OpenCart.Pages.User;
using OpenCart.Actions.User;
using OpenCart.Data.Users;

namespace OpenCart
{
    [TestFixture]
    public class SmokeLoginTest : TestRunner
    {
        private static readonly object[] CData =
        {
            new object[] { UserRepository.Get().UserTestLogin()}
        };

        [Test, TestCaseSource(nameof(CData))]
        public void CheckChangeCurrency(IUser user)
        {
			// HomePage homePage = Application.Get().LoadHomePage();
			LoginPage loginPage = Application.Get().Login();
			loginPage.InputPassword(user.GetEmail());
			loginPage.InputPassword(user.GetPassword());
			Thread.Sleep(2000);
        }
    }
}
