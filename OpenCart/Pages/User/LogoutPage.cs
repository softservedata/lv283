using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
	public class LogoutPage : RightPage
	{
		public LogoutPage() : base() { }

		public IWebElement ContinueButton
		{ get { return Search.CssSelector(".btn.btn - primary"); } }

		public IWebElement GetContinueButton()
		{
			return ContinueButton;
		}

		public void ClickContinueButton()
		{
			GetContinueButton().Click();
		}

		public HomePage GotoHomePage()
		{
			ClickContinueButton();
			return new HomePage();
		}
	}
}
