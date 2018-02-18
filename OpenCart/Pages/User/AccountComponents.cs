using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Tools;
using OpenQA.Selenium;

namespace OpenCart.Pages.User
{
	public class AccountComponents
	{
		protected ISearch Search { get; private set; }
		//
		public IWebElement FirstNameField
		{ get { return Search.Id("input-firstname"); } }

		public IWebElement LastNameField
		{ get { return Search.Id("input-lastname"); } }

		public IWebElement EmailField
		{ get { return Search.Id("input-email"); } }

		public IWebElement TelephoneField
		{ get { return Search.Id("input-telephone"); } }

		public IWebElement FaxField
		{ get { return Search.Id("input-fax"); } }
		
		public IWebElement BackButton
		{ get { return Search.ClassName("pull-left"); } }

		public IWebElement ContinueButton
		{ get { return Search.ClassName("pull-right"); } }

		protected AccountComponents()
		{
			this.Search = Application.Get().Search;
		}

		public IWebElement GetFirstNameField()
		{
			return FirstNameField;
		}

		public IWebElement GetLastNameField()
		{
			return LastNameField;
		}

		public IWebElement GetEmailField()
		{
			return EmailField;
		}

		public IWebElement GetTelephoneField()
		{
			return TelephoneField;
		}

		public IWebElement GetFaxField()
		{
			return FaxField;
		}

		// set Data

		public void ClickFirstNameField()
		{
			GetFirstNameField().Click();
		}

		public void setFirstNameField(string text)
		{
			GetFirstNameField().SendKeys(text);
		}

		public void ClearFirstNameField()
		{
			GetFirstNameField().Clear();
		}

		public void ClickLastNameField()
		{
			GetLastNameField().Click();
		}

		public void SetLastNameField(string text)
		{
			GetLastNameField().SendKeys(text);
		}

		public void ClearLastNameField()
		{
			GetLastNameField().Clear();
		}

		public void ClickEmailField()
		{
			GetEmailField().Click();
		}

		public void SetEmailField(string text)
		{
			GetEmailField().SendKeys(text);
		}

		public void ClearEmailField()
		{
			GetEmailField().Clear();
		}

		public void ClickTelephoneField()
		{
			GetTelephoneField().Click();
		}

		public void setTelephoneField(string text)
		{
			GetTelephoneField().SendKeys(text);
		}

		public void ClearTelephoneField()
		{
			GetTelephoneField().Clear();
		}

		public void ClickFaxField()
		{
			GetFaxField().Click();
		}

		public void SetFaxField(string text)
		{
			GetFaxField().SendKeys(text);
		}

		public void ClearFaxField()
		{
			GetFaxField().Clear();
		}


	}
}
