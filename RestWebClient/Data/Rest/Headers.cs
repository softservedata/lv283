using System.Runtime.Serialization;

namespace RestWebClient.Data.Rest
{
	[DataContract]
	public class Headers
	{
		[DataMember(Name = "Host")]
		public string Host { get; set; }

		[DataMember(Name = "User-Agent")]
		public string UserAgent { get; set; }

		[DataMember(Name = "Connection")]
		public string Connection { get; set; }

		[DataMember(Name = "Upgrade-Insecure-Requests")]
		public string UpgradeInsecureRequests { get; set; }

		[DataMember(Name = "Accept-Encoding")]
		public string AcceptEncoding { get; set; }

		[DataMember(Name = "Cookie")]
		public string Cookie { get; set; }

		[DataMember(Name = "Accept")]
		public string Accept { get; set; }

	}

}
