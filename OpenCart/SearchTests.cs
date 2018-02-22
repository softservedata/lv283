using System.Collections.Generic;
using NUnit.Framework;
using OpenCart.Pages;
using OpenCart.Actions.User;

namespace OpenCart
{

    [TestFixture]
    public class SearchTests : TestRunner
    {
        private static string[] positiveSearchData = new string[] { "mac", "5d", "30" };
        private static string[] negativeSearchData = new string[] { "$", "%", " ", "" };

        [Test, TestCaseSource("positiveSearchData")]
        public void PositiveSearchTest(string searchName)
        {
            SuccesSearchActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccesSearchProduct(searchName);

            List<string> list = searchActions.GetProductComponentTexts();

            foreach (string element in list)
            {
                StringAssert.Contains(searchName.ToUpper(), element.ToUpper());
            }
        }

        [Test, TestCaseSource("negativeSearchData")]
        public void NegativeSearchTest(string searchName)
        {
            SuccesSearchActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccesSearchProduct(searchName);

            Assert.NotNull(searchActions.SuccesSearchPageOperation.GetMessegeNoProductText());

        }
    }
}
