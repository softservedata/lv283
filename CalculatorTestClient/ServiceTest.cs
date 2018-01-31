using System;
using CalculatorTestClient.CalculatorService;
using NUnit.Framework;

namespace CalculatorTestClient
{
	[TestFixture]
	public class ServiceTest : FunctionPow
	{
		//[Test]
		//public void PowTest(
		//               [Values(2)] int a,
		//			[Values(-10, 0, 10)] int b)
		//{
		//	CalcSEIClient calc = new CalcSEIClient();
		//	double actual = calc.pow(a, b);
		//	Console.WriteLine(" {0} ^ {1} = {2} ", a, b, actual);
		//	Console.WriteLine(" {0} ^ {1} = {2} ", a, b, Math.Pow(a,b));
		//	Console.WriteLine("Answer: " + calc.about("Ivan"));
		//}


		[Test, Order(2)]
		public void PowOneToAll(
			[Values(1)] int bases,
			[Range(-10, 10)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}
		
		[Test, Order(3)]
		public void PowZeroToZero(
					[Values(0)] int bases,
					[Values(0)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual); ;
		}

		[Test, Order(4)]
		public void PowZeroToPositive(
					[Values(0)] int a,
					[Range(1, 10)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}

		[Test, Order(5)]
		public void PowZeroToNegative(
					[Values(0)] int bases,
					[Range(-10, -1)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}

		[Test, Order(6)]
		public void PowNegativeOneToNegativePaired(
					[Values(-1)] int bases,
					[Range(-12, -2, 2)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}

		[Test, Order(7)]
		public void PowNegativeOneToNegativeAdd(
					[Values(-1)] int bases,
					[Range(-11, -1, 2)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}


	}
}
