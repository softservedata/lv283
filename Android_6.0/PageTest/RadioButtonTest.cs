//using Android_6._0.Pages;
//using Android_6._0.Data.RadioGroups;

//namespace Android_6._0.PageTest
//{
//	public class RadioButtonTest: TestRunner
//	{

//		public void GoToRadioPage()
//		{
//			HomePage home = new HomePage(driver);
//			ViewsPage views = home.GoToViewsPage();
//			RadioGroupPage radioGroupPage = views.GoToRadioGroupPage();
//		}

//		public void GoToInlinePage()
//		{
//			HomePage home = new HomePage(driver);
//			ViewsPage views = home.GoToViewsPage();
//			DateWidgetsPage dateWidgets = views.GoToDateWidgetsPage();
//			InlinePage inlinePage = dateWidgets.GoToInlinePage();
//		}

//		public void CheckRadioGroups(IRadioGroup radioGroup)
//		{
//			RadioGroupPage radioGroupPage = new RadioGroupPage();
//			radioGroupPage.RadioSnack.Click();
//			radioGroupPage.CheckRadioGroup(radioGroup.GetSnack());

//			radioGroupPage.RadioBreakfast.Click();
//			radioGroupPage.CheckRadioGroup(radioGroup.GetBreakfast());

//			radioGroupPage.RadioLunch.Click();
//			radioGroupPage.CheckRadioGroup(radioGroup.GetLunch());

//			radioGroupPage.RadioDinner.Click();
//			radioGroupPage.CheckRadioGroup(radioGroup.GetDinner());

//			radioGroupPage.RadioAll.Click();
//			radioGroupPage.CheckRadioGroup(radioGroup.GetAll());

//			radioGroupPage.ButtonClear.Click();
//			radioGroupPage.CheckRadioGroup(radioGroup.GetClear());
//		}


//	}
//}
