using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
	public class TestRunner
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;

		private readonly string url = @"http://283-taqc.ml/";

		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			driver.Manage().Window.Maximize();
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			driver.Quit();
		}

		[SetUp]
		public void BeforeTest()
		{
			driver.Navigate().GoToUrl(url);
		}
	}
}
