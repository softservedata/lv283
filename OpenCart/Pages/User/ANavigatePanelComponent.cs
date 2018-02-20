using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
	public abstract class ANavigatePanelComponent : HeadPage
	{
		// TODO Init PathElements
		public ICollection<IWebElement> PathElements { get; private set; }

		public ANavigatePanelComponent() : base() { }
	}

}
