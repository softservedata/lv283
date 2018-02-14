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
		private WebElement eMailAddressField;
		private WebElement passwordField;
		private WebElement LoginButton;
		private WebElement warning;

		protected ISearch Search { get; private set; }
		//		
		public IWebElement EmailField
		{ get { return Search.Name("email"); } }

		public IWebElement PasswordField
		{ get { return Search.Name("password"); } }

		public LoginPage()
		{
			this.Search = Application.Get().Search;
		}

		//
		public IWebElement GetEmailField()
		{
			return eMailAddressField;
		}

		public WebElement getPasswordField()
		{
			return passwordField;
		}

		public WebElement getLoginButton()
		{
			return LoginButton;
		}


		public WebElement getWarningText()
		{
			return getWarningText();
		}

		// get Functional
		public String getEmailAddressFieldText()
		{
			return geteMailAddressField().getText();
		}

		public String getPasswordFieldText()
		{
			return getPasswordField().getText();
		}
		// set Data

		public void clickEMailAddressField()
		{
			geteMailAddressField().click();
		}

		public void clickPasswordField()
		{
			getPasswordField().click();
		}

		public void clickLoginButton()
		{
			getLoginButton().click();
		}

		public void clearEMailAddressField()
		{
			geteMailAddressField().clear();
		}

		public void clearPasswordField()
		{
			getPasswordField().clear();
		}

	}
}
