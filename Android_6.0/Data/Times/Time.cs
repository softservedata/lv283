using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.Data.Times
{
	public interface IM : ITimeBuilder
	{
		IHour SeP(string p);
	}

	public interface IHour : ITimeBuilder
	{
		IMinute SetHour(string hour);
	}

	public interface IMinute : ITimeBuilder
	{
		ITimeBuilder SetMinute(string minute);
	}

	public interface ITimeBuilder
	{
		ITime Build();
	}


	public interface ITime
	{
		string GetP();
		string GetHour();
		string GetMinute();

	}


	public class Time
	{
		private Time()
		{

		}

		public static IM Get()
		{
			return new Time();
		}



	}
}
