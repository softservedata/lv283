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
        private static readonly object[] People =
        {
            new object[] { NameRepository.Get().PeopleNames() }
        };

        [Test, TestCaseSource(nameof(People))]
        public void PeopleNamesTest(List<IName> name)
        {
            CustomAdapter adapter = new CustomAdapter(driver);

            Assert.IsTrue(adapter.CheckPeopleNames(name));
        }

        private static readonly object[] Dogs =
        {
            new object[] { NameRepository.Get().DogNames() }
        };

        [Test, TestCaseSource(nameof(Dogs))]
        public void DogsNamesTest(List<IName> name)
        {
            CustomAdapter adapter = new CustomAdapter(driver);

            Assert.IsTrue(adapter.CheckDogNames(name));
        }

        private static readonly object[] Cats =
        {
            new object[] { NameRepository.Get().CatNames() }
        };

        [Test, TestCaseSource(nameof(Cats))]
        public void CatsNamesTest(List<IName> name)
        {
            CustomAdapter adapter = new CustomAdapter(driver);

            Assert.IsTrue(adapter.CheckCatNames(name));
        }

        private static readonly object[] Fishes =
        {
            new object[] { NameRepository.Get().FishNames() }
        };

        [Test, TestCaseSource(nameof(Fishes))]
        public void FishesNamesTest(List<IName> name)
        {
            CustomAdapter adapter = new CustomAdapter(driver);

            Assert.IsTrue(adapter.CheckFishNames(name));
        }
    }
}
