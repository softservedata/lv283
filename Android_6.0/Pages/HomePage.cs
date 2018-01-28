using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace Android_6._0.Pages
{
	public class HomePage: TestRunner
	{
		public HomePage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "Views")]
		public IWebElement Views { get; protected set; }

		public ViewsPage GoToViewsPage()
		{
			Views.Click();
			return new ViewsPage(driver);
		}

	}
}
