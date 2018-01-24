using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenCart.Data.Passwords;
using System.Threading;

namespace OpenCart
{
	[TestFixture]
	public class EditTests:TestRunner
	{
		//private IWebDriver driver;

		//DataProvider
		private static readonly object[] UsersData =
		{
            //Use Repository
            //Use Singleton
            new object[] { UserRepository.Get().ValidUser() }
		};

		//Parameterize Test
		[Test, Order(1), TestCaseSource(nameof(UsersData))]
		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			home.goToPage();
			LoginPage login = home.goToLoginPage();
			AccountPage accountPage = login.goToAccountPage(user.GetEmail(), user.GetPassword());
			//accountPage.goToEditPasswordPage();
			//accountPage.clickOnLogout();
		}


		private static readonly object[] PasswordsData =
		{
            new object[] {  PasswordRepository.Get().IncorrectPasswordLessThanFour() },
			new object[] {  PasswordRepository.Get().IncorrectPasswordLessThanTwentyOne() }
		};

		[Test, Order(2), TestCaseSource(nameof(PasswordsData))]
		public void EditIncorrectPasswordField(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterPassword(password.GetPasswordField());
			editPasswordPage.CheckEnterPassword();
			Thread.Sleep(1000);
		}

		private static readonly object[] ConfirmsData =
        {
			new object[] {  PasswordRepository.Get().IncorrectConfirm() }
		};

		[Test, Order(3), TestCaseSource(nameof(ConfirmsData))]
		public void EditIncorrectConfirmField(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterConfirm(password.GetPasswordField(), password.GetConfirmField());

			Thread.Sleep(1000);
			editPasswordPage.CheckEnterConfirm();			
		}

		private static readonly object[] CorrectPasswordData =
        {
			new object[] {  PasswordRepository.Get().Password4() },
			new object[] {  PasswordRepository.Get().Password20() },
			new object[] {  PasswordRepository.Get().Password6() }
		};

		[Test, Order(4), TestCaseSource(nameof(CorrectPasswordData))]
		public void ChangePassword(Data.Passwords.IPassword password)
		{

			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterConfirm(password.GetPasswordField(), password.GetConfirmField());
			Thread.Sleep(1000);
			editPasswordPage.CheckChangePassword();
		}

	}
	}
