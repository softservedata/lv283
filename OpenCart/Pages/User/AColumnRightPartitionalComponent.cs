using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
	public abstract class AColumnRightPartitionalComponent : ANavigatePanelComponent
	{
		public IWebElement MyAccountRigthPanel
		       { get { return Search.CssSelector("a.list-group-item[href*='account/account']"); } }
		public IWebElement MyAddressBookRightPanel
		       { get { return Search.CssSelector("a.list-group-item[href*='address']"); } }
		public IWebElement WishListRigthPanel
		       { get { return Search.CssSelector("a.list-group-item[href*='wishlist']"); } }
		public IWebElement OrderHistory
		       { get { return Search.CssSelector("a.list-group-item[href*='order']"); } }
		public IWebElement Downloads
		       { get { return Search.CssSelector("a.list-group-item[href*='download']"); } }
		public IWebElement RecurringPayments
		       { get { return Search.CssSelector("a.list-group-item[href*='recurring']"); } }
		public IWebElement RewardPoints
		       { get { return Search.CssSelector("a.list-group-item[href*='reward']"); } }
		public IWebElement Returns
		       { get { return Search.CssSelector("a.list-group-item[href*='return']"); } }
		public IWebElement Transactions
		       { get { return Search.CssSelector("a.list-group-item[href*='transaction']"); } }
		public IWebElement Newsletter
		       { get { return Search.CssSelector("a.list-group-item[href*='newsletter']"); } }

		//
		public IWebElement GetAddressBook()
		{
			return MyAddressBookRightPanel;
		}

		public void ClickAddressBook()
		{
			GetAddressBook().Click();
		}

		public IWebElement GetMyAccountRigthPanel()
		{
			return MyAccountRigthPanel;
		}

		public IWebElement GetWishListRigthPanel()
		{
			return WishListRigthPanel;
		}

		public void ClickRigthPanelWishList()
		{
			GetWishListRigthPanel().Click();
		}

		public IWebElement GetOrderHistory()
		{
			return OrderHistory;
		}

		public void ClickOrderHistory()
		{
			GetOrderHistory().Click();
		}

		public IWebElement GetDownloads()
		{
			return Downloads;
		}

		public void ClickDownloads()
		{
			GetDownloads().Click();
		}

		public IWebElement GetRecurringPayments()
		{
			return RecurringPayments;
		}

		public void ClickRecurringPayments()
		{
			GetRecurringPayments().Click();
		}

		public IWebElement GetRewardPoints()
		{
			return RewardPoints;
		}

		public void ClickRewardPoints()
		{
			GetRewardPoints().Click();
		}

		public IWebElement GetReturns()
		{
			return Returns;
		}

		public void ClickReturns()
		{
			GetReturns().Click();
		}

		public IWebElement GetTransactions()
		{
			return Transactions;
		}

		public void ClickTransactions()
		{
			GetTransactions().Click();
		}

		public IWebElement GetNewsletter()
		{
			return Newsletter;
		}

		public void ClickNewsletter()
		{
			GetNewsletter().Click();
		}
		
	}
}
