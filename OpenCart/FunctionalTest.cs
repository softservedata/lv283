using System;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NSubstitute;

namespace OpenCart
{
    //[TestClass]
    [TestFixture]
    public class FunctionalTest
    {
        private string steps = "";

        //[TestMethod]
        //[Test, Order(3)]
        public void CheckOpen()
        {
            steps += "\nCheckOpen() done";
            Console.WriteLine("CheckOpen() done steps = " + steps);
        }

       // [Test, Order(1)]
        public void CheckRunning()
        {
            steps += "\nCheckRunning() done";
            Console.WriteLine("CheckRunning() done steps = " + steps);
        }

        //[Test, Order(2)]
        public void CheckClose()
        {
            steps += "\nCheckClose() done";
            Console.WriteLine("CheckClose() done steps = " + steps);
            throw new Exception("ha-ha-ha");
        }

        //[Test]
        public void CheckDependency()
        {
            steps += "\nCheckRunning() done";
            Console.WriteLine("CheckDependency() done steps = " + steps);
        }

    }
}
