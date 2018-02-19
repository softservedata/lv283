using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
	public abstract class AColumnLeftComponent : ANavigatePanelComponent
	{
		public ICollection<IWebElement> LeftCategories { get; private set; }

		public AColumnLeftComponent() : base() { }
	}
}
