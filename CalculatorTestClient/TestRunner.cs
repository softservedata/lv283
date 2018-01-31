using CalculatorTestClient.CalculatorService;
using NUnit.Framework;

namespace CalculatorTestClient
{
	public class TestRunner
	{
		protected CalcSEIClient calc;

		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			calc = new CalcSEIClient();
		}

	}
}
