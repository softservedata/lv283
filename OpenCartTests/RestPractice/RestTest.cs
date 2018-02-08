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
namespace RestPractice
{
    [DataContract()]
    public class ResultJsonObj
    {
        [DataMember(Name = "origin")]
        public string Origin { get; set; }

        [DataMember(Name = "url")]
        public string url { get; set; }

        public override string ToString()
        {
            return "\nOrigin = " + Origin + "\nUrl = " + url;
        }

    }

    public class RestTest
    {
        private ResultJsonObj repositories;

        private async Task FillAll() // GET
        {
            string url = "http://httpbin.org/cache";
            string mediaTypeHeaderValue = "application/json";
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
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
            var serializer = new DataContractJsonSerializer(typeof(ResultJsonObj));
            var streamTask = client.GetStreamAsync(url);
            //repositories = serializer.ReadObject(await streamTask) as List<ResultJsonObj>;
            repositories = serializer.ReadObject(await streamTask) as ResultJsonObj;
        }
        

        public ResultJsonObj GetAll()
        {
            FillAll().Wait();
            return repositories;
        }

        [Test]
        public void CheckFoundationExist()
        {
            RestTest restTest = new RestTest();
            ResultJsonObj resultJsonObj = restTest.GetAll();
            Console.WriteLine("done  Result: " + resultJsonObj);
        }

    }
}