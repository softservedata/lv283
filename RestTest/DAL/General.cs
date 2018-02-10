using RestSharp;
using RestTest.Data;

namespace RestTest.DAL
{
    public class RestGeneral
    {
        public RestClient restClient;
        public readonly string url = "https://httpbin.org/";
        public string content;
        public IRestResponse response;

        public RestGeneral()
        {
        }

        public RestGeneral(string url)
        {
            this.url = url;
            Init();
        }

        private void Init()
        {
            restClient = new RestClient(url);
        }

        public void RequestMethod()
        {
            RestRequest request = new RestRequest("user-agent", Method.GET);
            request.AddParameter("name", "value");
            request.AddHeader("user-agent", "Mozilla / 5.0(Windows NT 6.1) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 64.0.3282.140 Safari / 537.36");
            response = restClient.Execute(request);
            content = response.Content;
        }
    }
}
