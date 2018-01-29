using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.Data.RadioGroups
{
	public interface IName : IRadioGroupBuilder
	{
		IId SetName(string name);
	}

	public interface IId : IRadioGroupBuilder
	{
		IRadioGroupBuilder SetId(string id);
	}

	public interface IRadioGroupBuilder
	{
		IRadioGroup Build();
	}

	public interface IRadioGroup
	{
		string GetName();
		string GetId();
	}

	public class RadioGroup : IName, IId, IRadioGroupBuilder,
		                      IRadioGroup
	{
		private string name;
		private string id;


		private RadioGroup()
		{ }

		public static IName Get()
		{
			return new RadioGroup();
		}

		public IId SetName(string name)
		{
			this.name = name;
			return this;
		}

		public IRadioGroupBuilder SetId(string id)
		{
			this.id = id;
			return this;
		}

		public IRadioGroup Build()
		{
			return this;
		}
			
		public string GetName()
		{
			return name;
		}

		public string GetId()
		{
			return id;
		}

	}

}
