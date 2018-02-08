using System;
using System.Net;
using Newtonsoft.Json;
using RestWebClient.Data.Rest;


namespace RestWebClient.DAL
{
	public class RestGeneral<T>
	{
		private WebClient client;
		private string url;
		private string response;
		private Stream repositories;

		public RestGeneral(string url)
		{
			this.url = url;
			Init();
		}

		private void Init()
		{
			client = new WebClient();
			response = client.DownloadString(url);
		}

		private void ReadAll() // GET
		{
			try
			{
				repositories = JsonConvert.DeserializeObject<Stream>(response);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public Stream GetAll()
		{
			ReadAll();
			return repositories;
		}
	}
}
