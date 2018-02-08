using System;
using System.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Globalization;

namespace Rest
{
    public class RestGeneral
    {
        private WebClient client;
        private string url;
        private string mediaTypeHeaderValue;
        private ResultJsonObj repositories;

        public RestGeneral(string url, string mediaTypeHeaderValue)
        {
            this.url = url;
            this.mediaTypeHeaderValue = mediaTypeHeaderValue;
            client = new WebClient();
        }

       

        //private async Task<List<T>> FillAll() // GET
        private async Task FillAll() // GET
        {
            var serializer = new DataContractJsonSerializer(typeof(ResultJsonObj));
            var streamTask = client.OpenReadTaskAsync(url);
            repositories = serializer.ReadObject(await streamTask) as ResultJsonObj;
            //return repositories;
        }

        public ResultJsonObj GetAll()
        {
            FillAll().Wait();
            return repositories;
        }
    }
}
