using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using RestWebClient.Data.Rest;

namespace RestWebClient.DAL
{
	public class RestGeneral<T>
	{
		private WebClient client;
		private string url;
		private string mediaTypeHeaderValue;
		private Dictionary<string, string> requestHeaders;
		private string response;
		private Stream repositories;

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
			client = new WebClient();
			response = client.DownloadString(url);
		}

		private async Task ReadAll() // GET
		{
			repositories = JsonConvert.DeserializeObject<Stream>(response);
		}

		public Stream GetAll()
		{
			ReadAll().Wait();
			return repositories;
		}
	}
}
