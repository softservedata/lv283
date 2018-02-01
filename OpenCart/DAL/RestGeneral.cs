using System;
using System.Xml;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;

namespace OpenCart.DAL
{
    public class RestGeneral<T>
    {
        private HttpClient client;
        private string url;
        private string mediaTypeHeaderValue;
        private Dictionary<string, string> requestHeaders;
        private List<T> repositories;

        public RestGeneral(string url, string mediaTypeHeaderValue,
            Dictionary<string, string> requestHeaders)
        {
            this.url = url;
            this.mediaTypeHeaderValue = mediaTypeHeaderValue;
            this.requestHeaders = requestHeaders;
            Init();
        }

        private void Init()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(mediaTypeHeaderValue));
            foreach (string key in requestHeaders.Keys)
            {
                client.DefaultRequestHeaders.Add(key, requestHeaders[key]);
            }
        }

        private async Task<List<T>> FillAll() // GET
        {
            var serializer = new DataContractJsonSerializer(typeof(List<T>));
            var streamTask = client.GetStreamAsync(url);
            repositories = serializer.ReadObject(await streamTask) as List<T>;
            return repositories;
        }

        public List<T> GetAll()
        {
            FillAll().Wait();
            return repositories;
        }

        //public async Task<T> GetByKey(string key) // GET
        // {
        //}

        //public async Task<int> Create(T element) { } // POST

        //public async Task<T> Update(T searchElement, T modifyElement) { } // PUT

        //public async Task<bool> Delete(T element) { } // DELETE

        //public async Task<bool> Delete(int id) { } // DELETE
    }
}
