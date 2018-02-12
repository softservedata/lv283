using OpenQA.Selenium;
using SeleniumTests.Data.Users;


namespace SeleniumTests
{
    public class LoginModule
    {
        private IWebDriver driver;

        public LoginModule(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool Login(IUser user)
        {            
            bool isLogged = false;
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(user.GetEmail());
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(user.GetPassword());
            driver.FindElement(By.CssSelector(".btn.btn-primary:not(a)")).Click();

            if (driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Text == "Logout")
            {
                isLogged = true;
            }

            driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Click();

            return isLogged;
        }

        public bool LoginBlocked(IUser user)
        {
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            for (var i = 0; i < 6; i++)
            {
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(user.GetEmail());
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys(user.GetPassword());
                driver.FindElement(By.CssSelector(".btn.btn-primary:not(a)")).Click();

                if (i < 5)
                {
                    driver.FindElement(By.CssSelector(".alert.alert-danger"));
                }
            }           

            return (driver.FindElement(By.CssSelector(".alert.alert-danger")).Text ==
                "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.");
        }

        public bool Unblock(IUser user)
        {
            string admin = "admin";
            string adminPassword = "lv-283";
            string adminPanelLink = "http://zewer1bp.beget.tech/admin";

            driver.Navigate().GoToUrl(adminPanelLink);
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(admin);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(adminPassword);
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".fa.fa-user.fw")).Click();
            driver.FindElement(By.XPath("//li[@id='menu-customer']/ul/li")).Click();
            driver.FindElement(By.Name("filter_email")).Clear();
            driver.FindElement(By.Name("filter_email")).SendKeys(user.GetEmail());
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector(".fa.fa-unlock")).Click();

            return driver.FindElement(By.ClassName("close")).Displayed;
        }
    }
}
