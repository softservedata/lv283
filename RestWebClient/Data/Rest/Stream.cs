using System.Runtime.Serialization;

namespace RestWebClient.Data.Rest
{
	[DataContract()]
	public class Stream
	{
		[DataMember(Name = "origin")]
		public string Origin { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		//[DataMember(Name = "args")]
		//public string Args { get; set; }

		[DataMember(Name = "headers")]
		public Headers Headers { get; set; }

		public override string ToString()
		{
			return "\nOrigin = " + Origin + " \nId = " + Id + "\nUrl = " + Url +
					"\nHost = " + Headers.Host + "\nConnection = " + Headers.Connection;
		}
	}
}
