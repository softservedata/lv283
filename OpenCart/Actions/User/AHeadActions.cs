using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;
using OpenCart.Data.Commons;
using OpenCart.Tools;

namespace OpenCart.Actions.User
{
	public abstract class AHeadActions
	{
		public HeadPage HeadPageOperation { get; private set; }

		public AHeadActions()
		{
			HeadPageOperation = new HeadPage();
		}

		public HomeActions GotoHomeActions()
		{
			HeadPageOperation.GotoHome();
			return new HomeActions();
		}

		public SuccesSearchActions SuccesSearchProduct(string partialProductName)
		{
			HeadPageOperation.SuccesSearchProduct(partialProductName);
			return new SuccesSearchActions();
		}

		public RegisterActions GotoRegisterAccountActions()
		{
			HeadPageOperation.GotoRegister();
			return new RegisterActions();
		}

		public LoginActions GotoLoginAccountActions()
		{
			HeadPageOperation.GotoLogin();
			return new LoginActions();
		}

		public MyAccountActions GotoMyAccountActions()
		{
			HeadPageOperation.GotoMyAccount();
			return new MyAccountActions();
		}

		public LogoutActions GotoLogoutAccountActions()
		{
			HeadPageOperation.GotoLogout();
			return new LogoutActions();
		}

		public AHeadActions ChooseMenuTopByCategoryPartialName(string categoryName)
		{
			HeadPageOperation.ClickMenuTopByCategoryPartialName(categoryName);
			//return new HeadActions();
			return this;
		}

		public List<string> GetAllSubMenuTopByCategoryName(string categoryName)
		{
			return HeadPageOperation.GetSubMenuTopByPartialName(categoryName);
		}

		public List<ElementItem> GetAllElementItemsByCategoryName(string categoryName)
		{
			List<ElementItem> result = new List<ElementItem>();
			foreach (string current in GetAllSubMenuTopByCategoryName(categoryName))
			{
				result.Add(new ElementItem(RegexUtils.ExtractFirstString(current).Trim(),
				   RegexUtils.ExtractFirstNumber(current)));
			}
			return result;
		}

	}
}
