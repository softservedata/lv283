using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenCart.Data.Users;
using OpenCart.Pages;

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
			driver.Navigate().GoToUrl(url);
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			driver.Quit();
		}

		private static readonly object[] UsersData =
        {
			new object[] { UserRepository.Get().ValidUser() }
		};

		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			LoginPage login = home.GoToLoginPage();
			AccountPage accountPage = login.GoToAccountPage(user.GetEmail(), user.GetPassword());
			accountPage.GoToEditPasswordPage();
			//accountPage.clickOnLogout();
		}


		public void LogoutUser()
		{
			EditAccountPage editAccountPage = new EditAccountPage(driver);
			editAccountPage.Logout();
		}


		[SetUp]
		public void BeforeTest(IUser user)
		{
			driver.Navigate().GoToUrl(url);
			LoginUser(user);
		}

		[SetUp]
		public void AfterTest()
		{
          LogoutUser();
		}
	}
}
