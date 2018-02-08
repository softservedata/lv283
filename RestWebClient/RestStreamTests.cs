using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using NUnit.Framework;
using System.Net;
using Newtonsoft.Json;
using RestWebClient.Data.Rest;
using RestWebClient.BBL;

namespace RestWebClient
{

	[TestFixture]
	public class RestStreamTests
	{
		//private List<ResultObj> repositories;
		private Stream repositories;

		private async Task ReadAll()
		{
			//WebClient
			string url = "http://httpbin.org/stream/1";
			using (var webClient = new WebClient())
			{
				//GET
			    var response = webClient.DownloadString(url);
				Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
				//Deserialize
				repositories = JsonConvert.DeserializeObject<Stream>(response);
				//var repo = JsonConvert.DeserializeObject<ResultObj>(response);
				
				//Console.WriteLine("result" + repositories);
				//Console.WriteLine("response" + response);

			}
		}

		//public List<ResultObj> GetAll()
		public Stream GetAll()
		{
			ReadAll().Wait();
			return repositories;
		}

		[Test]
		public void CheckExist()
		{
			RestStreamTests restTest = new RestStreamTests();
			//List<ResultObj> resultObj = restTest.GetAll();
			Stream resultObj = restTest.GetAll();
			//foreach (ResultObj result in resultObj)
			//{
			//	Console.WriteLine("Result: " + result);
			//}
			Console.WriteLine("done  Result: " + resultObj);
		}

		[Test]
		public void StreamList()
		{
			Stream actualStreams = new StreamBLL().GetStreams();
			//Console.WriteLine("Name = " + current.Name + " \t\tDescription= " + current.Description);

		}

		private static readonly object[] StreamData =
		{
			new object[] { "0", true }
		};

		[Test, TestCaseSource(nameof(StreamData))]
		public void CheckStreamExist(string id, bool origin)
		{
			bool actualStream = new StreamBLL().GetStreamById(id);
			Assert.AreEqual(origin, actualStream);
		}

	}
}
