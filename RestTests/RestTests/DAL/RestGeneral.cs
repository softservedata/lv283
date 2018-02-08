using System;
using System.Net;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Globalization;
using System.Web.Script.Serialization;
using RestTests.Data.Rest;

namespace RestTests.DAL
{
    public class RestGeneral
    {
        private string url;
        private string myIp;
        HttpWebRequest request;
        JsonData deserializedResult;

        public RestGeneral(string url)
        {
            this.url = url;
            Init();
        }
        private void Init()
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";            
        }

        public string GetIp()
        {
            string actual = "";
            //string url = "http://httpbin.org/ip";

            //request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";

            //var serializer = new JavaScriptSerializer();            
            var serializer = new JavaScriptSerializer();

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

                            deserializedResult = serializer.Deserialize<JsonData>(response);
                            actual = deserializedResult.Origin;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

            return actual;
        }

    }
}
