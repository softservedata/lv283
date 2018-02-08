using System;
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
			    Stream data  = new Stream();

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
