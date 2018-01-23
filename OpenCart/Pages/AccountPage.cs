using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OpenCart.Pages
{
	public class AccountPage:TestRunner
	{
		//private IWebDriver driver;

		public AccountPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.ClassName, Using = "caret")]
		private IWebElement myAccount;

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/logout')]")]
		private IWebElement logout;

		public void clickOnLogout()
		{
			myAccount.Click();
			logout.Click();
		}
	}
}
