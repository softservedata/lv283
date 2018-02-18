using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
	public class ANavigatePanelComponent : AHeadComponent
	{
		// TODO Init PathElements
		public ICollection<IWebElement> PathElements { get; private set; }

		public ANavigatePanelComponent() : base() { }
	}

}
