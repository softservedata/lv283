using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Commons;
using OpenCart.Pages.User;
using OpenCart.Tools;

namespace OpenCart.Actions.User
{
    public abstract class HeadActions
    {
        public HeadPage HeadPageOperation { get; private set; }

        public HeadActions()
        {
            HeadPageOperation = new HeadPage();
        }

        public HomeActions GotoHomeActions()
        {
            HeadPageOperation.GotoHome();
            return new HomeActions();
        }

        public SuccessSearchActions SuccessSearchProduct(string partialProductName)
        {
            HeadPageOperation.SuccesSearchProduct(partialProductName);
            return new SuccessSearchActions();
        }

        public RegisterAccountActions GotoRegisterAccountActions()
        {
            HeadPageOperation.GotoRegister();
            return new RegisterAccountActions();
        }

        public LoginAccountActions GotoLoginAccountActions()
        {
            HeadPageOperation.GotoLogin();
            return new LoginAccountActions();
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

        public HeadActions ChooseMenuTopByCategoryPartialName(string categoryName)
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
                result.Add(new ElementItem(RegexUtils.ExtractFirstString(current),
                    RegexUtils.ExtractFirstNumber(current)));
            }
            return result;
        }

    }
}
