using OpenCart.Tools;
using OpenQA.Selenium;

namespace OpenCart.Pages.User
{
	public class AccountComponent : AColumnRightUserComponent
	{
		//protected ISearch Search { get; private set; }
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

		public IWebElement ChangeAccountLabel
		{ get { return Search.XPath("//a[contains(@href, '/edit')]"); } }

		public IWebElement SuccessAlert
		{ get { return Search.ClassName("fa fa-check-circle"); } }

		public IWebElement DangerText
		{ get { return Search.XPath("//div[@class='text-danger']"); } }

		protected AccountComponent()
		{
			//this.Search = Application.Get().Search;
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

		// FirstName
		public void ClickFirstNameField()
		{
			GetFirstNameField().Click();
		}

		public void SetFirstNameField(string text)
		{
			GetFirstNameField().SendKeys(text);
		}

		public void ClearFirstNameField()
		{
			GetFirstNameField().Clear();
		}

		public void SubmitFirstNameField()
		{
			FirstNameField.Submit();
		}

	    public string GetFirstNameFieldText()
        {
			return FirstNameField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

		// LastName
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
		public void SubmitLastNameField()
		{
			LastNameField.Submit();
		}

		public string GetLastNameFieldText()
		{
			return LastNameField.GetAttribute(TAG_ATTRIBUTE_VALUE);
		}

		// Email
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
		public void SubmitEmailField()
		{
			EmailField.Submit();
		}
		public string GetEmailFieldText()
		{
			return EmailField.GetAttribute(TAG_ATTRIBUTE_VALUE);
		}

		// Telephone
		public void ClickTelephoneField()
		{
			GetTelephoneField().Click();
		}

		public void SetTelephoneField(string text)
		{
			GetTelephoneField().SendKeys(text);
		}

		public void ClearTelephoneField()
		{
			GetTelephoneField().Clear();
		}
		public void SubmitTelephoneField()
		{
			TelephoneField.Submit();
		}

		public string GetTelephoneFieldText()
		{
			return TelephoneField.GetAttribute(TAG_ATTRIBUTE_VALUE);
		}

		// Fax
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
		public void SubmitFaxField()
		{
			FaxField.Submit();
		}

		public string GetFaxFieldText()
		{
			return FaxField.GetAttribute(TAG_ATTRIBUTE_VALUE);
		}

		// ChangePassword
		public string GetChangeAccountText()
		{
			return ChangeAccountLabel.Text;
		}

		// SuccessAlert
		public string GetSuccessAlertText()
		{
			return SuccessAlert.Text;
		}

		// DangerText
		public string GetDangerText()
		{
			return DangerText.Text;
		}

		// ChangeAccountLabel
		public string GetChangeAccountLabelText()
		{
			return ChangeAccountLabel.Text;
		}

		// Set Functional
		private void InputInFirstNameField(string firstNameField)
		{
			FirstNameField.SendKeys(firstNameField);
		}

		private void InputInLastNameField(string lastNameField)
		{
			LastNameField.SendKeys(lastNameField);
		}

		private void InputInEmailField(string emailField)
		{
			EmailField.SendKeys(emailField);
		}

		private void InputInTelephoneField(string telephoneField)
		{
			TelephoneField.SendKeys(telephoneField);
		}

		private void InputInFaxField(string faxField)
		{
			FaxField.SendKeys(faxField);
		}

		public void InputFirstName(string firstNameField)
		{
			ClickFirstNameField();
			ClearFirstNameField();
			InputInFirstNameField(firstNameField);
		}

		public void InputLastName(string lastNameField)
		{
			ClickLastNameField();
			ClearLastNameField();
			InputInLastNameField(lastNameField);
		}

		public void InputEmail(string emailField)
		{
			ClickEmailField();
			ClearEmailField();
			InputInEmailField(emailField);
		}

		public void InputTelephone(string telephoneField)
		{
			ClickTelephoneField();
			ClearTelephoneField();
			InputInTelephoneField(telephoneField);
		}

		public void InputFax(string faxField)
		{
			ClickFaxField();
			ClearFaxField();
			InputInFaxField(faxField);
		}
	}
}
