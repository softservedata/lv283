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

			public Stream GetStreams()
			{
				var result = streamDAL.GetAll();
				return result;
			}

			public bool GetStreamById(string id)
			{
				Console.WriteLine("Search id = " + id);
			    bool result;
			    Stream data = null;

			if (data.Id.Equals(id))
				{
				result = true;
				}
			else
			{
				result = false;
			}
			    return result;

		}
	}
}
