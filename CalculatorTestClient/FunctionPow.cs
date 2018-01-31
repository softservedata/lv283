using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorTestClient.CalculatorService;
using NUnit.Framework;

namespace CalculatorTestClient
{
	public class FunctionPow
	{
		CalcSEIClient calc = new CalcSEIClient();
		public double bases, exponent;
		public double actual;
		public double extended;

		public void Set(double bases, double exponent)
		{
		    actual = calc.pow(bases, exponent);
		    extended = Math.Pow(bases, exponent);
	    }

		public void Check(double extended, double actual)
		{
			Assert.AreEqual(extended, actual);
		}

		//[Test, Order(2)]
		//public void PowOneToAll(
		//	        [Values(1)] int bases,
		//	        [Range(-10, 10)] int exponent)
		//{
		//	 Set(bases, exponent);
		//	 Check(extended, actual);
		//}
		



		//[Test, Order(3)]
		//public void PowZeroToZero(
		//            [Values(0)] int bases,
		//            [Values(0)] int exponent)
		//{
		//	Set(bases, exponent);
		//	Check(extended, actual); ;
		//}


		//[Test, Order(4)]
		//public void PowZeroToPositive(
		//		    [Values(0)] int a,
		//		    [Range(1, 10)] int exponent)
		//{
		//	Set(bases, exponent);
		//	Check(extended, actual);
		//}


		//[Test, Order(5)]
		//public void PowZeroToNegative(
	 //               [Values(0)] int bases,
	 //               [Range(-10, -1)] int exponent)
		//{
		//	Set(bases, exponent);
		//	Check(extended, actual);
		//}

		//[Test, Order(6)]
		//public void PowNegativeOneToNegativePaired(
		//	        [Values(-1)] int bases,
		//	        [Range(-12, -2, 2)] int exponent)
		//{
		//	Set(bases, exponent);
		//	Check(extended, actual);
		//}

		//[Test, Order(7)]
		//public void PowNegativeOneToNegativeAdd(
	 //               [Values(-1)] int bases,
	 //               [Range(-11, -1, 2)] int exponent)
		//{
		//	Set(bases, exponent);
		//	Check(extended, actual);
		//}

	}
}
