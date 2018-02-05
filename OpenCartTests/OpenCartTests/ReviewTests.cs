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
            new object[] { new StreamReader(@"C:\Users\Max\source\repos\lv283\OpenCartTests\OpenCartTests\Review.txt").ReadToEnd().Remove(0,1)},
            new object[] { new StreamReader(@"C:\Users\Max\source\repos\lv283\OpenCartTests\OpenCartTests\Review.txt").ReadToEnd().Remove(0,2)}
        };
        //
        private static readonly object[] ReviewBoundariesInValid =
        {
            new object[] { "Has excactly 24 characts" },
            new object[] { "Has excactly 21 chars" },
            //Can't run tasts with a lot of characters or streamreader
            new object[] {new StreamReader(@"C:\Users\Max\source\repos\lv283\OpenCartTests\OpenCartTests\Review.txt").ReadToEnd() },
            new object[] { new StreamReader(@"C:\Users\Max\source\repos\lv283\OpenCartTests\OpenCartTests\Review.txt").ReadToEnd().Insert(0, "Bonus") } };         
        //
        [Test, TestCaseSource(nameof(ReviewData))]
        public void NotLoggedUserReviewCreation(string customerName, string review)
        {
            //Steps
            MoveToReviewTab();
            //Creating Review            
            driver.FindElement(By.Id("input-name")).SendKeys(customerName);
            CreateReview(review);
            //Check
            Assert.IsFalse(driver.FindElement(By.CssSelector(".alert.alert-success")).Enabled);
        }
        //
        [Test, TestCaseSource(nameof(ReviewBoundariesInValid))]
        public void InvalidReviewLengthCheck(string review)
        {

            Preconditions();
            //Steps
            //Getting to review tab
            MoveToReviewTab();
            //Creating Review
            CreateReview(review);
            //Check
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-danger")).Enabled);
            
            Logout();
        }
        //
        [Test, TestCaseSource(nameof(ReviewBoundariesValid))]
        public void ValidReviewLengthCheck(string review)
        {
            Preconditions();
            //Steps
            MoveToReviewTab();
            CreateReview(review);
            //Check
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Enabled);

            Logout();
        }
       
    }
}