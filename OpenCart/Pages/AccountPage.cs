using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Pages
{
	public class AccountPage:TestRunner
	{
		public AccountPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/password')]")]
		public IWebElement EditPassword { get; protected set; }

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/edit')]")]
		public IWebElement EditAccount { get; protected set; }

		[FindsBy(How = How.ClassName, Using = "caret")]
		public IWebElement MyAccount { get; protected set; }

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/logout')]")]
		public IWebElement Logout { get; protected set; }

		public EditPasswordPage GoToEditPasswordPage()
		{
			EditPassword.Click();
        	return new EditPasswordPage(driver);
		}

		public EditAccountPage GoToEditAccountPage()
		{
			EditAccount.Click();
			return new EditAccountPage(driver);
		}

		public void ClickOnLogout()
		{
			MyAccount.Click();
			Logout.Click();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/login')]")));
		}
	}
}
