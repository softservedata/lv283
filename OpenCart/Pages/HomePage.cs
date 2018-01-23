using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OpenCart.Pages
{
	public class HomePage:TestRunner
	{
		//private IWebDriver driver;

		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.ClassName, Using = "caret")]
		private IWebElement myAccount;

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/login')]")]
		private IWebElement login;

		public void goToPage()
		{
			driver.Navigate().GoToUrl("http://283-taqc.ml/");
		}

		public LoginPage goToLoginPage()
		{
			myAccount.Click();
			login.Click();
			return new LoginPage(driver);
		}
	}
}
