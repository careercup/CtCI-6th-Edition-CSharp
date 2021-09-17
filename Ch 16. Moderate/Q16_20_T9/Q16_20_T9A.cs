using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_20_T9
{
    // 暴力解
    // Time complexity: O(4^N)
    // N: 字串長度 
    public class Q16_20_T9A : Question
    {
        public static char[][] t9Letters = {
            null, 								// 0
			null, 								// 1
			new char[] {'a', 'b', 'c'}, 		// 2
			new char[] {'d', 'e', 'f'}, 		// 3
			new char[] {'g', 'h', 'i'}, 		// 4
			new char[] {'j', 'k', 'l'},			// 5
			new char[] {'m', 'n', 'o'},			// 6
			new char[] {'p', 'q', 'r', 's'}, 	// 7
			new char[] {'t', 'u', 'v'},			// 8
			new char[] {'w', 'x', 'y', 'z'} 	// 9
	    };

        public static IList<string> GetValidT9WordsA(string number, HashSet<string> wordList)
        {
            IList<string> results = new List<string>();
            GetValidWords(number, 0, "", wordList, results);
            return results;
        }

        public static void GetValidWords(string number, int index, string prefix, HashSet<string> wordSet, IList<string> results)
        {
            /* If it's a complete word, print it. */
            if (index == number.Length)
            {
                if (wordSet.Contains(prefix))
                {
                    results.Add(prefix);
                }
                return;
            }

            /* Get characters that match this digit */
            char digit = number[index];
            char[] letters = getT9Chars(digit);

            /* Go through all remaining options. */
            if (letters != null)
            {
                foreach (char letter in letters)
                {
                    GetValidWords(number, index + 1, prefix + letter, wordSet, results);
                }
            }
        }

        public static char[] getT9Chars(char digit)
        {
            if (!char.IsDigit(digit))
            {
                return null;
            }
            int dig = digit - '0';
            return t9Letters[dig];
        }


        public override void Run()
        {
            IList<string> words = GetValidT9WordsA("33835676368", new HashSet<string>(AssortedMethods.GetListOfWords()));
            foreach (string w in words)
            {
                Console.WriteLine(w);
            }
        }
    }
}
