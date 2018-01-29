using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_6._0.Data.RadioGroups
{
	public class RadioGroupRepository
	{
		private volatile static RadioGroupRepository instance;
		private static object lockingObject = new object();

		private RadioGroupRepository()
		{
		}

		public static RadioGroupRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new RadioGroupRepository();
					}
				}
			}
			return instance;
		}

		//
		public IRadioGroup Group()
		{
			return RadioGroup.Get()
				.SetSnack("2131296259")
				.SetBreakfast("2131296533")
				.SetLunch("2131296531")
				.SetDinner("2131296534")
				.SetAll("2131296535")
				.SetClear("(none)")
				.Build();
		}



		////
		//public IRadioGroup Snack()
		//{
		//	return RadioGroup.Get()
		//		.SetName("Snack")
		//		.SetId("2131296259")
		//		.Build();
		//}

		//public IRadioGroup Breakfast()
		//{
		//	return RadioGroup.Get()
		//		.SetName("Breakfast")
		//		.SetId("2131296533")
		//		.Build();
		//}

		//public IRadioGroup Lunch()
		//{
		//	return RadioGroup.Get()
		//		.SetName("Lunch")
		//		.SetId("2131296531")
		//		.Build();
		//}

		//public IRadioGroup Dinner()
		//{
		//	return RadioGroup.Get()
		//		.SetName("Dinner")
		//		.SetId("2131296534")
		//		.Build();
		//}

		//public IRadioGroup AllOfThem()
		//{
		//	return RadioGroup.Get()
		//		.SetName("AllOfThem")
		//		.SetId("2131296565")
		//		.Build();
		//}

		//public IRadioGroup None()
		//{
		//	return RadioGroup.Get()
		//		.SetName("None")
		//		.SetId("(none)")
		//		.Build();
		//}

	}
}
