﻿using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenCart.Data.AccountsInfo;

namespace OpenCart.Tests.EditAccount
{
	public class TestEditAccountTest : TestRunner
	{
		private static readonly object[] SearchUsers =
		{
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().ValidUser() }
		};

		[Test, TestCaseSource("SearchUsers")]
		public void VerifySuccessChangeAccount(IUser validUser, IAccountInfo validAccountInfo)
		{
			// Precondition
			// Steps
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .SuccessfulChangeAccount(validAccountInfo);

			// Verify
			Assert.AreEqual(AlertsText.EDIT_INFORMATION, editAccountActions.EditAccountPageOperation.GetChangeAccountText());
			//
			editAccountActions.GotoLogoutAccountActions();
			//
			
		}

		private static readonly object[] InvalidAccountData =
        {
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccount(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			// Precondition
			// Steps
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeAccount(invalidAccountInfo);

			// Verify
			Assert.AreEqual(AlertsText.FIRST_NAME_MUST_BE_1_TO_32, editAccountActions.EditAccountPageOperation.GetDangerText());

			//
			editAccountActions.GotoLogoutAccountActions();
			//
			
		}

		private static readonly object[] InvalidAccountFieldData =
		{
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountFirstnameField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeFirstnameFieldAccount(invalidAccountInfo);

			Assert.AreEqual(AlertsText.FIRST_NAME_MUST_BE_1_TO_32, editAccountActions.EditAccountPageOperation.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();
		}

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountLastnameField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeLastnameFieldAccount(invalidAccountInfo);

			Assert.AreEqual(AlertsText.LAST_NAME_MUST_BE_1_TO_32, editAccountActions.EditAccountPageOperation.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();
		}

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountTelephoneField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeTelephoneFieldAccount(invalidAccountInfo);

			Assert.AreEqual(AlertsText.TELEPHONE_MUST_BE_3_TO_32, editAccountActions.EditAccountPageOperation.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();
		}

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountEmailField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeEmailFieldAccount(invalidAccountInfo);

			Assert.AreEqual(AlertsText.EMAIL_DOES_NOT_APPER_TO_BE_VALID, editAccountActions.EditAccountPageOperation.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();
		}


	}
}
