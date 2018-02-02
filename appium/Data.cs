using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appium
{
    public class Data: TestRunner
    {
        public static readonly object[] copyText =
        {
            new object[] { "io.appium.android.apis:id/copy_styled_text", "io.appium.android.apis:id/styled_text"},
            new object[] { "io.appium.android.apis:id/copy_plain_text", "io.appium.android.apis:id/plain_text" },
            new object[] { "io.appium.android.apis:id/copy_html_text", "io.appium.android.apis:id/html_text" }
        };

    }
}
