using System;
using HttpClientRestTests.DAL;
using NUnit.Framework;

namespace HttpClientRestTests
{
    [TestFixture]
    public class RestTests
    {
        [Test]
        public void StatusTest()
        {
            RestGeneral api = new RestGeneral();
            StringAssert.Contains("teapot", api.GetAll());
            Console.WriteLine(api.GetAll());
        }
    }
}
