using System;
using NUnit.Framework;
using OpenCart.CreateData;
using OpenQA.Selenium;

namespace OpenCart
{
	[TestFixture, Order(2)]
	public class EditPasswordTest : TestManager
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

		/// <summary>
		/// +++++++++++++++++++++++ Edit Password +++++++++++++++++++
		/// <summary>
		public void EditPassword(int LengthPassword)
		{
			//
			IWebElement editAccountButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
			editAccountButton.Click();

			//
			password = driver.FindElement(By.Id("input-password"));
			password.Clear();
			password.SendKeys(randomString.GetRandomString(LengthPassword));
		}

		[Test, Order(3)]
		public void EditPasswordIncorectTest([Range(0, 3)] int LengthPassword)
		{
			//
			EditPassword(LengthPassword);
			password.Submit();

			// Check
			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
			Console.WriteLine("actual string: " + actual.Text.Trim());
			Assert.True(actual.Text.Trim().Contains("Password must be between 4 and 20 characters!"));
		}

		[Test, Order(4)]
		public void EditPasswordCorectTest([Range(4, 20)] int LengthPassword)
		{
			//
			EditPassword(LengthPassword);
			password.Submit();

			// Check
			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
			Console.WriteLine("actual string: " + actual.Text.Trim());
			Assert.True(actual.Text.Trim().Contains("Password confirmation does not match password!"));
		}

		[Test, Order(5)]
		public void EditPasswordIncorrectTest([Range(21, 23)] int LengthPassword)
		{
			//
			EditPassword(LengthPassword);

			password.Submit();
			// Check
			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
			Console.WriteLine("actual string: " + actual.Text.Trim());
			Assert.True(actual.Text.Trim().Contains("Password must be between 4 and 20 characters!"));
		}

		public void EditConfirm(int LengthConfirm)
		{
			//
			IWebElement editAccountButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
			editAccountButton.Click();

			//
			password = driver.FindElement(By.Id("input-password"));
			password.Clear();
			password.SendKeys("qwerty");

			//
			confirm = driver.FindElement(By.Id("input-confirm"));
			confirm.Clear();
			confirm.SendKeys(randomString.GetRandomString(LengthConfirm));
			//Thread.Sleep(1000);
		}

		[Test, Order(6)]
		public void EditConfirmIncorectDataTest([Range(4, 20)] int LengthConfirm)
		{
			//
			EditConfirm(LengthConfirm);
			confirm.Submit();

			// Check
			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
			Console.WriteLine("actual string: " + actual.Text.Trim());
			Assert.True(actual.Text.Trim().Contains("Password confirmation does not match password!"));
		}

		private static readonly object[] PasswordData =
		{
			new object[] { "qwer", "qwer"},
			new object[] { "qwert", "qwert"},
			new object[] { "111111", "111111"},
			new object[] { "20172017201720172017", "20172017201720172017"},
			new object[] { "qwerty", "qwerty"}
		};

		[Test, TestCaseSource(nameof(PasswordData)), Order(7)]
		public void EditConfirmCorectDataTest(string Password, string Confirm)
		{
			//
			editButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
			editButton.Click();

			//
			password = driver.FindElement(By.Id("input-password"));
			password.Clear();
			password.SendKeys(Password);

			//
			confirm = driver.FindElement(By.Id("input-confirm"));
			confirm.Clear();
			confirm.SendKeys(Confirm);
			confirm.Submit();

			// Check 
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
			Assert.IsTrue(actual.Text.Contains("Change"));

		}
	}
}
