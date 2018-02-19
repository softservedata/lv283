using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Data.Users;

namespace OpenCart.Pages.User
{
	public class RegisterAccountPage : AColumnRightGuestComponent
	{
		public IWebElement FirstName
		{ get { return Search.CssSelector(""); } }
		public IWebElement Continue
		{ get { return Search.CssSelector(""); } }

		public RegisterAccountPage() : base() { }

		// Business Logic
		public void RegisterUser(IUser user)
		{
			FirstName.SendKeys(user.GetFirstname());
			// TODO ...
			Continue.Click();
		}
	}
}
