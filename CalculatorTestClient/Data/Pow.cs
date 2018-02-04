namespace CalculatorTestClient.Data
{
	public interface IBases
	{
		IExponent SetBases(double bases);
	}

	public interface IExponent
	{
		IExtended SetExponent(double exponent);
	}

	public interface IExtended
	{
		IPowBuilder SetExtended(double extended);
	}

	public interface IPowBuilder
	{
		IPow Build();
	}

	public interface IPow
	{
		double GetBases();
		double GetExponent();
		double GetExtended();
	}
	public class Pow : IBases,IExponent,
		               IExtended,IPowBuilder,IPow
	{
		private double bases;
		private double exponent;
		private double extended;

		private Pow()
		{
		}

		public static IBases Get()
		{
			return new Pow();
		}

		public IExponent SetBases(double bases)
		{
			this.bases = bases;
			return this;
		}

		public IExtended SetExponent(double exponent)
		{
			this.exponent = exponent;
			return this;
		}

		public IPowBuilder SetExtended(double extended)
		{
			this.extended = extended;
			return this;
		}

		public IPow Build()
		{
			return this;
		}

		public double GetBases()
		{
			return bases;
		}
		public double GetExponent()
		{
			return exponent;
		}

		public double GetExtended()
		{
			return extended;
		}
	}
}
