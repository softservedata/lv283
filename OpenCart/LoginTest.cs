using NUnit.Framework;
using OpenQA.Selenium;

namespace OpenCart
{
	[TestFixture]
	public class LoginTest : TestManager
	{
		//NOT USE
		//public static readonly object[] LoginData =
		//{
		//	new object[] { "lion@gmail.com", "qwerty" }
		//};

		////[Test, Order(1), TestCaseSource(nameof(LoginData))]
		//public void CheckLoginUser(string Email, string Password)
		//{
		//	//
		//	driver.FindElement(By.ClassName("caret")).Click();

		//	//
		//	driver.FindElement(By.XPath("//a[contains(@href, '/login')]")).Click();

		//	//
		//	driver.FindElement(By.Id("input-email")).Clear();
		//	driver.FindElement(By.Id("input-email")).SendKeys(Email);

		//	//
		//	driver.FindElement(By.Id("input-password")).Clear();
		//	driver.FindElement(By.Id("input-password")).SendKeys(Password);
		//	driver.FindElement(By.Id("input-password")).Submit();

		//	//Check
		//	actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
		//	Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));
		//}

		//[Test, Order(2)]
		//public void LogoutUser()
		//{
		//	//
		//	driver.FindElement(By.ClassName("caret")).Click();

		//	//
		//	driver.FindElement(By.XPath("//a[contains(@href, '/logout')]")).Click();
		//}
	}
}
