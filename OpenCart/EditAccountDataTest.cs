using System;
using NUnit.Framework;
using OpenCart.CreateData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
	[TestFixture]
	class EditAccountDataTest : TestManager
	{
		RandomString randomString = new RandomString();

		public static readonly object[] LoginData =
		{
			new object[] { "lion@gmail.com", "qwerty" }
		};

		[Test, Order(1), TestCaseSource(nameof(LoginData))]

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

			//Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));
		}

		[Test, Order(3)]
		public void EditAccountCorrectTest([Range(1, 3)] int FirstNameLength, [Range(1, 3)] int LastNameLength, [Range(3, 6)] int TelephoneLength)
		{

			//
			driver.FindElement(By.XPath("//a[contains(@href, '/edit')]")).Click();

			//
			driver.FindElement(By.Id("input-firstname")).Clear();
			driver.FindElement(By.Id("input-firstname")).SendKeys(randomString.GetRandomString(FirstNameLength));

			//
			driver.FindElement(By.Id("input-lastname")).Clear();
			driver.FindElement(By.Id("input-lastname")).SendKeys(randomString.GetRandomString(LastNameLength));

			//
			driver.FindElement(By.Id("input-telephone")).Clear();
			driver.FindElement(By.Id("input-telephone")).SendKeys(randomString.GetRandomString(TelephoneLength));
			driver.FindElement(By.Id("input-lastname")).Submit();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/edit')]"));
			Assert.IsFalse(actual.Text.Contains("Edit Information"));
		}



		private static readonly object[] EditData =
		{
			new object[] {"lion@gmail.com"}
		};

		public void EditEmail(int Log, int Dom, int End)
		{
			//
			string email;
			email = randomString.GetRandomString(Log) + "@" + randomString.GetRandomString(Dom) + "." + randomString.GetRandomString(End);

			//
			driver.FindElement(By.XPath("//a[contains(@href, '/edit')]")).Click();

			//
			driver.FindElement(By.Id("input-email")).Clear();
			driver.FindElement(By.Id("input-email")).SendKeys(email);

		}

		[Test, Order(4)]
		public void EditCorrectUserEmail([Range(1, 3)] int Log, [Range(1, 3)] int Dom, [Range(1, 3)] int End)
		{
			//
			EditEmail(Log, Dom, End);
			driver.FindElement(By.Id("input-email")).Submit();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/edit')]"));
			Assert.IsFalse(actual.Text.Contains("Edit Information"));
		}

		[Test, Order(5)]
		public void EditInCorrectUserEmail([Range(33, 35)] int Log, [Range(33, 35)] int Dom, [Range(33, 35)] int End)
		{
			//
			EditEmail(Log, Dom, End);
			driver.FindElement(By.Id("input-email")).Submit();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/edit')]"));
			Assert.IsTrue(actual.Text.Contains("Edit Information"));
		}
	}
}
