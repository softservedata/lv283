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
			log.Info("Start VerifySuccessChangeAccount() validUser = " + validUser.GetEmail());

			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .SuccessfulChangeAccount(validAccountInfo);

			log.Trace("Your account has been updated. Value= " + validAccountInfo.ToString());

			Assert.AreEqual(AlertsText.EDIT_INFORMATION, 
				           editAccountActions
						   .EditAccountPageOperation
						   .GetChangeAccountText());

			editAccountActions.GotoLogoutAccountActions()
							  .GotoLoginAccountActions()
							  .SuccessfulLogin(validUser)
							  .GotoEditAccountActions();

			Assert.AreEqual(validAccountInfo.GetFirstname(),
			                editAccountActions
			                .EditAccountPageOperation
			                .GetFirstNameFieldText());

			Assert.AreEqual(validAccountInfo.GetLastname(),
	                        editAccountActions
	                        .EditAccountPageOperation
	                        .GetLastNameFieldText());

			Assert.AreEqual(validAccountInfo.GetEmail(),
				            editAccountActions
				            .EditAccountPageOperation
				            .GetEmailFieldText());

			Assert.AreEqual(validAccountInfo.GetPhone(),
			             	editAccountActions
				            .EditAccountPageOperation
				            .GetTelephoneFieldText());

			log.Trace(AlertsText.SUCCESS);

			editAccountActions.GotoLogoutAccountActions();

			log.Info("Done Start VerifySuccessChangeAccount()");
		}

		private static readonly object[] InvalidAccountData =
        {
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccount(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			log.Info("Start VerifyUnsuccessChangeAccount() validUser = " + validUser.GetEmail());

			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeAccount(invalidAccountInfo);

			log.Trace(AlertsText.FIRST_NAME_MUST_BE_1_TO_32 + " Value= " + invalidAccountInfo.GetEmail());

			Assert.AreEqual(AlertsText.FIRST_NAME_MUST_BE_1_TO_32,
				            editAccountActions
							.EditAccountPageOperation
							.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangeAccount()");

		}

		private static readonly object[] InvalidAccountFieldData =
		{
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountFirstnameField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			log.Info("Start VerifyUnsuccessChangeAccountFirstnameField() validUser = " + validUser.GetEmail());

			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeFirstnameFieldAccount(invalidAccountInfo);

			log.Trace(AlertsText.FIRST_NAME_MUST_BE_1_TO_32 + " Value= " + invalidAccountInfo.GetFirstname());

			Assert.AreEqual(AlertsText.FIRST_NAME_MUST_BE_1_TO_32, 
				            editAccountActions
							.EditAccountPageOperation
							.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangeAccountFirstnameField()");
		}

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountLastnameField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			log.Info("Start VerifyUnsuccessChangeAccountLastnameField() validUser = " + validUser.GetEmail());

			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeLastnameFieldAccount(invalidAccountInfo);

			log.Trace(AlertsText.LAST_NAME_MUST_BE_1_TO_32 + " Value= " + invalidAccountInfo.GetLastname());

			Assert.AreEqual(AlertsText.LAST_NAME_MUST_BE_1_TO_32, 
				            editAccountActions
							.EditAccountPageOperation
							.GetDangerText());

			editAccountActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangeAccountLastnameField()");
		}

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountTelephoneField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			log.Info("Start VerifyUnsuccessChangeAccountTelephoneField() validUser = " + validUser.GetEmail());

			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeTelephoneFieldAccount(invalidAccountInfo);

			log.Trace(AlertsText.TELEPHONE_MUST_BE_3_TO_32 + " Value= " + invalidAccountInfo.GetPhone());

			Assert.AreEqual(AlertsText.TELEPHONE_MUST_BE_3_TO_32, 
				           editAccountActions
						   .EditAccountPageOperation
						   .GetDangerText());

			editAccountActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangeAccountTelephoneField()");
		}

		[Test, TestCaseSource("InvalidAccountData")]
		public void VerifyUnsuccessChangeAccountEmailField(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			log.Info("Start VerifyUnsuccessChangeAccountEmailField() validUser = " + validUser.GetEmail());

			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .UnsuccessfulChangeEmailFieldAccount(invalidAccountInfo);

			log.Trace(AlertsText.EMAIL_DOES_NOT_APPER_TO_BE_VALID + " Value= " + invalidAccountInfo.GetEmail());

			Assert.AreEqual(AlertsText.EMAIL_DOES_NOT_APPER_TO_BE_VALID, 
				            editAccountActions
							.EditAccountPageOperation
							.GetDangerText());
			 
			editAccountActions.GotoLogoutAccountActions();

			log.Info("Done VerifyUnsuccessChangeAccountEmailField()");
		}


	}
}
