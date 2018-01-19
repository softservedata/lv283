using System;
using System.Threading;
using NUnit.Framework;
using OpenCart.CreateData;
using OpenQA.Selenium;

namespace OpenCart
{
    [TestFixture, Order(1)]
    public class EditLoginTest :TestManager
	{

		[Test, Order(1), TestCaseSource(nameof(LoginData))]
		public void LoginUser(string Email, string Password)
		{
			//
			CheckLoginUser(Email, Password);

			//Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));
		}

		[Test, Order(2)]
		public void Logout()
		{
			//
			LogoutUser();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/login')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("login"));
		}
	}
}
