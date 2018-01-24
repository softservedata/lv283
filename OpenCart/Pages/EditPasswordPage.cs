using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/password')]")]
		private IWebElement passwordButton;

		[FindsBy(How = How.Id, Using = "input-confirm")]
		private IWebElement confirm;

		[FindsBy(How = How.XPath, Using = "//div[@class='text-danger']")]
		private IWebElement actual;

		public void GoToEditPassword()
		{
			passwordButton.Click();
		}


		public void EnterPassword(string passwordField)
		{
			password.Clear();
			password.SendKeys(passwordField);
			password.Submit();
		}

		//public void CheckEnterPassword(string expected)
		public void CheckEnterPassword()
		{
			Assert.True(actual.Text.Trim().Contains("Password must be between 4 and 20 characters!"));
		}

		public void EnterConfirm(string passwordField, string confirmField)
		{
			password.Clear();
			password.SendKeys(passwordField);
			confirm.Clear();
			confirm.SendKeys(confirmField);
			confirm.Submit();
		}

		//public void CheckEnterConfirm(string expected)
		public void CheckEnterConfirm()
		{
			Assert.True(actual.Text.Trim().Contains("Password confirmation does not match password!"));
		}

		public void ChangePassword(string passwordField, string confirmField)
		{
			password.Clear();
			password.SendKeys(passwordField);
			confirm.Clear();
			confirm.SendKeys(confirmField);
			confirm.Submit();
		}

		//public void CheckChangePassword(string expected)
		public void CheckChangePassword()
		{
		    actual = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
			Assert.IsTrue(actual.Text.Contains("Change"));
		}

		public void Logout()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.clickOnLogout();
		}

	}
}
