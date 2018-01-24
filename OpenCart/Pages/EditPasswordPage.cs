using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OpenCart.Pages
{
	public class EditPasswordPage:TestRunner
	{
		public EditPasswordPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "input-password")]
		private IWebElement password;

		[FindsBy(How = How.Id, Using = "input-confirm")]
		private IWebElement confirm;

		public void EnterPassword(string passwords)
		{
			password.SendKeys(passwords);
			password.Submit();
		}

		public void EnterConfirm(string confirms)
		{
			confirm.SendKeys(confirms);
			confirm.Submit();
		}

		public void ChangePassword(string passwords, string confirms)
		{
			password.SendKeys(passwords);
			confirm.SendKeys(confirms);
			confirm.Submit();
		}

	}
}
