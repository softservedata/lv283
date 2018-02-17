using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;
using NUnit.Framework;
using RestTest.BLL;

namespace CheckAnything
{
    [TestFixture]
    public class Tests
    {

        private static readonly object[] FoundationData =
        {
            new object[] { "http://httpbin.org/anything", "GET" },
            new object[] { "http://httpbin.org/anything/:anything", "GET" }
        };

        [Test, TestCaseSource(nameof(FoundationData))]
        public void CheckUrlAndMethod(string expectedUrl, string expectedMethod)
        {
            FoundationBll anythingBll = new FoundationBll(expectedUrl);

            string actualUrl = anythingBll.GetFoundationUrl();
            string actualMethod = anythingBll.GetFoundationMethod();

            Assert.AreEqual(expectedUrl, actualUrl);
            Assert.AreEqual(expectedMethod, actualMethod);
        }
    }
}

