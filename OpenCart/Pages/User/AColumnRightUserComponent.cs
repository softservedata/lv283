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
		public IWebElement MyAccountLink
		{ get { return Search.CssSelector("a.list-group-item[href*='account']"); } }
		public IWebElement EditAccountLink
		{ get { return Search.CssSelector("a.list-group-item[href*='edit']"); } }
        public IWebElement AddressBookLink
        { get { return Search.CssSelector("a.list-group-item[href*='address']"); } }
        public IWebElement PasswordLink
		{ get { return Search.CssSelector("a.list-group-item[href*='password']"); } }
		public IWebElement LogoutLink
		{ get { return Search.CssSelector("a.list-group-item[href*='logout']"); } }


		// MyAccountLink
		public string GetMyAccountLinkText()
		{
			return MyAccountLink.Text;
		}

		public void ClickMyAccountLink()
		{
			MyAccountLink.Click();
		}

		// EditAccount
		public IWebElement GetEditAccountLink()
		{
			return EditAccountLink;
		}
		public void ClickEditAccountLink()
		{
			GetEditAccountLink().Click();
		}

		// Password
		public IWebElement GetPasswordLink()
		{
			return PasswordLink;
		}
		public void ClickPasswordLink()
		{
			GetPasswordLink().Click();
		}

		// Logout
		public IWebElement GetLogoutLink()
		{
			return LogoutLink;
		}
		public string GetLogoutTextLink()
		{
			return LogoutLink.Text;
		}

		public void ClickLogoutRightColumnLink()
		{
			GetLogoutLink().Click();
		}

		// Actions

		public LogoutPage GotoLogoutPageRightColumn()
		{
			ClickLogoutRightColumnLink();
			return new LogoutPage();
		}
	}
}
