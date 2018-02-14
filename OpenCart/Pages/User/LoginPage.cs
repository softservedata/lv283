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
	public class LoginPage
	{
		protected ISearch Search { get; private set; }
		//		
		public IWebElement EmailField
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
		public IWebElement GetEmailField()
		{
			return EmailField;
		}

		public String GetEmailFieldText()
		{
			return GetEmailField().Text;
		}

		public void ClickEmailField()
		{
			GetEmailField().Click();
		}

		public void ClearEmailAddressField()
		{
			GetEmailField().Clear();
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



	}
}
