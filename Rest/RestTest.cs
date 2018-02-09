using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;
using NUnit.Framework;


namespace Rest
{
    [TestFixture]
    public class RestTest
    {

        public static readonly object[] Data =
        {
            new object[] {"http://httpbin.org/get", "application/json"},
            new object[] {"http://httpbin.org/anything", "application/json"},
            new object[] { "http://httpbin.org/cache", "application/json" },
            new object[] { "http://httpbin.org/etag/etag", "application/json" }
        };


        [Test, TestCaseSource(nameof(Data))]
        public void CheckFoundationExist(string link, string header)
        {
            ResultJsonObj resultJsonObj = new RestGeneral(link, header).GetAll();
            Console.WriteLine("done  Result: " + resultJsonObj);
        }

    }
}