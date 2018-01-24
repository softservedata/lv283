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
using OpenCart.Data.Passwords;

namespace OpenCart
{
	[TestFixture]
	public class EditTests:TestRunner
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
            new object[] { UserRepository.Get().AdminUser() }
		};

		//Parameterize Test
		[Test, TestCaseSource(nameof(UsersData))]
		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			home.goToPage();
			LoginPage login = home.goToLoginPage();
			AccountPage accountPage = login.goToAccountPage(user.GetEmail(), user.GetPassword());
			Console.WriteLine("user.GetEmail() = " + user.GetEmail());
			Console.WriteLine("user.GetPassword() = " + user.GetPassword());
			accountPage.goToEditPasswordPage();
			//accountPage.clickOnLogout();
		}
		//DataProvider
		private static readonly object[] PasswordsData =
		{
            //Use Repository
            //Use Singleton
            new object[] {  PasswordRepository.Get().AdminPassword() }
		};
		[Test, TestCaseSource(nameof(PasswordsData))]
		public void EditPassword(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.EnterPassword(password.GetPasswordField());

			editPasswordPage.EnterConfirm(password.GetConfirmField());

			editPasswordPage.ChangePassword(password.GetPasswordField(), password.GetConfirmField());
			//AccountPage accountPage = login.goToAccountPage(user.GetEmail(), user.GetPassword());
			//Console.WriteLine("user.GetEmail() = " + user.GetEmail());
			//Console.WriteLine("user.GetPassword() = " + user.GetPassword());
			//accountPage.goToEditPasswordPage();
			//accountPage.clickOnLogout();
		}

		//[TearDown]
		//public void TearDown()
		//{
		//	driver.Close();
		//}
	}
}
