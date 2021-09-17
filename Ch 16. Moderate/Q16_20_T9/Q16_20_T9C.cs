using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_20_T9
{
	// 最最佳化
	// 取得對應此數字的字需要 O(N)時間
	// N: 數字長度
	// O(N)來自雜湊表查詢(必須轉換數字到雜湊表)
    public class Q16_20_T9C : Question
    {
		public static int numLetters = 26;

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

		public static IList<string> GetValidT9WordsC(string numbers, DictionaryList<string, string> dictionary)
		{
			return dictionary.Get(numbers);
		}

		


		/* Create a hash table that maps from a number to all words that
		 * have this numerical representation. */
		public static DictionaryList<string, string> InitializeDictionary(string[] words)
		{
			/* Create hash table that maps from a letter to the digit */
			Dictionary<char, char> letterToNumberMap = CreateLetterToNumberMap();

			/* Create word -> number map */
			DictionaryList<string, string> wordsToNumbers = new DictionaryList<string, string>();
			foreach (string word in words)
			{
				string numbers = ConvertToT9(word, letterToNumberMap);
				wordsToNumbers.Add(numbers, word);
			}
			return wordsToNumbers;
		}

		/* Convert mapping of number->letters into letter->number */
		public static Dictionary<char, char> CreateLetterToNumberMap()
		{
			Dictionary<char, char> letterToNumberMap = new Dictionary<char, char>();
			for (int i = 0; i < t9Letters.Length; i++)
			{
				char[] letters = t9Letters[i];
				if (letters != null)
				{
					foreach (char letter in letters)
					{
						char c = (char)(i + '0');
						letterToNumberMap[letter] = c;
					}
				}
			}
			return letterToNumberMap;
		}

		/* Convert from a string to its T9 representation. */
		public static string ConvertToT9(string word, Dictionary<char, char> letterToNumberMap)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in word)
			{
				if (letterToNumberMap.ContainsKey(c))
				{
					char digit = letterToNumberMap[c];
					sb.Append(digit);
				}
			}
			return sb.ToString();
		}

		public override void Run()
        {
			DictionaryList<string, string> dictionary = InitializeDictionary(AssortedMethods.GetListOfWords());
			IList<string> words = GetValidT9WordsC("8733", dictionary);
			foreach (string w in words)
			{
				Console.WriteLine(w);
			}
		}
    }
}
