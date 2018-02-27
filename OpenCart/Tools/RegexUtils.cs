﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OpenCart.Tools
{
	public sealed class RegexUtils
	{
		private RegexUtils()
		{
		}

		public static double DoubleParseCulture(string text)
		{
			NumberFormatInfo format = new NumberFormatInfo();
			format.NumberDecimalSeparator = ".";
			return Double.Parse(text, format);
		}

		public static MatchCollection ExtractMatchCollection(string pattern, string text)
		{
			Regex regexPattern = new Regex(pattern, RegexOptions.IgnoreCase);
			return regexPattern.Matches(text);
		}

		public static List<int> ExtractNumbers(string text)
		{
			List<int> result = new List<int>();
			MatchCollection collectionNumbers = ExtractMatchCollection(@"\d+", text);
			if (collectionNumbers.Count == 0)
			{
				throw new Exception("Digits not Found in " + text);
			}
			foreach (Match current in collectionNumbers)
			{
				result.Add(Convert.ToInt32(current.Value));
			}
			return result;
		}

		public static int ExtractFirstNumber(string text)
		{
			return ExtractNumbers(text)[0];
		}

		public static List<double> ExtractDoubles(string text)
		{
			List<double> result = new List<double>();
			MatchCollection collectionNumbers = ExtractMatchCollection(@"\d+\.\d+", text);
			if (collectionNumbers.Count == 0)
			{
				throw new Exception("Double Type not Found in " + text);
			}

			foreach (Match current in collectionNumbers)
			{
				result.Add(DoubleParseCulture(current.Value));
			}
			return result;
		}

		public static double ExtractFirstDouble(string text)
		{
			return ExtractDoubles(text)[0];
		}

		public static List<string> ExtractStrings(string text)
		{
			List<string> result = new List<string>();
			MatchCollection collectionNumbers = ExtractMatchCollection(@"[a-zA-Z ]", text);
			if (collectionNumbers.Count == 0)
			{
				throw new Exception("String not Found in " + text);
			}
			foreach (Match current in collectionNumbers)
			{
				result.Add(current.Value);
			}
			return result;
		}

		public static List<string> ExtractEmail(string text)
		{
			List<string> result = new List<string>();
			MatchCollection collectionNumbers = ExtractMatchCollection(@"[a-zA-Z] ", text);
			if (collectionNumbers.Count == 0)
			{
				throw new Exception("String not Found in " + text);
			}
			foreach (Match current in collectionNumbers)
			{
				result.Add(current.Value);
			}
			return result;
		}

		public static string ExtractFirstString(string text)
		{
			return ExtractStrings(text)[0];
		}

	}
}