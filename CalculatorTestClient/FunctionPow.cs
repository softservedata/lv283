using System;
using NUnit.Framework;

namespace CalculatorTestClient 
{
	public class FunctionPow : TestRunner
	{
		public double actual;
		public double extended;

		public void Set(double bases, double exponent)
		{
			try
			{
				actual = calc.pow(bases, exponent);
				extended = Math.Pow(bases, exponent);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
	    }

		public void Pow(double bases, double exponent)
		{
			try
			{
				actual = calc.pow(bases, exponent);
				extended = Math.Pow(bases, exponent);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}


	}
}
