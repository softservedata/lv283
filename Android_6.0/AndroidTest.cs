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

		[Test, TestCaseSource(nameof(RadioGroupData))]
		public void CheckRadioGroup(IRadioGroup radioGroup)
		{
			HomePage home = new HomePage(driver);
			ViewsPage views = home.GoToViewsPage();
			RadioGroupPage radioGroupPage = views.GoToRadioGroupPage();

			radioGroupPage.RadioSnack.Click();
			Assert.AreEqual(radioGroup.GetSnack(), radioGroupPage.Actual.Text);
			radioGroupPage.RadioBreakfast.Click();
			Assert.AreEqual(radioGroup.GetBreakfast(), radioGroupPage.Actual.Text);
			radioGroupPage.RadioLunch.Click();
			Assert.AreEqual(radioGroup.GetLunch(), radioGroupPage.Actual.Text);
			radioGroupPage.RadioDinner.Click();
			Assert.AreEqual(radioGroup.GetDinner(), radioGroupPage.Actual.Text);
			radioGroupPage.RadioAll.Click();
			Assert.AreEqual(radioGroup.GetAll(), radioGroupPage.Actual.Text);
			radioGroupPage.ButtonClear.Click();
			Assert.AreEqual(radioGroup.GetClear(), radioGroupPage.Actual.Text);
		}

		private static readonly object[] TimeData =
		{
			new object[] { TimeRepository.Get().GroupTimeFive() },
			new object[] { TimeRepository.Get().GroupTimeSeven() },
			new object[] { TimeRepository.Get().GroupTimeTen() }
			//new object[] { TimeRepository.Get().GroupTimeTwelve() },
			//new object[] { TimeRepository.Get().GroupTimeEleven() },
		 //   new object[] { TimeRepository.Get().GroupTimeFirst() }
		};

		[Test, TestCaseSource(nameof(TimeData))]
		public void CheckInline(ITime time)
		{
			HomePage home = new HomePage(driver);
			ViewsPage views = home.GoToViewsPage();
			DateWidgetsPage dateWidgets = views.GoToDateWidgetsPage();
			InlinePage inlinePage = dateWidgets.GoToInlinePage();
			inlinePage.GhangeTime(time.GetHour(), time.GetMinute());
			Assert.AreEqual(time.GetHour(), inlinePage.Hours.Text);
			Assert.AreEqual(time.GetMinute(), inlinePage.Minutes.Text);

		}


	}
}
