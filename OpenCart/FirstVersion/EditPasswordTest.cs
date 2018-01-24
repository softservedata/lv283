//using System;
//using NUnit.Framework;
//using OpenCart.CreateData;
//using OpenQA.Selenium;

//namespace OpenCart
//{
//	[TestFixture, Order(2)]
//	public class EditPasswordTest : TestManager
//	{
//		RandomString randomString = new RandomString();

//		[Test, Order(1), TestCaseSource(nameof(LoginData))]
//		public void LoginUser(string Email, string Password)
//		{
//			//
//			CheckLoginUser(Email, Password);

//			//Check
//			actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
//			Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));
//		}

//		/// <summary>
//		/// +++++++++++++++++++++++ Edit Password +++++++++++++++++++
//		/// <summary>
//		/// 
//		public void EditPassword(int LengthPassword)
//		{
//			//
//			editAccountButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
//			editAccountButton.Click();

//			//Fill "Password" field
//			password = driver.FindElement(By.Id("input-password"));
//			password.Clear();
//			password.SendKeys(randomString.GetRandomString(LengthPassword));
//		}

//		[Test, Order(3)]
//		public void EditPasswordIncorectTest([Range(0, 3)] int LengthPassword)
//		{
//			//
//			EditPassword(LengthPassword);
//			password.Submit();

//			// Check
//			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
//			Console.WriteLine("actual string: " + actual.Text.Trim());
//			Assert.True(actual.Text.Trim().Contains("Password must be between 4 and 20 characters!"));
//		}

//		[Test, Order(4)]
//		public void EditPasswordCorectTest([Range(4, 20)] int LengthPassword)
//		{
//			//
//			EditPassword(LengthPassword);
//			password.Submit();

//			// Check
//			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
//			Console.WriteLine("actual string: " + actual.Text.Trim());
//			Assert.True(actual.Text.Trim().Contains("Password confirmation does not match password!"));
//		}

//		[Test, Order(5)]
//		public void EditPasswordIncorrectTest([Range(21, 23)] int LengthPassword)
//		{
//			//
//			EditPassword(LengthPassword);
//			password.Submit();

//			// Check
//			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
//			Console.WriteLine("actual string: " + actual.Text.Trim());
//			Assert.True(actual.Text.Trim().Contains("Password must be between 4 and 20 characters!"));
//		}

//		public void EditConfirm(int LengthConfirm)
//		{
//			//
//			editAccountButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
//			editAccountButton.Click();

//			//Fill "Password" field
//			password = driver.FindElement(By.Id("input-password"));
//			password.Clear();
//			password.SendKeys("qwerty");

//			//Fill "Confirm" field
//			confirm = driver.FindElement(By.Id("input-confirm"));
//			confirm.Clear();
//			confirm.SendKeys(randomString.GetRandomString(LengthConfirm));
//		}

//		[Test, Order(6)]
//		public void EditConfirmIncorectDataTest([Range(4, 20)] int LengthConfirm)
//		{
//			//
//			EditConfirm(LengthConfirm);
//			confirm.Submit();

//			// Check
//			actual = driver.FindElement(By.XPath("//div[@class='text-danger']"));
//			Console.WriteLine("actual string: " + actual.Text.Trim());
//			Assert.True(actual.Text.Trim().Contains("Password confirmation does not match password!"));
//		}

//		private static readonly object[] PasswordData =
//		{
//			new object[] { "qwer", "qwer"},
//			new object[] { "qwert", "qwert"},
//			new object[] { "111111", "111111"},
//			new object[] { "20172017201720172017", "20172017201720172017"},
//			new object[] { "qwerty", "qwerty"}
//		};

//		[Test, TestCaseSource(nameof(PasswordData)), Order(7)]
//		public void EditConfirmCorectDataTest(string Password, string Confirm)
//		{
//			//"Password" button
//			editButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
//			editButton.Click();

//			//Fill "Password" field
//			password = driver.FindElement(By.Id("input-password"));
//			password.Clear();
//			password.SendKeys(Password);

//			//Fill "Confirm" field
//			confirm = driver.FindElement(By.Id("input-confirm"));
//			confirm.Clear();
//			confirm.SendKeys(Confirm);
//			confirm.Submit();

//			// Check 
//			actual = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
//			Assert.IsTrue(actual.Text.Contains("Change"));

//		}
//	}

//}
