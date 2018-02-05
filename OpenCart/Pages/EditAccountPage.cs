using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OpenCart.Pages
{
	public class EditAccountPage:TestRunner
	{
		public EditAccountPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/edit')]")]
		public IWebElement EditButton { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-firstname")]
		public IWebElement Firstname { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-lastname")]
		public IWebElement Lastname { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-email")]
		public IWebElement Email { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-telephone")]
		public IWebElement Telephone { get; protected set; }

		[FindsBy(How = How.Id, Using = "input-fax")]
		public IWebElement Fax { get; protected set; }

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/edit')]")]
		public IWebElement Actual { get; protected set; }

		public void GoToEditAccount()
		{
			EditButton.Click();
		}

		public void EnterFirstname(string firstnameField)
		{
			Firstname.Clear();
			Firstname.SendKeys(firstnameField);
			///////////
			Firstname.Submit();
		}

		public void EnterLastname(string lastnameField)
		{
			Lastname.Clear();
			Lastname.SendKeys(lastnameField);
			///////////
			Lastname.Submit();
		}

		public void EnterEmail(string emailField)
		{
			Email.Clear();
			Email.SendKeys(emailField);
			///////////
			Email.Submit();
		}

		public void EnterTelephone(string telephoneField)
		{
			Telephone.Clear();
			Telephone.SendKeys(telephoneField);
			///////////
			Telephone.Submit();
		}

		public void EnterFax(string faxField)
		{
			Fax.Clear();
			Fax.SendKeys(faxField);
			///////////
			Fax.Submit();
		}


		public void LogOut()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.ClickOnLogout();
		}

	}
}
