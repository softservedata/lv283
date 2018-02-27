using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class EditPasswordActions : ColumnRightActions
	{
		public EditPasswordPage EditPasswordPageOperation { get; private set; }

		public EditPasswordActions() : base()
		{
			EditPasswordPageOperation = new EditPasswordPage();
		}
		
		public EditPasswordActions UnsuccessfulChangePassword(Data.Passwords.IPassword invalidPassword)
		{
			EditPasswordPageOperation.ChangePassword(invalidPassword);
			return new EditPasswordActions();
		}

		public EditPasswordActions SuccessfulChangePassword(Data.Passwords.IPassword validPassword)
		{
			EditPasswordPageOperation.ChangePassword(validPassword);
			return new EditPasswordActions();
		}

		public EditPasswordActions UnsuccessfulChangeOnlyPasswordField(Data.Passwords.IPassword invalidPassword)
		{
			EditPasswordPageOperation.ChangeOnlyPasswordField(invalidPassword);
			return new EditPasswordActions();
		}

		public EditPasswordActions SuccessfulChangeOnlyPasswordField(Data.Passwords.IPassword validPassword)
		{
			EditPasswordPageOperation.ChangeOnlyPasswordField(validPassword);
			return new EditPasswordActions();
		}

		public EditPasswordActions UnsuccessfulChangeOnlyConfirmField(Data.Passwords.IPassword invalidPassword)
		{
			EditPasswordPageOperation.ChangeOnlyConfirmField(invalidPassword);
			return new EditPasswordActions();
		}

		public EditPasswordActions SuccessfulChangeOnlConfirmField(Data.Passwords.IPassword validPassword)
		{
			EditPasswordPageOperation.ChangeOnlyConfirmField(validPassword);
			return new EditPasswordActions();
		}

	}
}
