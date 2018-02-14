﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;

namespace OpenCart.Pages.User
{
    public class ProductComponent
    {
        protected ISearch Search { get; private set; }
        public IWebElement ProductLayout { get; private set; }
        //
        public IWebElement Name
            { get { return Search.CssSelector("h4 a", ProductLayout); } }
        public IWebElement Price
            { get { return Search.CssSelector(".price", ProductLayout); } }
        public IWebElement AddToCart
            { get { return Search.CssSelector(".fa.fa-shopping-cart", ProductLayout); } }
        public IWebElement AddToWish
            { get { return Search.CssSelector(".fa.fa-heart", ProductLayout); } }

        public ProductComponent(IWebElement productLayout)
        {
            this.Search = Application.Get().Search;
            this.ProductLayout = productLayout;
            //
            // Verify Web Elements
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement verify = Name;
            // TODO Check, if Web Elements Exist
        }

        // Name
        public string GetNameText()
        {
            return Name.Text;
        }

        // Price
        public String GetPriceText()
        {
            return Price.Text;
        }

        public double GetPriceAmount()
        {
            //TODO RegexUtils.ExtractDouble(RegexPatterns.NUMBER_DOUBLE.ToString(), GetPriceText());
            return 0;
        }

        public void ClickName()
        {
            Name.Click();
        }

        // AddToCart

        public void ClickAddToCart()
        {
            AddToCart.Click();
        }

        // AddToWish
        public void ClickAddToWish()
        {
            AddToWish.Click();
        }

    }
}
