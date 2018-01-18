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
            new object[] { "Has between 25 and 1000 characters" },
            //Can't run tasts with a lot of characters or streamreader
            new object[] { new StreamReader(@"F:\Git\OpenCartTests\OpenCartTests\BigReview.txt").ReadToEnd().Remove(0,1)}
        };
        //
        private static readonly object[] ReviewBoundariesInValid =
        {
            new object[] { "Has excactly 24 characts" },
            new object[] { "Has excactly 21 chars" },
            //Can't run tasts with a lot of characters or streamreader
            new object[] {new StreamReader(@"F:\Git\OpenCartTests\OpenCartTests\BigReview.txt").ReadToEnd() },
            new object[] { new StreamReader(@"F:\Git\OpenCartTests\OpenCartTests\BigReview.txt").ReadToEnd().Insert(0, "Bonus") } };         
        //
        [Test, TestCaseSource(nameof(ReviewData))]
        public void NotLoggedUserReviewCreation(string customerName, string review)
        {
        
            driver.FindElement(By.XPath(@"//a[text()='Components']")).Click();
            driver.FindElement(By.XPath(@"//a[text() = 'Monitors (2)']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'&product_id=42')]")).Click();
            //a[contains(@href,"#tab-review")]
            driver.FindElement(By.XPath("//a[contains(@href,\"#tab-review\")]")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys(customerName);
            driver.FindElement(By.Id("input-review")).SendKeys(review);
            driver.FindElement(By.CssSelector("input[name=\"rating\"][value =\"3\"]")).Click();
            driver.FindElement(By.Id("button-review")).Click();
            Thread.Sleep(3000);
        }
        //
        [Test, TestCaseSource(nameof(ReviewBoundariesInValid))]
        public void InvalidReviewLengthCheck(string review)
        {

            //Precondition
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("adelyna.emrie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("input-password")).Submit();
            driver.FindElement(By.XPath(@"//a[text()='Components']")).Click();
            driver.FindElement(By.XPath(@"//a[text() = 'Monitors (2)']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'&product_id=42')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,\"#tab-review\")]")).Click();
            driver.FindElement(By.Id("input-review")).SendKeys(review);
            driver.FindElement(By.CssSelector("input[name=\"rating\"][value =\"3\"]")).Click();
            driver.FindElement(By.Id("button-review")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-danger")).Enabled);
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }
        //
        [Test, TestCaseSource(nameof(ReviewBoundariesValid))]
        public void ValidReviewLengthCheck(string review)
        {
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys("adelyna.emrie@arockee.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("input-password")).Submit();
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