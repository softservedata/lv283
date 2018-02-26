using System;
using NUnit.Framework;
using OpenCart.Data;

namespace OpenCart.Pages
{
    public abstract class TestRunner
    {
		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			Application.Get(ApplicationSourceRepository.ChromeEpizy());
			//Application.Get(ApplicationSourceRepository.ChromeWithoutUIEpizy());
			//Application.Get(); // Default
			Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			Application.Remove();
			Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
		}

		[SetUp]
		public void SetUp()
		{
			// Navigate to Home Page
			Console.WriteLine("[SetUp] SetUp()");
		}

		[TearDown]
		public void TearDown()
		{
			// Logout
			Application.Get().LogoutAction().GotoHomeActions();
			Console.WriteLine("[TearDown] TearDown()");
		}

	}
}
