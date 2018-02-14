using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;

namespace OpenCart.Pages.User
{
	public class PasswordComponents
	{
		protected ISearch Search { get; private set; }
		//
		public IWebElement PasswordField
		{ get { return Search.Id("input-password"); } }

		public IWebElement ConfirmField
		{ get { return Search.Id("input-confirm"); } }

		public IWebElement DangerText
		{ get { return Search.XPath("//div[@class='text-danger']"); } }

		public IWebElement BackButton
		{ get { return Search.ClassName("pull-left"); } }

		public IWebElement ContinueButton
		{ get { return Search.ClassName("pull-right"); } }

		public IWebElement ChangePassword
		{ get { return Search.XPath("//a[contains(@href, '/password')]"); } }

		protected PasswordComponents()
		{
			this.Search = Application.Get().Search;
		}

		// PasswordField
		public string GetPasswordFieldText()
		{
			return PasswordField.Text;
		}

		public void SubmitPasswordField()
		{
			PasswordField.Submit();
		}

		public void ClearPasswordField()
		{
			PasswordField.Clear();
		}

		// ConfirmField
		public string GetConfirmFieldText()
		{
			return ConfirmField.Text;
		}

		public void SubmitConfirmField()
		{
			ConfirmField.Submit();
		}

		public void ClearConfirmField()
		{
			ConfirmField.Clear();
		}

		// DangerText
		public string GetDangerTextText()
		{
			return DangerText.Text;
		}

		// ChangePassword
		public string GetChangePasswordText()
		{
			return ChangePassword.Text;
		}

		// BackButton
		public void ClickBackButton()
		{
		    BackButton.Click();
		}

		// BackButton
		public void ClickContinueButton()
		{
			ContinueButton.Click();
		}

	}
}
