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
		protected IWebDriver driver;
		protected IWebElement actual;
		protected IWebElement password;
		protected IWebElement confirm;



		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			driver = new FirefoxDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Navigate().GoToUrl("http://283-taqc.ml/");
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			driver.Quit();
		}
	}
}
