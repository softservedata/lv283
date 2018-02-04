

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CalculatorTestClient.Data
{
	public class PowRepository 
	{
		private volatile static PowRepository instance;
		private static object lockingObject = new object();

		private PowRepository()
		{
		}

		public static PowRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new PowRepository();
					}
				}
			}
			return instance;
		}

		public IPow GroupPow()
		{
			return Pow.Get()
				.SetBases(1)
				.SetExponent(1)
				.SetExtended(1)
				.Build();
		}
		

		public List<IPow> ExcelPow()
		{
			List<IPow> result = new List<IPow>();

			TestData();
			result.Add(
				Pow.Get()
				.SetBases(1)
				.SetExponent(1)
				.SetExtended(1)
				.Build()
			);
			return result;
		}

		private static IEnumerable<object[]> TestData()
		{
			//read data from xml file
			var doc = XDocument.Load(@"D:\ATQC\TAQC.NET\OpenCart\CalculatorTestClient\Data\TestData.xml");
			return
				from vars in doc.Descendants("testData")
				let expected = vars.Attribute("expected").Value
				let bases = vars.Attribute("bases").Value
				let exponent = vars.Attribute("exponent").Value
				select new object[] { double.Parse(expected),
									  double.Parse(bases),
									  double.Parse(exponent) };
		}






	}
}
