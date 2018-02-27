using OpenQA.Selenium;
using OpenCart.Data.Users;

namespace OpenCart.Pages.AdminPanel
{
    public class AdminCustomersPage : AdminDropDownColumn
    {
        protected IWebElement SearchEmail
        { get { return Search.Name("filter_email"); } }

        protected IWebElement Filter
        { get { return Search.Id("button-filter"); } }

        protected IWebElement Unlock
        { get { return Search.CssSelector(".fa.fa-unlock"); } }

        protected IWebElement SelectAllMark
        { get { return Search.ClassName("text-center"); } }

        protected IWebElement Delete
        { get { return Search.CssSelector(".btn.btn-danger"); } }

        protected IWebElement Close
        { get { return Search.ClassName("close"); } }

        public AdminCustomersPage() : base()
        {
        }

        public bool IsCloseDisplayed()
        {
            return Close.Displayed;
        }

        //SearchEmail Field
        public void ClearSearchEmail()
        {
            SearchEmail.Clear();
        }

        public void SendKeysToEmail(string email)
        {
            SearchEmail.SendKeys(email);
        }

        //Filter Button
        public void ClickFilter()
        {
            Filter.Click();
        }

        //Unlock Button
        public void ClickUnlock()
        {
            Unlock.Click();
        }

        //Text Center
        public void ClickSelectAllMark()
        {
            SelectAllMark.Click();
        }

        //Delete Button
        public void ClickDelete()
        {
            Delete.Click();
        }

        //Close Button
        public void ClickClose()
        {
            Close.Click();
        }

        public void GetUnlockCustomer(IUser user)
        {
            ClearSearchEmail();
            SendKeysToEmail(user.GetEmail());
            ClickFilter();
            ClickUnlock();
        }

        public void GetDeletedCustomer(IUser user)
        {
            ClearSearchEmail();
            SendKeysToEmail(user.GetEmail());
            ClickFilter();
            ClickSelectAllMark();
            ClickDelete();
            GetAcceptPopUp();
        }

        //Accept pop up from browser
        public void GetAcceptPopUp()
        {
            AdminCustomersPage adminLoginPage = Application.Get().AcceptPopUp();
        }
    }
}
