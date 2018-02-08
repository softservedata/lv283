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

        //[DataContract]
        //public class Repository
        //{
        //    [DataMember(Name = "method")]
        //    public string Method { get; set; }

        //    [DataMember(Name = "url")]
        //    public string Url { get; set; }
        //}

        //public static async Task ProcessRepositories()
        //{
        //    HttpClient client = new HttpClient();
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept
        //        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var serializer = new DataContractJsonSerializer(typeof(Repository));
        //    var streamTask = client.GetStreamAsync("http://httpbin.org/anything");
        //    var repositories = serializer.ReadObject(await streamTask) as Repository;
        //    Console.WriteLine("Method = " + repositories.Method + " Url = " + repositories.Url);
        //    var streamTask2 = client.GetStreamAsync("http://httpbin.org/anything/:anything");
        //    var repositories2 = serializer.ReadObject(await streamTask2) as Repository;
        //    Console.WriteLine("Method = " + repositories2.Method + " Url = " + repositories2.Url);
        //}

        //[Test]
        //public static void Test()
        //{
        //    ProcessRepositories().Wait();

        //    Console.WriteLine("done");
        //}
        private static readonly object[] FoundationData =
        {
            new object[] { "http://httpbin.org/anything", "GET" },
            new object[] { "http://httpbin.org/anything/:anything", "GET" }
        };

        [Test, TestCaseSource(nameof(FoundationData))]
        public void CheckUrl(string expectedUrl, string expectedMethod)
        {
            FoundationBll anythingBll = new FoundationBll(expectedUrl);

            string actualUrl = anythingBll.GetFoundationUrl();
            string actualMethod = anythingBll.GetFoundationMethod();

            Assert.AreEqual(expectedUrl, actualUrl);
            Assert.AreEqual(expectedMethod, actualMethod);
        }
    }
}

