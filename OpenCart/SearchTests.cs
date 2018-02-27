using System.Collections.Generic;
using NUnit.Framework;
using OpenCart.Pages;
using OpenCart.Actions.User;
using NLog;

namespace OpenCart
{

    [TestFixture]
    public class SearchTests : TestRunner
    {
        public static Logger log = LogManager.GetCurrentClassLogger();

        private static string[] positiveSearchData = new string[] { "mac", "5d", "30" };
        private static string[] negativeSearchData = new string[] { "$", "%", " ", "" };

        [Test, TestCaseSource("positiveSearchData")]
        public void PositiveSearchTest(string searchName)
        {
            log.Info("PositiveSearchTest is started");
            SuccessSearchActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccessSearchProduct(searchName);

            List<string> list = searchActions.GetProductComponentTextList();

            foreach (string element in list)
            {
                StringAssert.Contains(searchName.ToUpper(), element.ToUpper());
            }
            log.Info("PositiveSearchTest is finished");
        }

        [Test, TestCaseSource("negativeSearchData")]
        public void NegativeSearchTest(string searchName)
        {
            log.Info("NegativeSearchTest is started");
            SuccessSearchActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccessSearchProduct(searchName);

            Assert.NotNull(searchActions.SuccessSearchPageOperation.GetMessegeNoProductText());
            log.Info("NegativeSearchTest is finished");
        }
    }
}
