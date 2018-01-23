using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Pages
{
	public class LoginPage : TestRunner
	{
		//private IWebDriver driver;
		//private WebDriverWait wait;

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "input-email")]
		private IWebElement email;

		[FindsBy(How = How.Id, Using = "input-password")]
		private IWebElement password;
		
		public AccountPage goToAccountPage(string emails, string passwords)
		{

			email.SendKeys(emails);
			password.SendKeys(passwords);
			password.Submit();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/logout')]")));
			return new AccountPage(driver);
		}
	}
}
