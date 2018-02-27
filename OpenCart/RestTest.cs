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
// INFO: https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data

namespace OpenCart
{
    //[DataContract(Name = "dotnet")]
    //[DataContract(Name = "anything")]
    [DataContract()]
    public class ResultJsonObj
    {
        [DataMember(Name = "method")]
        public string Method { get; set; }

        [DataMember(Name = "origin")]
        public string Origin { get; set; }

        public override string ToString()
        {
            return "\nMethod = " + Method + "\nOrigin = " + Origin;
        }

    }

    public class RestTest
    {
        //private List<ResultJsonObj> repositories;
        private ResultJsonObj repositories;

        private async Task FillAll() // GET
        {
            //string url = "https://api.github.com/orgs/dotnet/repos";
            //string url = "https://api.github.com/orgs/dotnet";
            string url = "http://httpbin.org/anything";
            //string mediaTypeHeaderValue = "application/vnd.github.v3+json";
            string mediaTypeHeaderValue = "application/json";
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
            //requestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            //
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaTypeHeaderValue));
            foreach (string key in requestHeaders.Keys)
            {
                client.DefaultRequestHeaders.Add(key, requestHeaders[key]);
            }
            //
            //var serializer = new DataContractJsonSerializer(typeof(List<ResultJsonObj>));
            var serializer = new DataContractJsonSerializer(typeof(ResultJsonObj));
            var streamTask = client.GetStreamAsync(url);
            //repositories = serializer.ReadObject(await streamTask) as List<ResultJsonObj>;
            repositories = serializer.ReadObject(await streamTask) as ResultJsonObj;
            //
            //HttpResponseMessage response = client.GetAsync(url).Result;
            //Console.WriteLine("response:  " + response.Content.ReadAsStringAsync().Result);
            //
            //Re
            //Console.WriteLine("response:  " + streamTask.Result.);
            //return repositories;
        }

        //public List<ResultJsonObj> GetAll()
        public ResultJsonObj GetAll()
        {
            FillAll().Wait();
            return repositories;
        }

        //[Test]
        public void CheckFoundationExist()
        {
            RestTest restTest = new RestTest();
            //List<ResultJsonObj> resultJsonObj = restTest.GetAll();
            ResultJsonObj resultJsonObj = restTest.GetAll();
            //Console.WriteLine("resultJsonObj.Count = " + resultJsonObj.Count);
            //foreach (ResultJsonObj result in resultJsonObj)
            //{
            //    Console.WriteLine("Result: " + result);
            //}
            Console.WriteLine("done  Result: " + resultJsonObj);
            //StringAssert.AreEqualIgnoringCase(description, actualFoundation.Description);
        }

    }
}
