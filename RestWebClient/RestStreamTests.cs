using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		public string actual;
		//private List<ResultObj> repositories;
		public Stream repositories;

		private async Task ReadAll()
		{
			//WebClient
			string url = "http://httpbin.org/stream/1";
			using (var webClient = new WebClient())
			{
			    var response = webClient.DownloadString(url);
				Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
				//Deserialize
				repositories = JsonConvert.DeserializeObject<Stream>(response);
				//var repo = JsonConvert.DeserializeObject<ResultObj>(response);
				

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
			Console.WriteLine("done  Result: " + resultObj);
		}

		[Test]
		public void StreamList()
		{
			Stream actualStreams = new StreamBLL().GetStreams();
			Console.WriteLine("\tOrigin = " + actualStreams.Origin + " \tId= " + actualStreams.Id
				+ " \tUrl= " + actualStreams.Url + " \tHeaders.Host= " + actualStreams.Headers.Host 
				+ " \tHeaders.Connection= " + actualStreams.Headers.Connection);

		}
		//private static readonly object[] StreamData =
		//{
		//	new object[] { "0", true }
		//};

		//[Test, TestCaseSource(nameof(StreamData))]
		//public void CheckStreamExist(string id, bool origin)
		//{
		//	bool actualStream = new StreamBLL().GetStreamById(id);
		//	Assert.AreEqual(origin, actualStream);
		//}
		StreamBLL actualRest = new StreamBLL();

		private static readonly object[] IdData =
	    {
			new object[] { StreamRepository.Get().Id() }
		};		
		[Test, TestCaseSource(nameof(IdData))]
		public void CheckIP(string expected)
		{			
			actual = actualRest.GetStreams().Id;
			Assert.AreEqual(expected, actual);
		}

		private static readonly object[] HeadersData =
        {
			new object[] { StreamRepository.Get().Connection()}
		};

		[Test, TestCaseSource(nameof(HeadersData))]
		public void CheckConnection(string expected)
		{			
			actual = actualRest.GetStreams().Headers.Connection;
			Assert.AreEqual(expected, actual);
		}
	}
}
