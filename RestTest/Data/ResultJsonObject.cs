using System.Runtime.Serialization;
using RestSharp;

namespace RestTest.Data
{
    [DataContract()]
    public class ResultJsonObj
    {
        [DataMember(Name = "user-agent")]
        public string UserAgent { get; set; }
    }
}
