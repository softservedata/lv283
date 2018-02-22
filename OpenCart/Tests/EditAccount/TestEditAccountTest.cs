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
using OpenCart.Data.AccountsInfo;

namespace OpenCart.Tests.EditAccount
{
	public class TestEditAccountTest : TestRunner
	{
		private static readonly object[] SearchUsers =
		{
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().ValidUser() }
		};

		[Test, TestCaseSource(nameof(SearchUsers))]
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
			Thread.Sleep(2000);
			// Verify
			//Aert.AreEqual(AlertsText.SUCCESS, editAccountActions.EditAccountPageOperation.GetSuccessAlertText());
			Thread.Sleep(2000);
			//
			editAccountActions.GotoLogoutAccountActions();
			//
			Thread.Sleep(2000);
		}

		private static readonly object[] InvalidAccountData =
        {
			new object[] { UserRepository.Get().Registered(), AccountInfoRepository.Get().InvalidUser() }
		};

		[Test, TestCaseSource(nameof(InvalidAccountData))]
		public void VerifyUnsuccessChangeAccount(IUser validUser, IAccountInfo invalidAccountInfo)
		{
			// Precondition
			// Steps
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions()
													 .SuccessfulChangeAccount(invalidAccountInfo);
			Thread.Sleep(2000);
			// Verify
			Assert.AreEqual(AlertsText.EDIT_INFORMATION, editAccountActions.EditAccountPageOperation.GetChangeAccountText());
			Thread.Sleep(2000);
			//
			editAccountActions.GotoLogoutAccountActions();
			//
			Thread.Sleep(2000);
		}
	}
}
