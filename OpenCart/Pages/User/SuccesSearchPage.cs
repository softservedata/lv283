using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.Pages.User
{
    public class SuccesSearchPage : ANavigatePanelComponent
    {
        public IWebElement KeyWords
        { get { return Search.Id("input-search"); } }

        public IWebElement Category
        { get { return Search.XPath("//select[@name='category_id']"); } }
        public ICollection<IWebElement> Categories
        {
            get
            {
                SelectElement selectList = new SelectElement(Category);
                return selectList.Options;
            }
        }

        public IWebElement SubCategories
        { get { return Search.XPath("//input[@name='sub_category']"); } }

        public IWebElement SearchProductDescription
        { get { return Search.XPath("//input[@name='description']"); } }

        public IWebElement SearchButton
        { get { return Search.Id("button-search"); } }

        public IWebElement MessageNoProduct
        { get { return Search.XPath("//div[@id='content']/p[contains(text(), 'no product')]"); } }


        public SuccesSearchPage() : base()
        {
            InitProductComponents(By.CssSelector(".product-layout"));
        }

        // KeyWords
        public string GetKeyWordsText()
        {
            return KeyWords.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetKeyWordsText(string key)
        {
            KeyWords.SendKeys(key);
        }

        public void ClearKeyWords()
        {
            KeyWords.Clear();
        }

        public void ClickKeyWords()
        {
            KeyWords.Click();
        }

        //Category
        public string GetCategoryText()
        {
            return Category.Text;
        }

        public void ClickCategory()
        {
            Category.Click();
        }

        public void ChooseCategory(string value)
        {
            var selectElement = new SelectElement(Category);
            selectElement.SelectByText(value);
        }

        //SubCategories
        public void ClickSubCategories()
        {
            SubCategories.Click();
        }
        public bool GetIsSelectedSubCategories()
        {
            return SubCategories.Selected;
        }

        //SearchProductDeskription
        public void ClickSearchProductDeskription()
        {
            SearchProductDescription.Click();
        }
        public bool GetIsSelectedSearchProductDeskription()
        {
            return SearchProductDescription.Selected;
        }

        //SearchButton
        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public string GetSearchButtonText()
        {
            return SearchButton.Text;
        }

        //MessegeNoProduct
        public string GetMessegeNoProductText()
        {
            return MessageNoProduct.Text;
        }

        //ProductComponent
        public new List<string> GetProductComponentTexts()
        {
            return base.GetProductComponentTexts();
        }

        public new string GetPriceTextByProductName(string productName)
        {
            return base.GetPriceTextByProductName(productName);
        }

        public new double GetPriceAmountByProductName(string productName)
        {
            return base.GetPriceAmountByProductName(productName);
        }

        public new void ClickAddToCartByProductName(string productName)
        {
            base.ClickAddToCartByProductName(productName);
        }

        public new void ClickAddToWishByProductName(string productName)
        {
            base.ClickAddToWishByProductName(productName);
        }

    }
}
