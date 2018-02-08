using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;
using NUnit.Framework;
using RestPractice.Data;

namespace RestPractice.DAL
{
    public class RestGeneral<T>
    {
        private HttpClient client;
        private string url;
        private ResultJsonObj repositories;

        public RestGeneral(string url)
        {
            this.url = url;
            Init();
        }

        private void Init()
        {
            client = new HttpClient();
        }
        
        private async Task FillAll() // GET
        {
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
            //
            HttpClient client = new HttpClient();
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
    }
}
