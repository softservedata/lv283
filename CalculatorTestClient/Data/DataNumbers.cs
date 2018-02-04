using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CalculatorTestClient.Data
{
	public class DataNumbers
	{
		public  static IEnumerable<object[]> TestData()
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
