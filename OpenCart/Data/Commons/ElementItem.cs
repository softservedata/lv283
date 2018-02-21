using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Commons
{
	public class ElementItem
	{
		public string Name { get; private set; }
		public int Count { get; private set; }
		public ElementItem(string name, int count)
		{
			this.Name = name;
			this.Count = count;
		}
	}
}
