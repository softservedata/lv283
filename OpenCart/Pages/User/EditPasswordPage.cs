using OpenCart.Data.Passwords;

namespace OpenCart.Pages.User
{
	public class EditPasswordPage : PasswordComponent
	{
		
		// Actions
		public void ChangePassword(IPassword password)
		{
			InputPassword(password.GetPasswordField());
			InputConfirm(password.GetConfirmField());
			SubmitConfirmField();
		}

		public void ChangeOnlyPasswordField(IPassword password)
		{
			InputPassword(password.GetPasswordField());
			SubmitPasswordField();
		}

		public void ChangeOnlyConfirmField(IPassword password)
		{
			InputConfirm(password.GetConfirmField());
			SubmitConfirmField();
		}
	}
}
