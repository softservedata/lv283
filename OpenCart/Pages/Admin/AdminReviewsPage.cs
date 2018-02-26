using OpenCart.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.Admin
{
    class AdminReviewsPage
    {
        private readonly string DATE_FORMAT = "{0}-{1}-{2}";
        private ISearch Search;

        public IWebElement Product
        { get { return Search.Id("input-product"); } }

        public IWebElement Author
        { get { return Search.Id("input-author"); } }

        public IWebElement Status
        { get { return Search.Id("input-status"); } }

        public IWebElement DateAdded
        { get {return Search.ClassName("input-group.date"); } }

        public IWebElement FilterButton
        { get { return Search.Id("button-filter"); } }


        //DateAdded
        public void ClearDateAdded()
        {
            DateAdded.Clear();
        }

        public void SetDateAdded(DateTime date)
        {
            DateAdded.SendKeys(String.Format(DATE_FORMAT,date.Year.ToString(), date.Month.ToString(), date.Day.ToString()));
        }


        //FilterButton
        public void ClickFilterButton()
        {
            FilterButton.Click();
        }

        public IWebElement FindTableFirstRow()
        {
            return Search.XPath("//tbody/tr[text()]");
        }
    }
}
