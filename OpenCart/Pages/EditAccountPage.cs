using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		private IWebElement editButton;

		[FindsBy(How = How.Id, Using = "input-firstname")]
		private IWebElement firstname;

		[FindsBy(How = How.Id, Using = "input-lastname")]
		private IWebElement lastname;

		[FindsBy(How = How.Id, Using = "input-email")]
		private IWebElement email;

		[FindsBy(How = How.Id, Using = "input-telephone")]
		private IWebElement telephone;

		[FindsBy(How = How.Id, Using = "input-fax")]
		private IWebElement fax;

		[FindsBy(How = How.XPath, Using = "//a[contains(@href, '/edit')]")]
		private IWebElement actual;


		public void GoToEditAccount()
		{
			editButton.Click();
		}

		public void EnterFirstname(string firstnameField)
		{
			firstname.Clear();
			firstname.SendKeys(firstnameField);
			///////////
			firstname.Submit();
		}

		public void EnterLastname(string lastnameField)
		{
			lastname.Clear();
			lastname.SendKeys(lastnameField);
			///////////
			lastname.Submit();
		}

		public void EnterEmail(string emailField)
		{
			email.Clear();
			email.SendKeys(emailField);
			///////////
		}

		public void EnterTelephone(string telephoneField)
		{
			telephone.Clear();
			telephone.SendKeys(telephoneField);
			///////////
			telephone.Submit();
		}

		public void EnterFax(string faxField)
		{
			fax.Clear();
			fax.SendKeys(faxField);
			///////////
			fax.Submit();
		}

		public void CheckEditInvalideInformation()
		{
			Assert.IsTrue(actual.Text.Contains("Edit Information"));
		}

		public void CheckEditValideInformation()
		{
			Assert.IsFalse(actual.Text.Contains("Edit Information"));
		}

		public void Logout()
		{
			AccountPage accountPage = new AccountPage(driver);
			accountPage.clickOnLogout();
		}

	}
}
