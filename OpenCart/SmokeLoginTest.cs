using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Actions.User;
using OpenCart.Pages;

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
            HomeActions homeActions = Application.Get().LoadHomeActions();
            homeActions
            Thread.Sleep(2000);
        }
    }
}
