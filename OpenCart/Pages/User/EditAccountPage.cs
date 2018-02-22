using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.AccountsInfo;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
	public class EditAccountPage : AccountComponent
	{
		// Actions
		public void ChangeAccountData(IAccountInfo accountData)
		{
			InputFirstName(accountData.GetFirstname());
			InputLastName(accountData.GetLastname());
			InputEmail(accountData.GetEmail());
			InputTelephone(accountData.GetPhone());
			InputFax(accountData.GetFax());
			SubmitFaxField();
			//ClickContinueButton();
		}

		public void ChangeFirstname(IAccountInfo accountData)
		{
			InputFirstName(accountData.GetFirstname());
			SubmitFirstNameField();
		}

		public void ChangeLastname(IAccountInfo accountData)
		{
			InputLastName(accountData.GetLastname());
			SubmitLastNameField();
		}

		public void ChangeEmail(IAccountInfo accountData)
		{
			InputEmail(accountData.GetEmail());
			SubmitEmailField();
		}

		public void ChangeTelephone(IAccountInfo accountData)
		{
			InputTelephone(accountData.GetPhone());
			SubmitTelephoneField();
		}

		public void ChangeFax(IAccountInfo accountData)
		{
			InputFax(accountData.GetFax());
			SubmitFaxField();
		}
	}
}
