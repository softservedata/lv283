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
					[Range(-8, 8)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual);
		}

		[Test]
		public void PowZeroToZero(
					[Values(0)] int bases,
					[Values(0)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}

		[Test]
		public void PowZeroToPositive(
					[Values(0)] int bases,
					[Range(1, 8)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}

		[Test]
		public void PowZeroToNegative(
					[Values(0)] int bases,
					[Range(-8, -1)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}

		[Test]
		public void PowNegativeOneToNegativePaired(
					[Values(-1)] int bases,
					[Range(-10, -2, 2)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}

		[Test]
		public void PowNegativeOneToNegativeOdd(
					[Values(-1)] int bases,
					[Range(-9, -1, 2)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}

		[Test]
		public void PowNegativeOneToPositivePaired(
					[Values(-1)] int bases,
					[Range(2, 10, 2)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}

		[Test]
		public void PowNegativeOneToPositiveOdd(
					[Values(-1)] int bases,
					[Range(1, 9, 2)] int exponent)
		{
			Pow(bases, exponent);
			Assert.AreEqual(extended, actual, 0.001);
		}



		//TODO
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
