using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenCart.Data.Passwords;

namespace OpenCart.Tests.EditPassword
{
	public class TestEditPasswordPage : TestRunner
	{
		private static readonly object[] SearchUsers =
	    {
			new object[] { UserRepository.Get().Registered(), PasswordRepository.Get().ValidPassword() }
		};

		[Test, TestCaseSource(nameof(SearchUsers))]
		public void VerifySuccessChangePassword(IUser validUser, Data.Passwords.IPassword validPassword)
		{
			// Precondition			// Steps
			EditPasswordActions editPasswordActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditPasswordActions()
													 .SuccessfulChangePassword(validPassword);
			Thread.Sleep(2000);
			// Verify
            //Assert.IsFalse(editPasswordActions.EditPasswordPageOperation.GetChangePasswordLabelText().Equals("Change Password"));
			//
			editPasswordActions.GotoLogoutAccountActions();
			Thread.Sleep(2000);
		}

		private static readonly object[] InvalidPasswords =
        {
			new object[] { UserRepository.Get().Registered(), PasswordRepository.Get().InvalidPasswordLessThanFour() },
			new object[] { UserRepository.Get().Registered(), PasswordRepository.Get().InvalidPasswordMoreThanTwentyOne() }
		};

		[Test, TestCaseSource(nameof(InvalidPasswords))]
		public void VerifyUnsuccessChangePassword(IUser validUser, Data.Passwords.IPassword invalidPassword)
		{
			// Precondition			// Steps
			EditPasswordActions editPasswordActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditPasswordActions()
													 .SuccessfulChangePassword(invalidPassword);
			Thread.Sleep(4000);
			// Verify
			Assert.AreEqual(AlertsText.PASSWORD_MUST_BE_4_TO_20, editPasswordActions.EditPasswordPageOperation.GetDangerText());
			//
			editPasswordActions.GotoLogoutAccountActions();
			Thread.Sleep(2000);
		}
	}


}
