using NUnit.Framework;
using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenCart.Data.Passwords;
using OpenCart.Data.AccountsInfo;

namespace OpenCart
{
	[TestFixture]
	public class EditTests: TestRunner
	{
			
		private static readonly object[] UsersData =
		{
            new object[] { UserRepository.Get().ValidUser() }
		};

		[Test, Order(1), TestCaseSource(nameof(UsersData))]
		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			LoginPage login = home.GoToLoginPage();
			AccountPage accountPage = login.GoToAccountPage(user.GetEmail(), user.GetPassword());
			accountPage.GoToEditPasswordPage();
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
			Assert.True(editPasswordPage.Actual.Text.Trim().Equals("Password must be between 4 and 20 characters!"));
		}

		private static readonly object[] ConfirmsData =
		{
			new object[] {  PasswordRepository.Get().IncorrectConfirm() }
		};

		[Test, TestCaseSource(nameof(ConfirmsData))]
		public void EditIncorrectConfirmField(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterConfirm(password.GetPasswordField(), password.GetConfirmField());
			Assert.True(editPasswordPage.Actual.Text.Trim().Equals("Password confirmation does not match password!"));
		}

		private static readonly object[] CorrectPasswordData =
		{
			new object[] {  PasswordRepository.Get().PasswordFour() },
			new object[] {  PasswordRepository.Get().PasswordTwenty() },
			new object[] {  PasswordRepository.Get().PasswordSix() }
		};

		[Test, TestCaseSource(nameof(CorrectPasswordData))]
		public void ChangePassword(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterConfirm(password.GetPasswordField(), password.GetConfirmField());
			editPasswordPage.ChangePassword();
			Assert.IsFalse(editPasswordPage.Actual.Text.Equals("Change"));
		}

		private static readonly object[] AccountData =
		{
			new object[] { AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, TestCaseSource(nameof(AccountData))]
		public void ChangeFirsname(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterFirstname(accountInfo.GetFirstname());
			Assert.IsTrue(editAccountPage.Actual.Text.Equals("Edit Information"));
		}

		[Test, TestCaseSource(nameof(AccountData))]
		public void ChangeLastname(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterLastname(accountInfo.GetLastname());
			Assert.IsTrue(editAccountPage.Actual.Text.Equals("Edit Information"));
		}

		[Test, TestCaseSource(nameof(AccountData))]
		public void ChangeTelephone(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterTelephone(accountInfo.GetPhone());
			Assert.IsTrue(editAccountPage.Actual.Text.Equals("Edit Information"));
		}

		private static readonly object[] Emails =
		{
			new object[] { AccountInfoRepository.Get().User1() },
			new object[] { AccountInfoRepository.Get().User2() },
			new object[] { AccountInfoRepository.Get().User3() },
			new object[] { AccountInfoRepository.Get().User4() },
			new object[] { AccountInfoRepository.Get().User5() },
			new object[] { AccountInfoRepository.Get().User6() },
			new object[] { AccountInfoRepository.Get().User7() }
		};
		[Test, TestCaseSource(nameof(Emails))]
		public void ChangeEmail(IAccountInfo accountInfo)
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.GoToEditAccount();

			editAccountPage.EnterEmail(accountInfo.GetEmail());
			Assert.IsFalse(editAccountPage.Actual.Text.Equals("Edit Information"));
		}

	}
}
