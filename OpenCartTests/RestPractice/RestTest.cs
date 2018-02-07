using NUnit.Framework;
using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestPractice.Rest;
using RestPractice.BLL;

namespace RestPractice
{
    [TestFixture]
    public class RestTest
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

        [Test, TestCaseSource(nameof(FoundationData))]
        public void CheckFoundationExist(string name, string description)
        {
            FoundationNET actualFoundation = new FoundationBLL().GetFoundationByName(name);
            StringAssert.AreEqualIgnoringCase(description, actualFoundation.Description);
        }
    }
}