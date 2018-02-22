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

namespace OpenCart.Tests.EditAccount
{
	public class EditAccountTests : TestRunner
	{
		private static readonly object[] SearchUsers =
		{
			new object[] { UserRepository.Get().Registered() }
		};

		[Test, TestCaseSource(nameof(SearchUsers))]
		public void VerifySuccessChangeAccount(IUser validUser)
		{
			// Precondition
			// Steps
			EditAccountActions editAccountActions = Application.Get()
													 .LoadHomeActions()
													 .GotoLoginAccountActions()
													 .SuccessfulLogin(validUser)
													 .GotoEditAccountActions();
			// Verify
			Assert.AreEqual(validUser.GetFirstname(), editAccountActions.EditAccountPageOperation.GetFirstNameFieldText());
			//
			editAccountActions.GotoLogoutAccountActions();
			//
			Thread.Sleep(2000);
		}
	}
}