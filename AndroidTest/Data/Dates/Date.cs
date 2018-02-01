using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTest.Data.Dates
{

    public enum Month { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

    public interface IMonth
    {
        IDay SetMonth(Month month);
    }

    public interface IDay
    {
        IYear SetDay(string day);
    }

    public interface IYear : IDateBuilder
    {
        IDateBuilder SetYear(string year);
    }


    public interface IDateBuilder
    {
        IDate Build();
    }

    public interface IDate
    {
        Month GetMonth();
        string GetDay();
        string GetYear();
    }

    public class Date : IMonth, IDay, IYear, IDateBuilder, IDate
    {
        private Month month;
        private string day;
        private string year;

        private Date() { }

        public static IMonth Get()
        {
            return new Date();
        }
        
        public IDay SetMonth(Month month)
        {
            this.month = month;
            return this;
        }

        public IYear SetDay(string day)
        {
            this.day = day;
            return this;
        }
        
        public IDateBuilder SetYear(string year)
        {
            this.year = year;
            return this;
        }

        public IDate Build()
        {
            return this;
        }

        public Month GetMonth()
        {
            return month;
        }

        public string GetDay()
        {
            return day;
        }

        public string GetYear()
        {
            return year;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}", (int)month+1, day, year);
        }
    }
}
