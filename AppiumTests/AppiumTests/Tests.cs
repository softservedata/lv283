using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using AppiumTests.Data.Names;

namespace AppiumTests
{
    [TestFixture]
    public class Tests : TestRunner
    {
        private static readonly object[] UserNames =
        {
            new object[] { NameRepository.Get().PeopleNames() }
        };

        [Test, TestCaseSource(nameof(UserNames))]
        public void TestMethod1(List<IName> name)
        {
            View view = new View(driver);

            Assert.IsTrue(view.CustomAdapterNames(name));
        }
    }
}
