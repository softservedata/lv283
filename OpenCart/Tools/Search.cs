using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace OpenCart.Tools
{
    public class Search
    {
        private ISearch search;

        //public Search(IApplicationSource applicationSource)
        //{
        //    initSearch(applicationSource);
        //}

        public Search()
        {
            search = new SearchImplicit();
        }

        private ISearch GetSearch()
        {
            return search;
        }

        private void SetStrategy(ISearch search)
        {
            this.search = search;
        }

        public IWebElement GetWebElement(By by)
        {
            return GetSearch().GetWebElement(by);
        }

        public IWebElement GetWebElement(By by, IWebElement fromWebElement)
        {
            return GetSearch().GetWebElement(by, fromWebElement);
        }

        public List<IWebElement> GetWebElements(By by)
        {
            return GetSearch().GetWebElements(by);
        }

        public List<IWebElement> GetWebElements(By by, IWebElement fromWebElement)
        {
            return GetSearch().GetWebElements(by, fromWebElement);
        }

        public bool StalenessOf(IWebElement webElement)
        {
            return GetSearch().StalenessOf(webElement);
        }

        // Search Element

        public IWebElement Id(string id)
        {
            return GetSearch().Id(id);
        }

        public IWebElement Name(string name)
        {
            return GetSearch().Name(name);
        }

        public IWebElement XPath(string xpath)
        {
            return GetSearch().XPath(xpath);
        }

        public IWebElement CssSelector(string cssSelector)
        {
            return GetSearch().CssSelector(cssSelector);
        }

        public IWebElement ClassName(string className)
        {
            return GetSearch().ClassName(className);
        }

        public IWebElement PartialLinkText(string partialLinkText)
        {
            return GetSearch().PartialLinkText(partialLinkText);
        }

        public IWebElement LinkText(string linkText)
        {
            return GetSearch().LinkText(linkText);
        }

        public IWebElement TagName(string tagName)
        {
            return GetSearch().TagName(tagName);
        }

        // Search From Element

        public IWebElement Id(string id, IWebElement fromWebElement)
        {
            return GetSearch().Id(id, fromWebElement);
        }

        public IWebElement Name(string name, IWebElement fromWebElement)
        {
            return GetSearch().Name(name, fromWebElement);
        }

        public IWebElement XPath(string xpath, IWebElement fromWebElement)
        {
            return GetSearch().XPath(xpath, fromWebElement);
        }

        public IWebElement CssSelector(string cssSelector, IWebElement fromWebElement)
        {
            return GetSearch().CssSelector(cssSelector, fromWebElement);
        }

        public IWebElement ClassName(string className, IWebElement fromWebElement)
        {
            return GetSearch().ClassName(className, fromWebElement);
        }

        public IWebElement PartialLinkText(string partialLinkText, IWebElement fromWebElement)
        {
            return GetSearch().PartialLinkText(partialLinkText, fromWebElement);
        }

        public IWebElement LinkText(string linkText, IWebElement fromWebElement)
        {
            return GetSearch().LinkText(linkText, fromWebElement);
        }

        public IWebElement TagName(string tagName, IWebElement fromWebElement)
        {
            return GetSearch().TagName(tagName, fromWebElement);
        }

        // Get List

        public List<IWebElement> Names(string name)
        {
            return GetSearch().Names(name);
        }

        public List<IWebElement> XPaths(string xpath)
        {
            return GetSearch().XPaths(xpath);
        }

        public List<IWebElement> XPaths(string xpath, IWebElement fromWebElement)
        {
            return GetSearch().XPaths(xpath, fromWebElement);
        }

        public List<IWebElement> CssSelectors(string cssSelector)
        {
            return GetSearch().CssSelectors(cssSelector);
        }

        public List<IWebElement> ClassNames(string className)
        {
            return GetSearch().ClassNames(className);
        }

        public List<IWebElement> PartialLinkTexts(string partialLinkText)
        {
            return GetSearch().PartialLinkTexts(partialLinkText);
        }

        public List<IWebElement> LinkTexts(string linkText)
        {
            return GetSearch().LinkTexts(linkText);
        }

        public List<IWebElement> TagNames(string tagName)
        {
            return GetSearch().TagNames(tagName);
        }
    }
}
