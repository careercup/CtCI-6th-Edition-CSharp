using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_18_Pattern_Matcher
{
	// 最佳化
	// Time complexity: O(n^2)
	// 迭代O(n)個可能的主字串並執行O(n)步驟來建構與比較字串
	public class Q16_18_Pattern_MatcherC : Question
    {
		public static bool DoesMatchC(string pattern, string value)
		{
			if (pattern.Length == 0) return value.Length == 0;

			char mainChar = pattern[0];
			char altChar = mainChar == 'a' ? 'b' : 'a';
			int size = value.Length;

			int countOfMain = CountOf(pattern, mainChar);
			int countOfAlt = pattern.Length - countOfMain;
			int firstAlt = pattern.IndexOf(altChar);
			int maxMainSize = size / countOfMain;

			for (int mainSize = 0; mainSize <= maxMainSize; mainSize++)
			{
				int remainingLength = size - mainSize * countOfMain;
				string first = value.Substring(0, mainSize);
				if (countOfAlt == 0 || remainingLength % countOfAlt == 0)
				{
					int altIndex = firstAlt * mainSize;
					int altSize = countOfAlt == 0 ? 0 : remainingLength / countOfAlt;
					string second = countOfAlt == 0 ? "" : value.Substring(altIndex, altSize);

					string candidate = BuildFromPattern(pattern, first, second);

					if (candidate.Equals(value))
					{
						Console.WriteLine(first + ", " + second);
						return true;
					}
				}
			}
			return false;
		}

		public static string BuildFromPattern(string pattern, string main, string alt)
		{
			StringBuilder sb = new StringBuilder();
			char first = pattern[0];
			foreach (char c in pattern)
			{
				if (c == first)
				{
					sb.Append(main);
				}
				else
				{
					sb.Append(alt);
				}
			}
			return sb.ToString();
		}

		public static int CountOf(string pattern, char c)
		{
			int count = 0;
			for (int i = 0; i < pattern.Length; i++)
			{
				if (pattern[i] == c)
				{
					count++;
				}
			}
			return count;
		}

		

		public override void Run()
        {
            string[][] tests = {
                new string[] { "ababb", "backbatbackbatbat" },
                new string[] { "abab", "backsbatbackbats" },
                new string[] { "aba", "backsbatbacksbat" }
            };
            foreach (string[] test in tests)
            {
                string pattern = test[0];
                string value = test[1];
                Console.WriteLine(pattern + ", " + value + ": " + DoesMatchC(pattern, value));
            }
        }
    }
}
