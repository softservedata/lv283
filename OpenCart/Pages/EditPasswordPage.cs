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
		public IWebElement Password { get; protected set; }

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/password')]")]
		public IWebElement PasswordButton { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-confirm")]
		public IWebElement Confirm { get; protected set; }

		[FindsBy(How = How.XPath, Using = "//div[@class='text-danger']")]
		public IWebElement Actual { get; protected set; }

		public void GoToEditPassword()
		{
			PasswordButton.Click();
		}

		public void EnterPassword(string passwordField)
		{
			Password.Clear();
			Password.SendKeys(passwordField);
			Password.Submit();
		}

		public void EnterConfirm(string passwordField, string confirmField)
		{
			Password.Clear();
			Password.SendKeys(passwordField);
			Confirm.Clear();
			Confirm.SendKeys(confirmField);
			Confirm.Submit();
		}

		public void ChangePassword(string passwordField, string confirmField)
		{
			Password.Clear();
			Password.SendKeys(passwordField);
			Confirm.Clear();
			Confirm.SendKeys(confirmField);
			Confirm.Submit();
		}

		public void ChangePassword()
		{
		    Actual = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
		}

		public void Logout()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.ClickOnLogout();
		}

	}
}
