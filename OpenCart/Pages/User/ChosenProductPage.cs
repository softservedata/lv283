using OpenCart.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class ChosenProductPage
    {
        private readonly static string NO_SUCH_ELEMENT_FOUND = "No such element found on this page";
        protected ISearch Search { get; private set; }
        //		
        public IWebElement NameField
        { get { return Search.Id("input-name"); } }
        public IWebElement ReviewField
        { get { return Search.Id("input-review"); } }

        public IWebElement ContinueButton
        { get { return Search.Id("button-review"); } }

        public ICollection<IWebElement> RatingRadioGroup
        { get { return Search.GetWebElements(By.Name("rating")); } }

        public IWebElement AlertMessage
        { get { return Search.CssSelector(".alert"); } }

        public ChosenProductPage()
        {
            this.Search = Application.Get().Search;
        }


        //Tabs
        public ICollection<IWebElement> GetProductTabs()
        {

            return this.Search.CssSelectors(".nav.nav-tabs");
        }

        public void ClickProductTab(string tabName)
        {
            foreach (IWebElement tab in GetProductTabs())
            {
                if (tab.Text.Contains(tabName))
                {
                    tab.Click();
                    break;
                }
            }
        }

        //Review
        //Name
        public string GetNameFieldText()
        {
            return NameField.Text;
        }

        public void ClearNameFieldText()
        {
            NameField.Clear();
        }

        public void SetNameField(string nameValue)
        {
            NameField.SendKeys(nameValue);
        }

        public void ClickNameFieldText()
        {
            NameField.Click();
        }

        //Review
        public string GetReviewFieldText()
        {
            return ReviewField.Text;
        }

        public void ClearReviewFieldText()
        {
            ReviewField.Clear();
        }

        public void SetReviewField(string reviewValue)
        {
            ReviewField.SendKeys(reviewValue);
        }

        public void ClickReviewFieldText()
        {
            ReviewField.Click();
        }

        //Rating

        // TODO How?
        //public string GetRatingFieldText()
        //{
        //    return ReviewField.Text;
        //}



        public void ClickRatingFieldText(int ratingValue)
        {
            Search.CssSelector("input[name=\"rating\"][value =\"3\"]").Click();
        }

        //ContinueButton
        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        //AlertMessage
        public string GetMessage()
        {
            return AlertMessage.Text;
        }
    }
}
