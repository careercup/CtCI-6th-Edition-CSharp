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
	// 相較於"方案C"的好處是不符時(通常不符)可提早跳出。
	// "方案C"演算法在知道不符前必須完整建構字串
	// 但"方案C"比較清楚
	public class Q16_18_Pattern_MatcherD : Question
    {
		public static bool DoesMatchD(string pattern, string value)
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
				if (countOfAlt == 0 || remainingLength % countOfAlt == 0)
				{
					int altIndex = firstAlt * mainSize;
					int altSize = countOfAlt == 0 ? 0 : remainingLength / countOfAlt;
					if (Matches(pattern, value, mainSize, altSize, altIndex))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool Matches(string pattern, string value, int mainSize, int altSize, int firstAlt)
		{
			int stringIndex = mainSize;
			for (int i = 1; i < pattern.Length; i++)
			{
				int size = pattern[i] == pattern[0] ? mainSize : altSize;
				int offset = pattern[i] == pattern[0] ? 0 : firstAlt;
				if (!IsEqual(value, offset, stringIndex, size))
				{
					return false;
				}
				stringIndex += size;
			}
			return true;
		}

		public static bool IsEqual(string s1, int offset1, int offset2, int size)
		{
			for (int i = 0; i < size; i++)
			{
				if (s1[offset1 + i] != s1[offset2 + i])
				{
					return false;
				}
			}
			return true;
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
                Console.WriteLine(pattern + ", " + value + ": " + DoesMatchD(pattern, value));
            }
        }
    }
}
