using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart.Tools
{
	public sealed class FlexAssert
	{

		public const string APPEND_TEXT = "\nDescription: {0}";
		public const string ERROR_ASSERT_MESSAGE = "\n{0}{1}";
		public const string NEW_LINE = "\n";

		private bool summaryResult;
		private StringBuilder summaryDescription;

		public FlexAssert()
		{
			InitResult();
		}

		public void InitResult()
		{
			this.summaryResult = true;
			this.summaryDescription = new StringBuilder();
		}

		public bool GetPassed()
		{
			return summaryResult;
		}

		public string GetSummaryDescription()
		{
			return summaryDescription.ToString();
		}

		private void Verify(bool pass, string errorText)
		{
		}

		private void AddWarning(string warningText)
		{
			summaryDescription.Append(string.Format(APPEND_TEXT, warningText));
		}


		public void AssertEquals(string actual, string expected)
		{
			try
			{
				Assert.AreEqual(actual, expected);
			}
			catch (Exception e)
			{
				Verify(actual.Equals(expected), string.Format(ERROR_ASSERT_MESSAGE,
						e.ToString()));
			}
		}
	}
}
