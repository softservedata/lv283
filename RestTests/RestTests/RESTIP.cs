using System;
using System.Net;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Globalization;
using System.Web.Script.Serialization;

namespace RestTests
{
    public class IP
    {
        public string Origin { get; set; }
    }

    static public class RESTIP
    {
        static public void GetIp (out string actual)
        {
            actual = "";
            string url = "http://httpbin.org/ip";
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentLength = data.Length;

            var serializer = new JavaScriptSerializer();
            IP deserializedResult;

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            
                            deserializedResult = serializer.Deserialize<IP>(response);
                            actual = deserializedResult.Origin;
                            //Console.WriteLine(deserializedResult.Origin);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Console.Out.WriteLine("-----------------");
                //Console.Out.WriteLine(e.Message);
            }
            //return deserializedResult.Origin;
        }
    }
}
