
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestWebClient.Data.Rest;

namespace RestWebClient.DAL
{
	public class StreamDAL : RestGeneral<Stream>
	{
		public StreamDAL() :
		   base(StreamRepository.Get().UrlGutHub(),
			   StreamRepository.Get().MediaTypeHeaderValue(),
			   StreamRepository.Get().RequestHeaders())
		{
		}
	}
}
