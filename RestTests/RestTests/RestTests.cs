using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestTests
{
    [TestClass]
    public class RestTests
    {
        [TestMethod]
        public void CheckIP()
        {
            string expected = "188.230.55.18";
            string actual = "";

            RESTIP.GetIp(out actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
