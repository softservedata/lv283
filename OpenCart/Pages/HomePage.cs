using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Pages
{
	public class HomePage: TestRunner
	{
		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.ClassName, Using = "caret")]
		public IWebElement MyAccount { get; protected set; }

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/login')]")]
		public IWebElement Login { get; protected set; }

		public LoginPage GoToLoginPage()
		{
			MyAccount.Click();
			Login.Click();
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, '/logout')]")));
			return new LoginPage(driver);
		}
	}
}
