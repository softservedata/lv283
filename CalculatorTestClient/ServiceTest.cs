using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CalculatorTestClient.Data;

namespace CalculatorTestClient
{
	[TestFixture]
	public class ServiceTest : FunctionPow
	{

		[Test]
		public void PowOneToAll(
					[Values(1)] int bases,
					[Range(-10, 10)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowZeroToZero(
					[Values(0)] int bases,
					[Values(0)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowZeroToPositive(
					[Values(0)] int bases,
					[Range(1, 10)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowZeroToNegative(
					[Values(0)] int bases,
					[Range(-10, -1)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowNegativeOneToNegativePaired(
					[Values(-1)] int bases,
					[Range(-12, -2, 2)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowNegativeOneToNegativeOdd(
					[Values(-1)] int bases,
					[Range(-11, -1, 2)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowNegativeOneToPositivePaired(
					[Values(-1)] int bases,
					[Range(2, 12, 2)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowNegativeOneToPositiveOdd(
					[Values(-1)] int bases,
					[Range(1, 11, 2)] int exponent)
		{
			Set(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		//[Test, Order(1), TestCaseSource(nameof(DataNumbers.TestData))]
		//public void Pows(
		//	 double bases,
		//	 double exponent,
		//	 double extended)
		//{
		//	Pow(bases, exponent);
		//	Assert.AreEqual(extended, actual);
		//}


	}
}
