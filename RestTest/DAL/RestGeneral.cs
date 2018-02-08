using RestTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.DAL
{
    public class RestGeneral
    {
        private HttpClient client;
        private string url;
        private string mediaTypeHeaderValue;
        private Foundation repository;

        public RestGeneral(string url, string mediaTypeHeaderValue)
        {
            this.url = url;
            this.mediaTypeHeaderValue = mediaTypeHeaderValue;
            Init();
        }

        private void Init()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaTypeHeaderValue));
        }

        public async Task FindRepository()
        {
            var serializer = new DataContractJsonSerializer(typeof(Foundation));
            var streamTask = client.GetStreamAsync(url);
            repository = serializer.ReadObject(await streamTask) as Foundation;
        }

        public Foundation GetRepository()
        {
            FindRepository().Wait();
            return repository;
        }

    }
}