using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
			return "https://api.github.com/orgs/dotnet/repos";
		}

		public string MediaTypeHeaderValue()
		{
			return "application/vnd.github.v3+json";
		}

		public Dictionary<string, string> RequestHeaders()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			result.Add("User-Agent", ".NET Foundation Repository Reporter");
			return result;
		}
	}
}
