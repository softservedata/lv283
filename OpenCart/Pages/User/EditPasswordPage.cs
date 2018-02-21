using OpenCart.Data.Passwords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
	public class EditPasswordPage : PasswordComponent
	{
		public void ChangePassword(IPassword password)
		{
			InputPassword(password.GetPasswordField());
			InputConfirm(password.GetConfirmField());
			ClickContinueButton();
		}
	}
}
