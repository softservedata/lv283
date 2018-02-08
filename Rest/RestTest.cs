using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Globalization;
using NUnit.Framework;


namespace Rest
{
    

    public class RestTest
    {
        [Test]
        public void CheckFoundationExist()
        {
            RestGeneral restTest = new RestGeneral("http://httpbin.org/get", "application/json");
            ResultJsonObj resultJsonObj = restTest.GetAll();
            Console.WriteLine("done  Result: " + resultJsonObj);
        }

    }
}