using RestWebClient.Data.Rest;

namespace RestWebClient.DAL
{
	public class StreamDAL : RestGeneral<Stream>
	{
		public StreamDAL() :
			base(StreamRepository.Get().Url())
		{
		}
	}
}

