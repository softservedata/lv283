using System;
using System.IO;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;


namespace OpenCartTests
{
    [TestFixture]
    public class UnitTest1 : TestRunner
    {
        // new StreamReader(@"F:\Git\OpenCartTests\OpenCartTests\BigReview.txt").ReadToEnd().Insert(100, "This is additional string")
        //Data for tests
      
        private static readonly object[] ReviewData =
        {
            new object[] { "NotAuthorizedCustomer", "This review created by NotAuthorizedUser" },
            new object[] { "UnknownCustomer", "This review is test review" },
            new object[] { "YourNeighbour", "I want to create my own fake shop" }
        };
        //
        private static readonly object[] ReviewBoundariesValid =
        {
            new object[] { "Has excactly 25 characts." },
            //Can't run tasts with a lot of characters or streamreader
            new object[] { new StreamReader(@"*\Review.txt").ReadToEnd().Remove(0,1)},
            new object[] { new StreamReader(@"*\Review.txt").ReadToEnd().Remove(0,2)}
        };
        //
        private static readonly object[] ReviewBoundariesInValid =
        {
            new object[] { "Has excactly 24 characts" },
            new object[] { "Has excactly 21 chars" },
            //Can't run tasts with a lot of characters or streamreader
            new object[] {new StreamReader(@"*\Review.txt").ReadToEnd() },
            new object[] { new StreamReader(@"*\Review.txt").ReadToEnd().Insert(0, "Bonus") } };         
        //
        [Test, TestCaseSource(nameof(ReviewData)), Order(1)]
        public void NotLoggedUserReviewCreation(string customerName, string review)
        {
            //Steps
            //Getting to review tab
            driver.FindElement(By.XPath(@"//a[text()='Components']")).Click();
            driver.FindElement(By.XPath(@"//a[text() = 'Monitors (2)']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'&product_id=42')]")).Click();
            //a[contains(@href,"#tab-review")]
            driver.FindElement(By.XPath("//a[contains(@href,\"#tab-review\")]")).Click();
            //Creating review with non existing user
            driver.FindElement(By.Id("input-name")).SendKeys(customerName);
            driver.FindElement(By.Id("input-review")).SendKeys(review);
            driver.FindElement(By.CssSelector("input[name=\"rating\"][value =\"3\"]")).Click();
            driver.FindElement(By.Id("button-review")).Click();
            //Check
            Assert.IsFalse(driver.FindElement(By.CssSelector(".alert.alert-success")).Enabled);
        }
        //
        [Test, TestCaseSource(nameof(ReviewBoundariesInValid)), Order(3)]
        public void InvalidReviewLengthCheck(string review)
        {

            //Precondition
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("adelyna.emrie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("input-password")).Submit();
            //Steps
            //Getting to review tab
            driver.FindElement(By.XPath(@"//a[text()='Components']")).Click();
            driver.FindElement(By.XPath(@"//a[text() = 'Monitors (2)']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'&product_id=42')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,\"#tab-review\")]")).Click();
            //Creating Review
            driver.FindElement(By.Id("input-review")).SendKeys(review);
            driver.FindElement(By.CssSelector("input[name=\"rating\"][value =\"3\"]")).Click();
            driver.FindElement(By.Id("button-review")).Click();
            //Check
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-danger")).Enabled);
            //Logout
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }
        //
        [Test, TestCaseSource(nameof(ReviewBoundariesValid)), Order (2)]
        public void ValidReviewLengthCheck(string review)
        {
            //Preconditions
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("adelyna.emrie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("input-password")).Submit();
            //Getting to review tab
            driver.FindElement(By.XPath(@"//a[text()='Components']")).Click();
            driver.FindElement(By.XPath(@"//a[text() = 'Monitors (2)']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'&product_id=42')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,\"#tab-review\")]")).Click();
            driver.FindElement(By.Id("input-review")).SendKeys(review);
            driver.FindElement(By.CssSelector("input[name=\"rating\"][value =\"3\"]")).Click();
            driver.FindElement(By.Id("button-review")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Enabled);
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }
       
    }
}