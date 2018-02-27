using System;
using NUnit.Framework;
using OpenCart.Data;
using NLog;

namespace OpenCart.Pages
{
    public abstract class TestRunner
    {
		protected static Logger log = LogManager.GetCurrentClassLogger();
        protected bool isTestSuccess;

		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			Application.Get(ApplicationSourceRepository.ChromeEpizy());
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			Application.Remove();
		}

		[SetUp]
		public void SetUp()
		{
			isTestSuccess = false;
		}

		[TearDown]
		public void TearDown()
		{
			if (!isTestSuccess)
			{
				Application.Get().SaveCurrentState();
			}

			Application.Get().LogoutAction().GotoHomeActions();
		}

	}
}
