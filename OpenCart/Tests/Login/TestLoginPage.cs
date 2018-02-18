using NUnit.Framework;
using OpenCart.Data.Users;
using OpenCart.Pages;
using OpenCart.Pages.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
			//HomePage homePage = Application.Get().LoadHomePage();
			//Thread.Sleep(2000);
			// HomePage homePage = Application.Get().LoadHomePage();
			LoginPage loginPage = Application.Get().Login();
			loginPage.GoToLoginForLoginPageToMyAccountPage(user);
			Thread.Sleep(2000);
		}
	}
}

