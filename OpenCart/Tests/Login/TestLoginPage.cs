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
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Tests.Login
{
	public class TestLoginPage
	{
		private static readonly object[] CData =
		{

			new object[] { UserRepository.Get().UserTestLogin()}
		 };

		[Test, TestCaseSource(nameof(CData))]
		public void VerifySuccessfulLogin(IUser user)
		{
            ////HomePage homePage = Application.Get().LoadHomePage();
            ////Thread.Sleep(2000);
            //MyAccountPage myAccountPage = Application.Get().LoadLoginAccountActions();
			//HomePage homePage = Application.Get().LoadHomeAction
			////LoginPage loginPage = Application.Get().Login();
			////loginPage.GoToLoginForLoginPageToMyAccountPage(user);
			//LoginPage loginPage =  Application.Get()
			//										.LoadLoginAccountActions()
			//										.SuccessfulRegister(user);
			//Thread.Sleep(2000);
		}
	}
}

