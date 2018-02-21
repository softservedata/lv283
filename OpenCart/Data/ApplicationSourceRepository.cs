using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data
{
    public sealed class ApplicationSourceRepository
    {
        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return ChromeEpizy();
        }

        public static ApplicationSource FirefoxEpizy()
        {
            return new ApplicationSource("FirefoxTemporary", 10L,
                "http://zewer1bp.beget.tech",
                "http://zewer1bp.beget.tech/index.php?route=account/logout",
                "http://zewer1bp.beget.tech/admin/");
        }

        public static ApplicationSource ChromeEpizy()
        {
            return new ApplicationSource("ChromeTemporary", 10L,
                "http://zewer1bp.beget.tech",
                "http://zewer1bp.beget.tech/index.php?route=account/logout",
                "http://zewer1bp.beget.tech/admin/");
        }

        public static ApplicationSource ChromeWithoutUIEpizy()
        {
            return new ApplicationSource("ChromeWithoutUI", 10L,
                "http://zewer1bp.beget.tech",
                "http://zewer1bp.beget.tech/index.php?route=account/logout",
                "http://zewer1bp.beget.tech/admin/");
        }

    }
}
