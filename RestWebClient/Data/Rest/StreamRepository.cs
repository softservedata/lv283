using System.Collections.Generic;

namespace RestWebClient.Data.Rest
{
	public class StreamRepository
	{
		private volatile static StreamRepository instance;
		private static object lockingObject = new object();

		private StreamRepository()
		{
		}
		public static StreamRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new StreamRepository();
					}
				}
			}
			return instance;
		}

		public string UrlGutHub()
		{
			return "http://httpbin.org/stream/1";
		}		

		public string MediaTypeHeaderValue()
		{
			return "application/vnd.github.v3+json";
		}

		public Dictionary<string, string> RequestHeaders()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			result.Add("origin", "194.44.52.254");
			return result;
		}
	}
}
