using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestWebClient.Data.Rest;
using RestWebClient.DAL;

namespace RestWebClient.BBL
{
	public class StreamBLL
	{
		private StreamDAL streamDAL;

		public StreamBLL()
		{
			streamDAL = new StreamDAL();
		}

		public List<Stream> GetStreams()
		{
			var result = streamDAL.GetAll();
			return result;
		}

		public Stream GetStreamByName(string name)
		{
			Console.WriteLine("Search name = " + name);
			Stream result = null;
			foreach (Stream current in GetStreams())
			{
				Console.WriteLine("current Name = " + current.Name);
				if (current.Name.ToLower().Trim().Equals(name.ToLower().Trim()))
				{
					result = current;
					break;
				}
			}
			return result;
		}
	}
}
