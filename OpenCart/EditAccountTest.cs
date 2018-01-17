using System;
using NUnit.Framework;
using OpenCart.CreateData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
    [TestFixture]
    public class EditAccountTest
	{
		IWebElement editButton;
		private IWebDriver driver;
		private IWebElement actual;
		private IWebElement password;
		private IWebElement confirm;

		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Navigate().GoToUrl("http://283-taqc.ml/");
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			driver.Quit();
		}

		[SetUp]
		public void SetUp()
		{

		}

		[TearDown]
		public void TearDown()
		{
			//Console.WriteLine("[TearDown] TearDown()");
		}

		/// <summary>
		/// ++++++++++++++++ LOGIN +++++++++++++
		/// </summary>
		private static readonly object[] LoginData =
		{
			new object[] { "lion@gmail.com", "qwerty" }
		};

		[Test, TestCaseSource(nameof(LoginData))]
		public void CheckLoginUser(string Email, string Password)
		{
			//
			driver.FindElement(By.ClassName("caret")).Click();

			//
			driver.FindElement(By.XPath("//a[contains(@href, '/login')]")).Click();

			//
			driver.FindElement(By.Id("input-email")).SendKeys(Email);

			//
			driver.FindElement(By.Id("input-password")).SendKeys(Password);
			driver.FindElement(By.Id("input-password")).Submit();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/logout')]"));
			Assert.IsTrue(actual.GetAttribute("href").Contains("logout"));

		}

		[Test]
		public void EditAccountCorrectTest([Range(1, 3)] int FirstNameLength, [Range(1, 3)] int LastNameLength, [Range(3, 6)] int TelephoneLength)
		{
			//
			RandomString randomString = new RandomString();

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
			RandomString randomString = new RandomString();
			string email;
			email = randomString.GetRandomString(Log) + "@" + randomString.GetRandomString(Dom) + "." + randomString.GetRandomString(End);

			//
			driver.FindElement(By.XPath("//a[contains(@href, '/edit')]")).Click();

			//
			driver.FindElement(By.Id("input-email")).Clear();
			driver.FindElement(By.Id("input-email")).SendKeys(email);

		}

		[Test]
		public void EditCorrectUserEmail([Range(1, 3)] int Log, [Range(1, 3)] int Dom, [Range(1, 3)] int End)
		{
			//
            EditEmail(Log, Dom, End);
			driver.FindElement(By.Id("input-email")).Submit();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/edit')]"));
			Assert.IsFalse(actual.Text.Contains("Edit Information"));
		}

		[Test]
		public void EditInCorrectUserEmail([Range(33, 35)] int Log, [Range(33, 35)] int Dom, [Range(33, 35)] int End)
		{
			//
			EditEmail(Log, Dom, End);
			driver.FindElement(By.Id("input-email")).Submit();

			// Check
			actual = driver.FindElement(By.XPath("//a[contains(@href, '/edit')]"));
			Assert.IsTrue(actual.Text.Contains("Edit Information"));
		}

		/// +++++++++++++++++++++++ Password +++++++++++++++++++
		/// 
		public void EditPassword(int LengthPassword)
		{
			//
			RandomString randomString = new RandomString();

			//
			IWebElement editAccountButton = driver.FindElement(By.XPath("//a[contains(@href, '/password')]"));
			editAccountButton.Click();

			//
			password = driver.FindElement(By.Id("input-password"));
			password.Clear();
			password.SendKeys(randomString.GetRandomString(LengthPassword));
		}

		[Test]
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

		[Test]
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

		[Test]
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
			RandomString randomString = new RandomString();

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

		[Test]
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

		[Test, TestCaseSource(nameof(PasswordData))]
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
