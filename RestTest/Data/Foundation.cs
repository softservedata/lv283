using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Data
{
    [DataContract]
    public class Foundation
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "method")]
        public string Method { get; set; }
    }
}
