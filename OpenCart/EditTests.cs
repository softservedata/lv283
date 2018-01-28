using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;
using OpenCart.PagesTest;
using OpenCart.Data.Users;
using OpenCart.Data.Passwords;
using OpenCart.Data.AccountsInfo;
using OpenQA.Selenium.Support.UI;

namespace OpenCart
{
	[TestFixture]
	public class EditTests: TestRunner
	{
				
		private static readonly object[] UsersData =
		{
            new object[] { UserRepository.Get().ValidUser() }
		};
		//Parameterize Test
		[Test, Order(1), TestCaseSource(nameof(UsersData))]
		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			LoginPage login = home.GoToLoginPage();
			AccountPage accountPage = login.GoToAccountPage(user.GetEmail(), user.GetPassword());
			accountPage.GoToEditPasswordPage();
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
			//Thread.Sleep(1000);
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
			editPasswordPage.CheckChangePassword();
		}

		private static readonly object[] AccountData =
		{
			new object[] { AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, Order(5), TestCaseSource(nameof(AccountData))]
		public void ChangeFirsname(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterFirstname(accountInfo.GetFirstname());
			editAccountPage.CheckEditInvalideInformation();
		}

		[Test, Order(6), TestCaseSource(nameof(AccountData))]
		public void ChangeLastname(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterLastname(accountInfo.GetLastname());
			editAccountPage.CheckEditInvalideInformation();
		}

		[Test, Order(7), TestCaseSource(nameof(AccountData))]
		public void ChangeTelephone(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterTelephone(accountInfo.GetPhone());
			editAccountPage.CheckEditInvalideInformation();
			//editAccountPage.Logout();
		}



	}
	}
