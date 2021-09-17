using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_18_Pattern_Matcher
{
	// 暴力解
	// Time complexity: O(n^4)
	public class Q16_18_Pattern_MatcherA : Question
    {
		public static bool DoesMatchA(string pattern, string value)
		{
			if (pattern.Length == 0) return value.Length == 0;
			int size = value.Length;

			for (int mainSize = 0; mainSize <= size; mainSize++)
			{
				string main = value.Substring(0, mainSize);
				for (int altStart = mainSize; altStart <= size; altStart++)
				{
					for (int altEnd = altStart; altEnd <= size; altEnd++)
					{
						string alt = value.Substring(altStart, altEnd - altStart);
						string cand = BuildFromPattern(pattern, main, alt);
						if (cand.Equals(value))
						{
							Console.WriteLine(main + ", " + alt);
							return true;
						}
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
				Console.WriteLine(pattern + ", " + value + ": " + DoesMatchA(pattern, value));
			}
		}
    }
}
