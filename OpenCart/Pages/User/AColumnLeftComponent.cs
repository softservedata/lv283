using System.Collections.Generic;
using OpenQA.Selenium;


namespace OpenCart.Pages.User
{
	public abstract class AColumnLeftComponent : ANavigatePanelComponent
	{
		public ICollection<IWebElement> LeftCategories { get; private set; }

		public AColumnLeftComponent() : base() { }
	}
}
