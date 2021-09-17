using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_18_Pattern_Matcher
{
    public class Q16_18_Pattern_MatcherB : Question
    {
        public static bool DoesMatchB(string pattern, string value)
        {
            if (pattern.Length == 0) return value.Length == 0;

            pattern = Canonical(pattern);

            int countOfAs = CountOf(pattern, 'a');
            int countOfBs = pattern.Length - countOfAs;
            int firstB = pattern.IndexOf('b');

            for (int aSize = 0; aSize <= value.Length / countOfAs; aSize++)
            {
                int remainingLength = value.Length - aSize * countOfAs;
                string first = value.Substring(0, aSize);
                if (countOfBs == 0 || remainingLength % countOfBs == 0)
                {
                    int bIndex = firstB * aSize;
                    int bSize = countOfBs == 0 ? 0 : remainingLength / countOfBs;
                    string second = countOfBs == 0 ? "" : value.Substring(bIndex, bSize);

                    string candidate = FormStringFromPattern(pattern, first, second);

                    if (candidate.Equals(value))
                    {
                        Console.WriteLine(first + ", " + second);
                        return true;
                    }
                }
            }
            return false;
        }


        public static string FormStringFromPattern(string pattern, string first, string second)
        {
            if (pattern.Length == 0) return null;

            StringBuilder sb = new StringBuilder();
            char firstChar = pattern[0];
            foreach (char c in pattern)
            {
                if (c == firstChar)
                {
                    sb.Append(first);
                }
                else if (c != firstChar)
                {
                    sb.Append(second);
                }
                else
                {
                    return null;
                }
            }
            return sb.ToString();
        }

        public static int CountOf(string pattern, char ch)
        {
            int count = 0;
            foreach (char c in pattern)
            {
                if (c == ch)
                {
                    count++;
                }
            }
            return count;
        }

        public static string Canonical(string pattern)
        {
            if (pattern[0] == 'a') return pattern;
            StringBuilder sb = new StringBuilder();
            foreach (char c in pattern)
            {
                if (c == 'a')
                {
                    sb.Append('b');
                }
                else
                {
                    sb.Append('a');
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
                Console.WriteLine(pattern + ", " + value + ": " + DoesMatchB(pattern, value));
            }
        }
    }
}
