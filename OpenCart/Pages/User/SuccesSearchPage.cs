using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
    public class SuccesSearchPage : ANavigatePanelComponent
    {
        // TODO Add Search Criteria

        public SuccesSearchPage() : base()
        {
            InitProductComponents(By.CssSelector(".product-layout"));
        }

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
            //Console.WriteLine("public new double GetPriceAmountByProductName(string productName) productName = " + productName);
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
