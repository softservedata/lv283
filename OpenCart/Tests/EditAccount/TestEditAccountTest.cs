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

			//Assert.AreEqual(validAccountInfo.GetFirstname(), editAccountActions.EditAccountPageOperation.GetFirstNameField());
			Thread.Sleep(2000);
			//
			editAccountActions.GotoLogoutAccountActions();
			//
			Thread.Sleep(2000);
		}
	}
}
