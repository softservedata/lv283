using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;
using OpenCart.Data.Users;

namespace OpenCart
{
	[TestFixture]
	public class Login:TestRunner
	{
		//private IWebDriver driver;

		//[SetUp]
		//public void SetUp()
		//{
		//	driver = new ChromeDriver();
		//	driver.Manage().Window.Maximize();
		//}
		//DataProvider
		private static readonly object[] UsersData =
		{
            //Use Repository
            //Use Singleton
            new object[] { UserRepository.Get().ValidUser() }
		};

		//Parameterize Test
		[Test, TestCaseSource(nameof(UsersData))]
		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			home.goToPage();
			LoginPage login = home.goToLoginPage();
			AccountPage result = login.goToAccountPage(user.GetEmail(), user.GetPassword());
			Console.WriteLine("user.GetEmail() = " + user.GetEmail());
			Console.WriteLine("user.GetPassword() = " + user.GetPassword());
			result.clickOnLogout();
		}

		//[TearDown]
		//public void TearDown()
		//{
		//	driver.Close();
		//}
	}
}
