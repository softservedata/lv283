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
			//ClickContinueButton();
		}
	}
}
