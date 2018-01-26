using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.PagesTest
{
	public class LoginPageTest : TestRunner
	{
		public void LoginUser(IUser user)
		{
			HomePage home = new HomePage(driver);
			LoginPage login = home.GoToLoginPage();
			//AccountPage accountPage = login.GoToAccountPage(user);
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/logout')]")));
		}

		public void EditPasswordPage()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.GoToEditPasswordPage();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/password')]")));
		}

		public void EditAccountPage()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.GoToEditAccountPage();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/edit')]")));
		}

		public void LogoutUser()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.ClickOnLogout();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/login')]")));
		}


	}
}
