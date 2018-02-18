using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
	public abstract class AColumnRightGuestComponent : AColumnRightPartitionalComponent
	{
		public IWebElement Login
		{ get { return Search.CssSelector("a.list-group-item[href*='login']"); } }
		public IWebElement GetLogin()
		{
			return Login;
		}

		public void ClickLoginRightColumn()
		{
			GetLogin().Click();
		}

		//Actions
		public LoginPage GotoLoginPageRightColumn()
		{
			ClickLoginRightColumn();
			return new LoginPage();
		}
	}
}
