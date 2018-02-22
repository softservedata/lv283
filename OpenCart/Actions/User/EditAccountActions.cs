using OpenCart.Data.AccountsInfo;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class EditAccountActions : ColumnRightActions
	{
		public EditAccountPage EditAccountPageOperation { get; private set; }

		public EditAccountActions() : base()
		{
			EditAccountPageOperation = new EditAccountPage();
		}

		public EditAccountActions SuccessfulChangeAccount(IAccountInfo validAccountInfo)
		{
			EditAccountPageOperation.ChangeAccountData(validAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions UnsuccessfulChangeAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeAccountData(invalidAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions UnsuccessfulChangeFirstnameFieldAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeFirstname(invalidAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions UnsuccessfulChangeLastnameFieldAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeLastname(invalidAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions UnsuccessfulChangeEmailFieldAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeEmail(invalidAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions UnsuccessfulChangeTelephoneFieldAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeTelephone(invalidAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions UnsuccessfulChangeFaxFieldAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeFax(invalidAccountInfo);
			return new EditAccountActions();
		}
	}
}
