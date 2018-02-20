using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
	public abstract class AColumnRightUserComponent : AColumnRightPartitionalComponent
	{
		public IWebElement EditAccount
		{ get { return Search.CssSelector("a.list-group-item[href*='edit']"); } }
        public IWebElement AddressBook
        { get { return Search.CssSelector("a.list-group-item[href*='address']"); } }
        public IWebElement Password
		{ get { return Search.CssSelector("a.list-group-item[href*='password']"); } }
		public IWebElement Logout
		{ get { return Search.CssSelector("a.list-group-item[href*='logout']"); } }

		// EditAccount
		public IWebElement GetEditAccount()
		{
			return EditAccount;
		}
		public void ClickEditAccount()
		{
			GetEditAccount().Click();
		}

		// Password
		public IWebElement GetPassword()
		{
			return Password;
		}
		public void ClickPassword()
		{
			GetPassword().Click();
		}

		// Logout
		public IWebElement GetLogout()
		{
			return Logout;
		}

		public void ClickLogoutRightColumn()
		{
			GetLogout().Click();
		}

		// Actions

		public LogoutPage GotoLogoutPageRightColumn()
		{
			ClickLogoutRightColumn();
			return new LogoutPage();
		}
	}
}
