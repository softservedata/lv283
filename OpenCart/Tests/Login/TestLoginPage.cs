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

namespace OpenCart.Tests.Login
{
	public class TestLoginPage : TestRunner
	{
		//private static readonly object[] CData =
		//{

		//	new object[] { UserRepository.Get().UserTestLogin()}
		// };

		private static readonly object[] SearchUsers =
				{
			new object[] { UserRepository.Get().Registered() }
		};

		[Test, TestCaseSource(nameof(SearchUsers))]
		public void VerifySuccessLogin(IUser validUser)
		{
			// Precondition
			// Steps
			MyAccountActions myAccountActions = Application.Get()
													.LoadHomeActions()
													.GotoLoginAccountActions()
													.SuccessfulLogin(validUser);
			// Verify
			Assert.AreEqual("Logout", myAccountActions.MyAccountPageOperation.GetLogoutTextLink());
			Thread.Sleep(2000);
			//
			// Return to previous state
			// TODO move to After Method
			myAccountActions.GotoLogoutAccountActions();
			//
			Thread.Sleep(2000);
		}
	}
}

