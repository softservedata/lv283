using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
	public class EditAccountPage : AColumnRightUserComponent
	{
		public IWebElement FirstNameField
		{ get { return Search.Id("input-firstname"); } }

		public EditAccountPage() : base() { }

		// FirstNameField
		public string GetFirstNameFieldText()
		{
			return FirstNameField.GetAttribute(TAG_ATTRIBUTE_VALUE);
		}

		public void ClickFirstNameField()
		{
			FirstNameField.Click();
		}
	}
}
