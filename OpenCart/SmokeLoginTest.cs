using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Pages;
using OpenCart.Pages.User;

namespace OpenCart
{
    [TestFixture]
    public class SmokeLoginTest : TestRunner
    {
        private static readonly object[] CData =
        {
            new object[] { "U" }
        };

        [Test, TestCaseSource(nameof(CData))]
        public void CheckChangeCurrency(string c)
        {
            HomePage homePage = Application.Get().LoadHomePage();
            Thread.Sleep(2000);
        }
    }
}
