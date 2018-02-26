using OpenQA.Selenium;

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
