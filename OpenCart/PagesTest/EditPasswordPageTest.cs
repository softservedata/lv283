using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;
using OpenCart.Data.Users;
using OpenCart.Data.Passwords;
using System.Threading;
using OpenCart.Data.AccountsInfo;

namespace OpenCart.PagesTest
{
	public class EditPasswordPageTest:TestRunner
	{


		public void EditIncorrectPasswordField(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterPassword(password.GetPasswordField());
			//editPasswordPage.CheckEnterPassword();
			//Thread.Sleep(1000);
		}


		public void EditIncorrectConfirmField(Data.Passwords.IPassword password)
		{
			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterConfirm(password.GetPasswordField(), password.GetConfirmField());
			//editPasswordPage.CheckEnterConfirm();
		}

		public void ChangePassword(Data.Passwords.IPassword password)
		{

			EditPasswordPage editPasswordPage = new EditPasswordPage(driver);
			editPasswordPage.GoToEditPassword();
			editPasswordPage.EnterConfirm(password.GetPasswordField(), password.GetConfirmField());
			//editPasswordPage.CheckChangePassword();
		}
	}
}
