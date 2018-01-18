using System;
using NUnit.Framework;
using OpenCart.CreateData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
	[TestFixture]
	public class LoginTest : TestManager
	{
		public  object[] LoginData =
		{
			new object[] { "lion@gmail.com", "qwerty" }
		};

		//[Test, Order(1), TestCaseSource(nameof(LoginData))]
		
		public void CheckLoginUser(string Email, string Password)
		{
			//
			driver.FindElement(By.ClassName("caret")).Click();

			//
			driver.FindElement(By.XPath("//a[contains(@href, '/login')]")).Click();

			//
			driver.FindElement(By.Id("input-email")).Clear();
			driver.FindElement(By.Id("input-email")).SendKeys(Email);

			//
			driver.FindElement(By.Id("input-password")).Clear();
			driver.FindElement(By.Id("input-password")).SendKeys(Password);
			driver.FindElement(By.Id("input-password")).Submit();


		}

		[Test, Order(1), TestCaseSource(nameof(LoginData))]

		public void CheckUser(string Email, string Password)
		{
			CheckLoginUser(Email, Password);

			//Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));
		}

		[Test, Order(2)]		
		public void LogoutUser()
		{
			//
			driver.FindElement(By.ClassName("caret")).Click();

			//
			driver.FindElement(By.XPath("//a[contains(@href, '/logout')]")).Click();

			//// Check
			//actual = driver.FindElement(By.XPath("//a[contains(@href, '/login')]"));
			//Assert.IsTrue(actual.GetAttribute("href").Contains("login"));
		}
	}
}
