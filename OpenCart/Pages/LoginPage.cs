using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenCart.Data.Users;

namespace OpenCart.Pages
{
	public class LoginPage : TestRunner
	{
		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "input-email")]
		public IWebElement Email { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-password")]
		public IWebElement Password { get; protected set; }

		public AccountPage GoToAccountPage(string email, string password)
		{
			Email.SendKeys(email);
			Password.SendKeys(password);
			Password.Submit();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/logout')]")));
			return new AccountPage(driver);
		}
	}
}
