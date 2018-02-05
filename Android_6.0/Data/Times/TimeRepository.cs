using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.Data.Times
{
	public class TimeRepository
	{
		private volatile static TimeRepository instance;
		private static object lockingObject = new object();

		private TimeRepository()
		{
		}

		public static TimeRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new TimeRepository();
					}
				}
			}
			return instance;
		}

		/////////////////////
		public ITime GroupTime()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("10")
				.SetMinute("55")
				.Build();
		}

		public ITime GroupTimeTen()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("10")
				.SetMinute("55")
				.Build();
		}

		public ITime GroupTimeSeven()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("7")
				.SetMinute("10")
				.Build();
		}


		public ITime GroupTimeFive()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("5")
				.SetMinute("40")
				.Build();
		}

		public ITime GroupTimeTwelve()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("12")
				.SetMinute("0")
				.Build();
		}

		public ITime GroupTimeFirst()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("1")
				.SetMinute("5")
				.Build();
		}

		public ITime GroupTimeEleven()
		{
			return Time.Get()
				.SetMeridiem("pm")
				.SetHour("11")
				.SetMinute("55")
				.Build();
		}

	}
}
