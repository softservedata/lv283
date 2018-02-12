using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace OpenCart.Tools
{
    public interface ISearch
    {
        IWebElement GetWebElement(By by);

        IWebElement GetWebElement(By by, IWebElement fromIWebElement);

        List<IWebElement> GetWebElements(By by);

        List<IWebElement> GetWebElements(By by, IWebElement fromIWebElement);

        bool StalenessOf(IWebElement IWebElement);

        // Search Element

        IWebElement Id(string id);

        IWebElement Name(string name);

        IWebElement XPath(string xpath);

        IWebElement CssSelector(string cssSelector);

        IWebElement ClassName(string className);

        IWebElement PartialLinkText(string partialLinkText);

        IWebElement LinkText(string linkText);

        IWebElement TagName(string tagName);

        // Search From Element

        IWebElement Id(string id, IWebElement fromIWebElement);

        IWebElement Name(string name, IWebElement fromIWebElement);

        IWebElement XPath(string xpath, IWebElement fromIWebElement);

        IWebElement CssSelector(string cssSelector, IWebElement fromIWebElement);

        IWebElement ClassName(string className, IWebElement fromIWebElement);

        IWebElement PartialLinkText(string partialLinkText, IWebElement fromIWebElement);

        IWebElement LinkText(string linkText, IWebElement fromIWebElement);

        IWebElement TagName(string tagName, IWebElement fromIWebElement);

        // Get List

        List<IWebElement> Names(string name);

        List<IWebElement> XPaths(string xpath);

        List<IWebElement> XPaths(string xpath, IWebElement fromIWebElement);

        List<IWebElement> CssSelectors(string cssSelector);

        List<IWebElement> ClassNames(string className);

        List<IWebElement> PartialLinkTexts(string partialLinkText);

        List<IWebElement> LinkTexts(string linkText);

        List<IWebElement> TagNames(string tagName);

    }
}
