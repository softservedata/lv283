using OpenQA.Selenium;

namespace OpenCart.Pages.User
{
	public class PasswordComponent : AColumnRightUserComponent
	{
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

		public IWebElement ChangePasswordLabel
		{ get { return Search.XPath("//a[contains(@href, '/password')]"); } }

		protected PasswordComponent()
		{
			
		}

		// ChangePasswordLabel
		public string GetChangePasswordLabelText()
		{
			return PasswordField.Text;
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

		public void ClickPasswordField()
		{
			PasswordField.Click();
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

		public void ClickConfirmField()
		{
			ConfirmField.Click();
		}

		// DangerText
		public string GetDangerText()
		{
			return DangerText.Text;
		}

		// ChangePassword
		public string GetChangePasswordText()
		{
			return ChangePasswordLabel.Text;
		}

		// BackButton
		public void ClickBackButton()
		{
			BackButton.Click();
		}

		// Continue Button
		public void ClickContinueButton()
		{
			ContinueButton.Click();
		}

		// Set Functional
		private void InputInPasswordField(string passwordField)
		{
			PasswordField.SendKeys(passwordField);
		}

		private void InputInConfirmField(string confirmField)
		{
			ConfirmField.SendKeys(confirmField);
		}

		public void InputPassword(string passwordField)
		{
			ClickPasswordField();
			ClearPasswordField();
			InputInPasswordField(passwordField);
		}

		public void InputConfirm(string confirmField)
		{
			ClickConfirmField();
			ClearConfirmField();
			InputInConfirmField(confirmField);
		}

	}
}
