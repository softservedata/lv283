using System;
using NUnit.Framework;
using RestTests.Data.Rest;
using RestTests.BLL;

namespace RestTests
{
    [TestFixture]
    public class RestTests //: TestRunner
    {
        private static readonly object[] IpData =
        {
            new object[] { RestRepository.Get().MyIP() }
        };

        [Test, TestCaseSource(nameof(IpData))]
        public void CheckIP (string expected)
        {
            string actual = "";
            RestBLL actualRest = new RestBLL();

            actual = actualRest.GetFoundations();
            Assert.AreEqual(expected, actual);
        }
    }
}
