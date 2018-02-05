//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenCart.Pages;
//using OpenCart.Data.Users;
//using OpenCart.Data.Passwords;
//using System.Threading;
//using OpenCart.Data.AccountsInfo;

//namespace OpenCart.PagesTest
//{
//	public class EditAccountPageTest:TestRunner
//	{

//		public void ChangeFirsname(IAccountInfo accountInfo)
//		{
//			EditAccountPage editAccountPage = new EditAccountPage(driver);
//			editAccountPage.GoToEditAccount();

//			editAccountPage.EnterFirstname(accountInfo.GetFirstname());
//		//	editAccountPage.CheckEditInvalideInformation();
//		}


//		public void ChangeLastname(IAccountInfo accountInfo)
//		{
//			EditAccountPage editAccountPage = new EditAccountPage(driver);
//			editAccountPage.GoToEditAccount();

//			editAccountPage.EnterLastname(accountInfo.GetLastname());
//			editAccountPage.CheckEditInvalideInformation();
//		}


//		public void ChangeTelephone(IAccountInfo accountInfo)
//		{
//			EditAccountPage editAccountPage = new EditAccountPage(driver);
//			editAccountPage.GoToEditAccount();

//			editAccountPage.EnterTelephone(accountInfo.GetPhone());
//			editAccountPage.CheckEditInvalideInformation();
//			editAccountPage.Logout();
//		}
//	}
//}
