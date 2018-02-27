using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenCart.Data.Passwords;

namespace OpenCart.Tests.EditPassword
{
	public class TestEditPasswordPage : TestRunner
	{
		private static readonly object[] Users =
	    {
			new object[] { UserRepository.Get().Registered(), PasswordRepository.Get().ValidPassword() }
		};

		[Test, TestCaseSource("Users")]
		public void VerifySuccessChangePassword(IUser validUser, Data.Passwords.IPassword validPassword)
		{
			log.Info("Start VerifySuccessChangePassword() validUser = " + validUser.GetEmail());

			EditPasswordActions editPasswordActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditPasswordActions()
													 .SuccessfulChangePassword(validPassword);

			log.Trace("Password has been updated. Value= " + validPassword.GetPasswordField());

			editPasswordActions.GotoLogoutAccountActions()
								.GotoLoginAccountActions()
							    .SuccessfulLogin(validUser);

			Assert.AreEqual(AlertsText.LOGOUT,
						   editPasswordActions
						   .EditPasswordPageOperation
						   .GetLogoutTextLink());

			log.Trace("Password has been successfully updated. Value= " + validPassword.GetPasswordField());

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

			log.Trace(AlertsText.PASSWORD_MUST_BE_4_TO_20 + " Value= " + invalidPassword.GetPasswordField());

			Assert.AreEqual(AlertsText.PASSWORD_MUST_BE_4_TO_20,
				            editPasswordActions
				           .EditPasswordPageOperation
				           .GetDangerText());

			editPasswordActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangePassword()");
		}
	}


}
