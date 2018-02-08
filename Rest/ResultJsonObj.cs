using System.Runtime.Serialization;

namespace Rest
{
    [DataContract()]
    public class ResultJsonObj
    {
        [DataMember(Name = "origin")]
        public string Origin { get; set; }

        [DataMember(Name = "url")]
        public string url { get; set; }

        public override string ToString()
        {
            return "\nOrigin = " + Origin + "\nUrl = " + url;
        }

    }
}
