using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace OpenCart.Pages.User
{
    public class SubCategoryProductsPage : ALeftComponent
    {
        public List<IWebElement> LeftSubCategories { get; private set; }

        // TODO SubCategory Name
        public SubCategoryProductsPage() : base() { }

    }
}
