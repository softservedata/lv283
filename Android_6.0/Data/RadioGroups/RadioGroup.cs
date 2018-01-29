using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.Data.RadioGroups
{
	public interface ISnack
	{
		IBreakfast SetSnack(string snack);
	}

	public interface IBreakfast
	{
		ILunch SetBreakfast(string breakfast);
	}

	public interface ILunch
	{
		IDinner SetLunch(string lunch);
	}

	public interface IDinner
	{
		IAll SetDinner(string dinner);
	}

	public interface IAll
	{
		IClear SetAll(string all);
	}

	public interface IClear : IRadioGroupBuilder
	{
		IRadioGroupBuilder SetClear(string clear);
	}

	public interface IRadioGroupBuilder
	{
		IRadioGroup Build();
	}

	public interface IRadioGroup
	{
		string GetSnack();
		string GetBreakfast();
		string GetLunch();
		string GetDinner();
		string GetAll();
		string GetClear();
	}

	public class RadioGroup : ISnack, IBreakfast, ILunch, IDinner,IAll,IClear,
		                      IRadioGroupBuilder, IRadioGroup
	{
		private string snack;
		private string breakfast;
		private string lunch;
		private string dinner;
		private string all;
		private string clear;

		private RadioGroup()
		{ }

		public static ISnack Get()
		{
			return new RadioGroup();
		}

		public IBreakfast SetSnack(string snack)
		{
			this.snack = snack;
			return this;
		}

		public ILunch SetBreakfast(string breakfast)
		{
			this.breakfast = breakfast;
			return this;
		}

		public IDinner SetLunch(string lunch)
		{
			this.lunch = lunch;
			return this;
		}

		public IAll SetDinner(string dinner)
		{
			this.dinner = dinner;
			return this;
		}
		public IClear SetAll(string all)
		{
			this.all = all;
			return this;
		}

		public IRadioGroupBuilder SetClear(string clear)
		{
			this.clear = clear;
			return this;
		}

		public IRadioGroup Build()
		{
			return this;
		}
			
		public string GetSnack()
		{
			return snack;
		}

		public string GetBreakfast()
		{
			return breakfast;
		}

		public string GetLunch()
		{
			return lunch;
		}

		public string GetDinner()
		{
			return dinner;
		}

		public string GetAll()
		{
			return all;
		}

		public string GetClear()
		{
			return clear;
		}

	}

}
