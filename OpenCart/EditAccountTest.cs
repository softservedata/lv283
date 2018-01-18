using System;
using NUnit.Framework;
using OpenCart.CreateData;
using OpenQA.Selenium;

namespace OpenCart
{
    [TestFixture]
    public class EditAccountTest :LoginTest
	{
		//RandomString randomString = new RandomString();
		//LoginTest login = new LoginTest();

		//public static readonly object[] LoginData =
  //      {
		//	new object[] { "lion@gmail.com", "qwerty" }
		//};

		[Test, Order(1), TestCaseSource(nameof(LoginData))]
		public void LoginUser(string Email, string Password)
		{


			//CheckLoginUser(Email, Password);
			CheckLoginUser(Email, Password);

			//Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));
		}

		//[Test, Order(2)]
		public void Logout(string Email, string Password)
		{


			LogoutUser();


			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/login')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("login"));
		}
	}
}
