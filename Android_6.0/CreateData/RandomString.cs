using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.CreateData
{
	public class RandomString
	{
		public string GetRandomString(int size)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random();
			char ch;
			for (int i = 0; i < size; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);
			}
			return builder.ToString();
		}

		public string GetRandomInt(int size)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random();
			string data;
			data = random.Next(size).ToString();
			return data;
		}
	}
}
