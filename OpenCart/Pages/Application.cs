using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data;
using OpenCart.Actions.User;
using OpenCart.Tools;
using OpenCart.Pages.User;
using OpenCart.Pages.AdminPanel;
using OpenCart.Actions.AdminActions;

namespace OpenCart.Pages
{
    public class Application
    {
        private volatile static Application instance;
        private static object lockingObject = new object();

        // TODO Change for parallel work
        public ApplicationSource ApplicationSource { get; private set; }
        //public FlexAssert FlexAssert { get; private set; }
        public BrowserWrapper Browser { get; private set; }
        public ISearch Search { get; private set; }

        private Application(ApplicationSource applicationSource)
        {
            this.ApplicationSource = applicationSource;
        }

        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSource applicationSource)
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        if (applicationSource == null)
                        {
                            applicationSource = ApplicationSourceRepository.Default();
                        }
                        instance = new Application(applicationSource);
                        //
                        instance.InitBrowser(applicationSource);
                        instance.InitSearch(applicationSource);
                    }
                }
            }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                // TODO Change for parallel work
                instance.Browser.Quit();
                instance = null;
            }
        }

        private void InitBrowser(ApplicationSource applicationSource)
        {
            this.Browser = new BrowserWrapper(applicationSource);
        }

        private void InitSearch(ApplicationSource applicationSource)
        {
            this.Search = new SearchElement(applicationSource);
        }

        public HomeActions LoadHomeActions()
        {
            Browser.OpenUrl(ApplicationSource.BaseUrl);
            return new HomeActions();
        }

        //*********************Admin panel Action*********************//
        public AdminActions LoadAdminActions()
        {
            Browser.OpenUrl(ApplicationSource.AdminLoginUrl);
            return new AdminActions();
        }

        
        //*********************Login Page code*********************//
        
        /*public LoginPage LoadLoginPage()
        {
            Browser.OpenUrl(ApplicationSource.BaseUrl);
            return new LoginPage();
        }*/

        //*********************Admin Panel code*********************//

        /*public AdminLoginPage LoadAdminPage()
        {
            Browser.OpenUrl(ApplicationSource.AdminLoginUrl);
            return new AdminLoginPage();
        }*/
        
        public AdminCustomersPage AcceptPopUp()
        {
            Browser.Driver.SwitchTo().Alert().Accept();
            return new AdminCustomersPage();
        }
        
    }
}
