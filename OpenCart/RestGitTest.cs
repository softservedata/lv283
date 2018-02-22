using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart.Data.Rest;
using OpenCart.BLL;

namespace OpenCart
{
    [TestFixture]
    public class RestGitTest
    {

        [Test]
        public void FoundationList()
        {
            List<FoundationNET> actualFoundations = new FoundationBLL().GetFoundations();
            foreach (FoundationNET current in actualFoundations)
            {
                Console.WriteLine("Name = " + current.Name + " \t\tDescription= " + current.Description);
            }
        }

        private static readonly object[] FoundationData =
        {
            new object[] { "BenchmarkDotNet", "Powerful .NET library for benchmarking" },
            new object[] { "core", "Home repository for .NET Core" }
        };

        //[Test, TestCaseSource(nameof(FoundationData))]
        public void CheckFoundationExist(string name, string description)
        {
            FoundationNET actualFoundation = new FoundationBLL().GetFoundationByName(name);
            StringAssert.AreEqualIgnoringCase(description, actualFoundation.Description);
        }
    }

}
