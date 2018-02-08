using System.Runtime.Serialization;

namespace RestPractice.Data
{
    [DataContract()]
    public class ResultJsonObj
    {
        [DataMember(Name = "origin")]
        public string Origin { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return "\n Origin = " + Origin + "\n Url = " + Url + "\n Connection = " + Data.Connection + "\n Host = " + Data.Host;
        }

        [DataMember(Name = "headers")]
        public Header Data { get; set; }
    }

    public class Header
    {
        [DataMember(Name = "Connection")]
        public string Connection { get; set; }

        [DataMember(Name = "Host")]
        public string Host { get; set; }
    }
}
