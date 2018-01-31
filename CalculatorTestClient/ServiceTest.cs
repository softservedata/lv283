using NUnit.Framework;

namespace CalculatorTestClient
{
	[TestFixture]
	public class ServiceTest : FunctionPow
	{
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
					[Values(0)] int bases,
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
		public void PowNegativeOneToNegativeOdd(
					[Values(-1)] int bases,
					[Range(-11, -1, 2)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}

		[Test, Order(8)]
		public void PowNegativeOneToPositivePaired(
					[Values(-1)] int bases,
					[Range(2, 12, 2)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}

		[Test, Order(9)]
		public void PowNegativeOneToPositiveOdd(
					[Values(-1)] int bases,
					[Range(1, 11, 2)] int exponent)
		{
			Set(bases, exponent);
			Check(extended, actual);
		}


	}
}
