using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.Data.Times
{
	public interface IMeridiem
	{
		IHour SetMeridiem(string meridiem);
	}

	public interface IHour 
	{
		IMinute SetHour(string hour);
	}

	public interface IMinute
	{
		ITimeBuilder SetMinute(string minute);
	}

	public interface ITimeBuilder
	{
		ITime Build();
	}
	
	public interface ITime
	{
		string GetMeridiem();
		string GetHour();
		string GetMinute();
	}
	
	public class Time : IMeridiem, IHour, IMinute,
		                ITimeBuilder, ITime
	{
		private string meridiem;
		private string hour;
		private string minute;

		private Time()
		{
		}

		public static IMeridiem Get()
		{
			return new Time();
		}

		public IHour SetMeridiem(string meridiem)
		{
			this.meridiem = meridiem;
			return this;
		}

		public IMinute SetHour(string hour)
		{
			this.hour = hour;
			return this;
		}

		public ITimeBuilder SetMinute(string minute)
		{
			this.minute = minute;
			return this;
		}

		public ITime Build()
		{
			return this;
		}

		public string GetMeridiem()
		{
			return meridiem;
		}
		public string GetHour()
		{
			return hour;
		}

		public string GetMinute()
		{
			return minute;
		}

	}
}
