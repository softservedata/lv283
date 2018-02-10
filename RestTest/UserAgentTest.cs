using System;
using NUnit.Framework;
using RestTest.Data;
using RestTest.BLL;
using RestSharp;
using RestTest.DAL;

namespace RestTest
{
    [TestFixture]
    public class UserAgentTest
    {
        [Test]
        public void UserAgentIsNullTest()
        {
            ResultJsonObj restTest = new ResultJsonObj();
            Assert.IsNull(restTest.UserAgent);
            Console.WriteLine("User agent: " + restTest.UserAgent);
        }

        [Test]
        public void UserAgentContentTest()
        {
            RestGeneral restClass = new RestGeneral();
            Console.WriteLine("Content " + restClass.content);
            Assert.IsNull(restClass.content);
        }
    }
}
