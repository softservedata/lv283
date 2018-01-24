//using System;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace OpenCart
//{
//	[TestFixture]
//	public class TestManager
//	{
//		protected IWebElement editButton;
//		protected IWebDriver driver;
//		protected IWebElement actual;
//		protected IWebElement password;
//		protected IWebElement confirm;
//		protected IWebElement editAccountButton;

//		[OneTimeSetUp]
//		public void BeforeAllMethods()
//		{
//			driver = new ChromeDriver();
//			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//			driver.Navigate().GoToUrl("http://283-taqc.ml/");
//		}

//		[OneTimeTearDown]
//		public void AfterAllMethods()
//		{
//			driver.Quit();
//		}

//		public static readonly object[] LoginData =
//		{
//			new object[] { "lion@gmail.com", "qwerty" }
//		};


//		public void CheckLoginUser(string Email, string Password)
//		{
//			//"Login" button
//			driver.FindElement(By.ClassName("caret")).Click();
//			driver.FindElement(By.XPath("//a[contains(@href, '/login')]")).Click();

//			//Fill "Email" field
//			driver.FindElement(By.Id("input-email")).Clear();
//			driver.FindElement(By.Id("input-email")).SendKeys(Email);

//			//Fill "Password" field
//			driver.FindElement(By.Id("input-password")).Clear();
//			driver.FindElement(By.Id("input-password")).SendKeys(Password);
//			driver.FindElement(By.Id("input-password")).Submit();

//		}

//		public void LogoutUser()
//		{
//			//
//			driver.FindElement(By.ClassName("caret")).Click();

//			//
//			driver.FindElement(By.XPath("//a[contains(@href, '/logout')]")).Click();
//		}


//	}
//}
