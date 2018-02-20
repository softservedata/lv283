using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Tools;
using OpenQA.Selenium;

namespace OpenCart.Pages.User
{
    public class DeleteAddressBook : AColumnRightUserComponent // TODO
    {
       // protected ISearch Search { get; private set; }

        public IWebElement DeleteFromAddressBookButton
        { get { return Search.XPath("//*[@id='content']//tr[2]/td[2]/a[2]"); } }

        public IWebElement BackButton
        { get { return Search.CssSelector("a.btn.btn-default"); } }

        public void DeleteButtonClick()
        {
            DeleteFromAddressBookButton.Click();
        }

        public void BackButtonClick()
        {
            BackButton.Click();
        }


        //Todo in test`s
        ////Verify
        //IWebElement actual = driver.FindElement(By.CssSelector("div>.alert.alert-success"));
        //Assert.AreEqual("Your address has been successfully deleted", actual.Text);
    }
}
