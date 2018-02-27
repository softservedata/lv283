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

		[Test, TestCaseSource("SearchUsers")]
		public void VerifySuccessChangePassword(IUser validUser, Data.Passwords.IPassword validPassword)
		{
			log.Info("Start VerifySuccessChangePassword() validUser = " + validUser.GetEmail());

			EditPasswordActions editPasswordActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditPasswordActions()
													 .SuccessfulChangePassword(validPassword);

			editPasswordActions.GotoLogoutAccountActions();

			log.Info("Done VerifySuccessChangePassword()");
		}

		private static readonly object[] InvalidPasswords =
        {
			new object[] { UserRepository.Get().Registered(), PasswordRepository.Get().InvalidPasswordLessThanFour() },
			new object[] { UserRepository.Get().Registered(), PasswordRepository.Get().InvalidPasswordMoreThanTwentyOne() }
		};

		[Test, TestCaseSource("InvalidPasswords")]
		public void VerifyUnsuccessChangePassword(IUser validUser, Data.Passwords.IPassword invalidPassword)
		{
			log.Info("Start VerifyUnsuccessChangePassword() validUser = " + validUser.GetEmail());

			EditPasswordActions editPasswordActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditPasswordActions()
													 .SuccessfulChangePassword(invalidPassword);
			// Verify
			Assert.AreEqual(AlertsText.PASSWORD_MUST_BE_4_TO_20,
				           editPasswordActions
				           .EditPasswordPageOperation
				           .GetDangerText());

			editPasswordActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangePassword()");
		}
	}


}
