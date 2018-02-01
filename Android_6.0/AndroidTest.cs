using System.Threading;
using NUnit.Framework;
using Android_6._0.Pages;
using Android_6._0.Data.RadioGroups;
using Android_6._0.Data.Times;
using Android_6._0.CreateData;


namespace Android_6._0
{
	[TestFixture]
	public class AndroidTest:TestRunner
	{
		RandomString randomString = new RandomString();

		private static readonly object[] RadioGroupData =
		{
			new object[] { RadioGroupRepository.Get().Group() }
		};

		[Test, Order(1), TestCaseSource(nameof(RadioGroupData))]
		public void CheckRadioGroup(IRadioGroup radioGroup)
		{
			HomePage home = new HomePage(driver);
			ViewsPage views = home.GoToViewsPage();
			RadioGroupPage radioGroupPage = views.GoToRadioGroupPage();

			radioGroupPage.RadioSnack.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetSnack());

			radioGroupPage.RadioBreakfast.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetBreakfast());

			radioGroupPage.RadioLunch.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetLunch());

			radioGroupPage.RadioDinner.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetDinner());

			radioGroupPage.RadioAll.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetAll());

			radioGroupPage.ButtonClear.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetClear());
			Back();
			Back();
		}

		private static readonly object[] TimeData =
		{
					new object[] { TimeRepository.Get().GroupTime() }
					//new object[] { RadioGroupRepository.Get().Breakfast() },
					//new object[] { RadioGroupRepository.Get().Lunch() },
					//new object[] { RadioGroupRepository.Get().Dinner() },
					//new object[] { RadioGroupRepository.Get().AllOfThem() },
					//new object[] { RadioGroupRepository.Get().None() }
		};

		[Test, Order(2), TestCaseSource(nameof(TimeData))]
		//public void CheckInline([Range(1, 12)] int h, [Range(0, 59)] int m)
		public void CheckInline(ITime time)
		{
			HomePage home = new HomePage(driver);
			ViewsPage views = home.GoToViewsPage();
			DateWidgetsPage dateWidgets = views.GoToDateWidgetsPage();
			InlinePage inlinePage = dateWidgets.GoToInlinePage();
			inlinePage.GhangeTime(time.GetHour(), time.GetMinute());
			Back();
			Back();
			Back();
		}


	}
}
