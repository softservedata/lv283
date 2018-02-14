﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;
using OpenCart.Data.Users;

namespace OpenCart.Pages.User
{
	public class LoginPage
	{
		public const string  EXPECTED_FIRST_WARNING = "Warning: No match for E-Mail Address and/or Password.";
		public const string EXPECTED_SECOND_WARNING = "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.";


		protected ISearch Search { get; private set; }
		//		
		public IWebElement EmailAdressField
		{ get { return Search.Name("email"); } }

		public IWebElement PasswordField
		{ get { return Search.Name("password"); } }

		public IWebElement LoginButton
		{ get { return Search.XPath("//*[@value='Login'] [@class='btn btn-primary']"); } }

		public LoginPage()
		{
			this.Search = Application.Get().Search;
		}

		//
		public IWebElement GetEmailAdressField()
		{
			return EmailAdressField;
		}

		public String GetEmailAdressFieldText()
		{
			return GetEmailAdressField().Text;
		}

		public void ClickEmailAdressField()
		{
			GetEmailAdressField().Click();
		}

		public void ClearEmailAddressField()
		{
			GetEmailAdressField().Clear();
		}

		public IWebElement GetPasswordField()
		{
			return PasswordField;
		}

		public String GetPasswordFieldText()
		{
			return GetPasswordField().Text;
		}

		public void ClickPasswordField()
		{
			GetPasswordField().Click();
		}

		public void ClearPasswordField()
		{
			GetPasswordField().Clear();
		}

		public IWebElement GetLoginButton()
		{
			return LoginButton;
		}
		
		public IWebElement GetWarningText()
		{
			return GetWarningText();
		}

		public void ClickLoginButton()
		{
			GetLoginButton().Click();
		}

		// set Functional
		private void InputInEmailAdressField(string emailAddress)
		{
			GetEmailAdressField().SendKeys(emailAddress);
		}

		private void inputInPasswordField(string passwordField)
		{
			GetPasswordField().SendKeys(passwordField);
		}

		public void InputEmailAdress(string emailAddress)
		{
			ClickEmailAdressField();
			ClearEmailAddressField();
			InputInEmailAdressField(emailAddress);
		}

		public void InputPassword(string passwordField)
		{
			ClickPasswordField();
			ClearPasswordField();
			inputInPasswordField(passwordField);
		}
		
		public void LoginForLoginPageToMyAccountPage(string email, string password)
		{
			InputEmailAdress(email);
			InputPassword(password);
			ClickLoginButton();
		}

		public void LoginForLoginPageToWarning(string email, string wrongPassword)
		{
			InputEmailAdress(email);
			InputPassword(wrongPassword);
			ClickLoginButton();
		}
		//Actions
		public MyAccountPage GoToLoginForLoginPageToMyAccountPage(IUser user)
		{
			LoginForLoginPageToMyAccountPage(user.GetEmail(), user.GetPassword());
			return new MyAccountPage();
		}

		public LoginPage GoToLoginForLoginPageToWarning(IUser user)
		{
			LoginForLoginPageToWarning(user.GetEmail(), user.GetPassword());
			return new LoginPage();
		}
	}
}
