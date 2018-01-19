using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace OpenCart
{
	[TestFixture]
	public class TestManagerFirefox
	{
		protected IWebElement editButton;
		protected IWebDriver driverfox;
		protected IWebElement actual;
		protected IWebElement password;
		protected IWebElement confirm;



		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			driverfox = new FirefoxDriver();
			driverfox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driverfox.Navigate().GoToUrl("http://283-taqc.ml/");
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			driverfox.Quit();
		}
	}
}
