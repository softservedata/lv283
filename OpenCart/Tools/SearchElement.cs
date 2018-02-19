using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Data;

namespace OpenCart.Tools
{
    public class SearchElement : ISearch
    {
        public ISearch Search { get; private set; }

        public SearchElement(ApplicationSource applicationSource)
        {
            InitSearch(applicationSource);
        }

        private void InitSearch(ApplicationSource applicationSource)
        {
            // Use Factory Method
            this.Search = new SearchImplicit(applicationSource);
        }

        private void SetStrategy(ISearch search)
        {
            // TODO Remove Timeouts
            this.Search = search;
        }

        public IWebElement GetWebElement(By by)
        {
            return Search.GetWebElement(by);
        }

        public IWebElement GetWebElement(By by, IWebElement fromWebElement)
        {
            return Search.GetWebElement(by, fromWebElement);
        }

        public ICollection<IWebElement> GetWebElements(By by)
        {
            return Search.GetWebElements(by);
        }

        public ICollection<IWebElement> GetWebElements(By by, IWebElement fromWebElement)
        {
            return Search.GetWebElements(by, fromWebElement);
        }

        public bool StalenessOf(IWebElement webElement)
        {
            return Search.StalenessOf(webElement);
        }

        // Search Element

        public IWebElement Id(string id)
        {
            return Search.Id(id);
        }

        public IWebElement Name(string name)
        {
            return Search.Name(name);
        }

        public IWebElement XPath(string xpath)
        {
            return Search.XPath(xpath);
        }

        public IWebElement CssSelector(string cssSelector)
        {
            return Search.CssSelector(cssSelector);
        }

        public IWebElement ClassName(string className)
        {
            return Search.ClassName(className);
        }

        public IWebElement PartialLinkText(string partialLinkText)
        {
            return Search.PartialLinkText(partialLinkText);
        }

        public IWebElement LinkText(string linkText)
        {
            return Search.LinkText(linkText);
        }

        public IWebElement TagName(string tagName)
        {
            return Search.TagName(tagName);
        }

        // Search From Element

        public IWebElement Id(string id, IWebElement fromWebElement)
        {
            return Search.Id(id, fromWebElement);
        }

        public IWebElement Name(string name, IWebElement fromWebElement)
        {
            return Search.Name(name, fromWebElement);
        }

        public IWebElement XPath(string xpath, IWebElement fromWebElement)
        {
            return Search.XPath(xpath, fromWebElement);
        }

        public IWebElement CssSelector(string cssSelector, IWebElement fromWebElement)
        {
            return Search.CssSelector(cssSelector, fromWebElement);
        }

        public IWebElement ClassName(string className, IWebElement fromWebElement)
        {
            return Search.ClassName(className, fromWebElement);
        }

        public IWebElement PartialLinkText(string partialLinkText, IWebElement fromWebElement)
        {
            return Search.PartialLinkText(partialLinkText, fromWebElement);
        }

        public IWebElement LinkText(string linkText, IWebElement fromWebElement)
        {
            return Search.LinkText(linkText, fromWebElement);
        }

        public IWebElement TagName(string tagName, IWebElement fromWebElement)
        {
            return Search.TagName(tagName, fromWebElement);
        }

        // Get List

        public ICollection<IWebElement> Names(string name)
        {
            return Search.Names(name);
        }

        public ICollection<IWebElement> XPaths(string xpath)
        {
            return Search.XPaths(xpath);
        }

        public ICollection<IWebElement> XPaths(string xpath, IWebElement fromWebElement)
        {
            return Search.XPaths(xpath, fromWebElement);
        }

        public ICollection<IWebElement> CssSelectors(string cssSelector)
        {
            return Search.CssSelectors(cssSelector);
        }

        public ICollection<IWebElement> ClassNames(string className)
        {
            return Search.ClassNames(className);
        }

        public ICollection<IWebElement> PartialLinkTexts(string partialLinkText)
        {
            return Search.PartialLinkTexts(partialLinkText);
        }

        public ICollection<IWebElement> LinkTexts(string linkText)
        {
            return Search.LinkTexts(linkText);
        }

        public ICollection<IWebElement> TagNames(string tagName)
        {
            return Search.TagNames(tagName);
        }
    }
}
