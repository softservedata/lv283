using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Tools
{
    class SearchImplicit : ASearch
    {
        public SearchImplicit()
        {
            InitImplicitWaits();
        }

        private void InitImplicitWaits()
        {
            //Application.get().browser().getDriver().manage().timeouts()
            //        .implicitlyWait(Application.get().getApplicationSource().getImplicitWaitTimeOut(), TimeUnit.SECONDS);
            //Application.get().browser().getDriver().manage().timeouts()
            //        .pageLoadTimeout(Application.get().getApplicationSource().getImplicitLoadTimeOut(), TimeUnit.SECONDS);
            //Application.get().browser().getDriver().manage().timeouts()
            //        .setScriptTimeout(Application.get().getApplicationSource().getImplicitScriptTimeOut(), TimeUnit.SECONDS);
        }

        private void RemoveImplicitWaits()
        {
            //Application.get().browser().getDriver().manage().timeouts().implicitlyWait(0L, TimeUnit.SECONDS);
            //Application.get().browser().getDriver().manage().timeouts().pageLoadTimeout(0L, TimeUnit.SECONDS);
            //Application.get().browser().getDriver().manage().timeouts().setScriptTimeout(0L, TimeUnit.SECONDS);
        }

        public override IWebElement GetWebElement(By by)
        {
            //return Application.get().browser().getDriver().findElement(by);
            return null;
        }

        public override IWebElement GetWebElement(By by, IWebElement fromIWebElement)
        {
            //return fromIWebElement.findElement(by);
            return null;
        }

        public override List<IWebElement> GetWebElements(By by)
        {
            //return Application.get().browser().getDriver().findElements(by);
            return null;
        }

        public override List<IWebElement> GetWebElements(By by, IWebElement fromIWebElement)
        {
            //return fromIWebElement.findElements(by);
            return null;
        }

        public override bool StalenessOf(IWebElement webElement)
        {
            //removeImplicitWaits();
            //new WebDriverWait(Application.get().browser().getDriver(),
            //        Application.get().getApplicationSource().getExplicitTimeOut())
            //                .until(ExpectedConditions.stalenessOf(IWebElement));
            //initImplicitWaits();
            return true;
        }

    }
}
