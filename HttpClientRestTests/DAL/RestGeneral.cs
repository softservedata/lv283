using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpClientRestTests.DAL
{
    public class RestGeneral
    {
        private HttpClient client;
        private Uri uri;
        private string result;

        public RestGeneral()
        {
            this.uri = new Uri("http://httpbin.org/status/418");
            Init();
        }

        private void Init()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
        }

        private async Task GetTaskWithStringResponse()
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            result = await response.Content.ReadAsStringAsync();
        }

        public string GetAll()
        {
            GetTaskWithStringResponse().Wait();
            return result;
        }
    }
}
