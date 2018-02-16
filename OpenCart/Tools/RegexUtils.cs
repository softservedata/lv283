using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpenCart.Tools
{
    public sealed class RegexUtils
    {
        private RegexUtils()
        {
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
                // TODO Develop Custom Exception
                throw new Exception("Digits not Found in " + text);
            }
            foreach (string current in collectionNumbers)
            {
                result.Add(Convert.ToInt32(current));
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
                // TODO Develop Custom Exception
                throw new Exception("Double Type not Found in " + text);
            }
            foreach (string current in collectionNumbers)
            {
                result.Add(Convert.ToDouble(current));
            }
            return result;
        }

        public static double ExtractFirstDouble(string text)
        {
            return ExtractDoubles(text)[0];
        }

    }
}
