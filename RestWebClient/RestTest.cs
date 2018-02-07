using NUnit.Framework;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.Serialization;

namespace RestWebClient
{
	[TestFixture]
	[DataContract(Name = "repo")]
	public class RestTest
	{
		[DataMember(Name = "origin")]
		public string Name { get; set; }

		[DataMember(Name = "url")]
		public string Description { get; set; }

		[DataMember(Name = "id")]
		public Uri GitHubHomeUrl { get; set; }
		[DataMember(Name = "args")]
		public Uri Homepage { get; set; }

		[DataMember(Name = "headers")]
		public int Watchers { get; set; }

		[DataMember(Name = "pushed_at")]
		private string JsonDate { get; set; }

		[Test]
		public void Test()
		{
			// WebClient
			//string url = "http://httpbin.org/stream/10";
			using (WebClient client = new WebClient())
			{
				string lines = "5";
				//string url = "http://httpbin.org/stream/5" + lines;
				string url = "http://httpbin.org/stream/5";
				string content = client.DownloadString(url);
				Console.WriteLine(content);
			}

			// WebClient
			//string url = "http://localhost:51266/api/home";
			//string url = "https://api.github.com/orgs/dotnet/repos";
			//using (var webClient = new WebClient())
			//{
			// GET
			//var response = webClient.DownloadString(url);
			//
			// Post // Error
			//var pars = new NameValueCollection();
			//var response = webClient.UploadValues(url, pars);
			//pars.Add("format", "json");
			//
			//Console.WriteLine("response: " + response);
			//}
			//
			//
			// HttpClient //Method GET
			//string url = "http://localhost:51266/api/home";
			//string urlParameters = "";
			//HttpClient client = new HttpClient();
			//client.BaseAddress = new Uri(url);
			// Add an Accept header for JSON format. 
			//client.DefaultRequestHeaders.Accept.Add(
			//    new MediaTypeWithQualityHeaderValue("application/json"));
			// List data response. 
			//HttpResponseMessage response = client.GetAsync(urlParameters).Result;
			//
			// Blocking call! 
			//if (response.IsSuccessStatusCode)
			//{
			// Parse the response body. Blocking! 
			//var result = response.Content
			//    .ReadAsStringAsync().Result;
			//Console.WriteLine("result" + result);
			//}
			//else
			//{
			//Console.WriteLine("{0} ({1})", (int)response.StatusCode,
			//    response.ReasonPhrase);
			//}
			//
			// (HttpWebRequest)WebRequest
			//string url = "http://localhost:51266/api/home/123";
			//string url = "https://api.github.com/orgs/dotnet/repos";
			//string data = "";
			//HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			//request.Method = "GET"; // DO NOT USE request.GetRequestStream()
			//request.Method = "POST";
			//request.Method = "DELETE";
			//request.Method = "PUT";
			//request.ContentType = "application/json";
			//request.ContentLength = data.Length;
			//using (Stream webStream = request.GetRequestStream())
			//{
			//    using (StreamWriter requestWriter =
			//        new StreamWriter(webStream, System.Text.Encoding.ASCII))
			//    {
			//        requestWriter.Write(data);
			//    }
			//}
			//try
			//{
			//    WebResponse webResponse = request.GetResponse();
			//    using (Stream webStream = webResponse.GetResponseStream())
			//    {
			//        if (webStream != null)
			//        {
			//            using (StreamReader responseReader = new StreamReader(webStream))
			//            {
			//                string response = responseReader.ReadToEnd();
			//                Console.WriteLine("response: " + response);
			//            }
			//        }
			//    }
			//}
			//catch (Exception e)
			//{
			//    Console.Out.WriteLine("-----------------");
			//    Console.Out.WriteLine(e.Message);
			//}
			//
			// RestClient
			//string url = "http://localhost:51266/";
			////string url = "https://api.github.com/";
			////var client = new RestClient(url);
			////// client.Authenticator = new HttpBasicAuthenticator(username, password);
			////var request = new RestRequest("orgs/dotnet/repos", Method.GET);
			//
			//var request = new RestRequest("api/home/123", Method.GET);
			//var request = new RestRequest("api/home/123", Method.POST);
			//var request = new RestRequest("api/home/123", Method.DELETE);
			//var request = new RestRequest("api/home/123", Method.PUT);
			//
			//request.AddParameter("name", "value");
			// adds to POST or URL querystring based on Method
			//request.AddUrlSegment("id", "123");
			// replaces matching token in request.Resource
			// easily add HTTP Headers
			//request.AddHeader("header", "value");
			// add files to upload (works with compatible verbs)
			//request.AddFile(path);
			// execute the request
			////IRestResponse response = client.Execute(request);
			////var content = response.Content;
			////Console.WriteLine("content: " + content);
			// raw content as string
			// or automatically deserialize result
			// return content type is sniffed
			// but can be explicitly set via RestClient.AddHandler();
			//
			//RestResponse<Person> response2 = client.Execute<Person>(request);
			//var name = response2.Data.Name;
			// easy async support
			//client.ExecuteAsync(request, response => {
			//    Console.WriteLine(response.Content);
			//});
			// async with deserialization
			//var asyncHandle = client.ExecuteAsync<Person>(request, response => {
			//    Console.WriteLine(response.Data.Name);
			//});
			// abort the request on demand
			//asyncHandle.Abort();
			//
			Console.WriteLine("done");
		}
	}
}
