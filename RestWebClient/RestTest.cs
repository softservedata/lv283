using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;
using NUnit.Framework;

namespace RestWebClient
{
	//[DataContract(Name = "dotnet")]
	//[DataContract(Name = "anything")]
	[DataContract()]
	//[DataContract(Name = "headers")]
	public class ResultJsonObj
	{
		[DataMember(Name = "origin")]
		public string Origin { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "args")]
		public string Args { get; set; }

		//[DataContract(Name = "headers")]
		//public class Headers
		//{
		//   [DataMember(Name = "Host")]
		//public string Host { get; set; }

		//[DataMember(Name = "User-Agent")]
		//public string UserAgent { get; set; }

		//[DataMember(Name = "Connection")]
		//public string Connection { get; set; }

		//[DataMember(Name = "Upgrade-Insecure-Requests")]
		//public string UpgradeInsecureRequests { get; set; }

		//[DataMember(Name = "Accept-Encoding")]
		//public string AcceptEncoding { get; set; }

		//[DataMember(Name = "Cookie")]
		//public string Cookie { get; set; }

		//[DataMember(Name = "Accept")]
		//public string Accept { get; set; }

		//public override string ToString()
		//{
		//	return "\nHost = " + Host + " \nUserAgent = " + UserAgent + "\nConnection = " + Connection +
		//		"\nUpgradeInsecureRequests = " + UpgradeInsecureRequests
		//		+ "\nAccept-Encoding= " + AcceptEncoding + "\nCookie= " + Cookie
		//		+ "\nAccept= " + Accept;
		//}

		//}

		//[DataMember(Name = "headers")]
		//public string Headers { get; set; }
		public override string ToString()
		{
			return "\nOrigin = " + Origin + " \nId = " + Id + "\nUrl = " + Url +
				"\nArgs = " /*+ "\nHeaders = " + Headers*/;
		}

	}

	public class RestTest
	{
		private List<ResultJsonObj> repositories;
		//private ResultJsonObj repositories;

		private async Task FillAll() // GET
		{
			//string url = "https://api.github.com/orgs/dotnet/repos";
			string url = "http://httpbin.org/stream/10";
			//string url = "http://httpbin.org/headers";
			//string mediaTypeHeaderValue = "application/vnd.github.v3+json";
			string mediaTypeHeaderValue = "application/json";
			Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
			//requestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
			//
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept
				.Add(new MediaTypeWithQualityHeaderValue(mediaTypeHeaderValue));
			foreach (string key in requestHeaders.Keys)
			{
				client.DefaultRequestHeaders.Add(key, requestHeaders[key]);
			}
			//
			var serializer = new DataContractJsonSerializer(typeof(List<ResultJsonObj>));
			//var serializer = new DataContractJsonSerializer(typeof(ResultJsonObj));
			var streamTask = client.GetStreamAsync(url);
			repositories = serializer.ReadObject(await streamTask) as List<ResultJsonObj>;
			//repositories = serializer.ReadObject(await streamTask) as ResultJsonObj;
			//
			//HttpResponseMessage response = client.GetAsync(url).Result;
			//Console.WriteLine("response:  " + response.Content.ReadAsStringAsync().Result);
			//
			//Re
			//Console.WriteLine("response:  " + streamTask.Result.);
			//return repositories;
		}

		public List<ResultJsonObj> GetAll()
		//public ResultJsonObj GetAll()
		{
			FillAll().Wait();
			return repositories;
		}

		[Test]
		public void CheckFoundationExist()
		{
			RestTest restTest = new RestTest();
			List<ResultJsonObj> resultJsonObj = restTest.GetAll();
			//ResultJsonObj resultJsonObj = restTest.GetAll();
			//Console.WriteLine("resultJsonObj.Count = " + resultJsonObj.Count);
			foreach (ResultJsonObj result in resultJsonObj)
			{
				Console.WriteLine("" + result);
			}
			//Console.WriteLine("done  Result: " + resultJsonObj);
			//StringAssert.AreEqualIgnoringCase(description, actualFoundation.Description);
			Console.WriteLine("Result: ");
		}
	}
}
