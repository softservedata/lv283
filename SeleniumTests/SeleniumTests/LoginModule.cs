using OpenQA.Selenium;

namespace SeleniumTests
{
    public class LoginModule
    {
        private IWebDriver driver;

        public LoginModule(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool Login(string email, string password)
        {            
            bool isLogged = false;
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn.btn-primary:not(a)")).Click();

            if (driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Text == "Logout")
            {
                isLogged = true;
            }

            driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Click();

            return isLogged;
        }

        public bool LoginBlocked(string email, string password)
        {
            bool isBlocked = false;
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            for (var i = 0; i < 6; i++)
            {
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.CssSelector(".btn.btn-primary:not(a)")).Click();

                if (i < 5)
                {
                    driver.FindElement(By.CssSelector(".alert.alert-danger"));
                }
            }

            if (driver.FindElement(By.CssSelector(".alert.alert-danger")).Text ==
                "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.")
            {
                isBlocked = true;
            }

            return isBlocked;
        }

        public bool Unblock(string email)
        {
            string admin = "admin";
            string adminPassword = "lv-283";
            string adminPanelLink = "http://zewer.beget.tech/admin";
            bool isNublocked = false;

            driver.Navigate().GoToUrl(adminPanelLink);
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(admin);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(adminPassword);
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".fa.fa-user.fw")).Click();
            driver.FindElement(By.XPath("//li[@id='menu-customer']/ul/li")).Click();
            driver.FindElement(By.Name("filter_email")).Clear();
            driver.FindElement(By.Name("filter_email")).SendKeys(email);
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector(".fa.fa-unlock")).Click();

            if (driver.FindElement(By.ClassName("close")).Displayed)
            {
                isNublocked = true;
            }
            return isNublocked;
        }
    }
}
