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
using RestPractice.Data;
using RestPractice.BLL;

namespace RestPractice
{
    

    public class RestTest
    {
       

        [Test]
        public void CheckFoundationExist()
        {
            ResultJsonObj restTest = new RestBLL().GetResult();
            Console.WriteLine("done  Result: " + restTest);
        }
    }
}