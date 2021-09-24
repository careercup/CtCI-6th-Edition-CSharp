using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_02_Word_Frequencies
{
	// 重複查詢
	// 建立字典，讓之後查詢變成 O(1)
	// Time complexity: O(n)
	// Space complexity: O(n)
	public class Q16_02_Word_FrequenciesB : Question
    {
		public static Dictionary<string, int> SetupDictionary(string[] book)
		{
			Dictionary<string, int> table = new Dictionary<string, int>();
			foreach (string word in book)
			{
				var w= word.ToLower();
				if (w.Trim() != "")
				{
					if (!table.ContainsKey(w))
					{
						table[w] = 0;
					}
					table[w]++;
				}
			}
			return table;
		}
		public static int GetFrequency(Dictionary<string, int> table, string word)
		{
			if (table == null || word == null)
			{
				return -1;
			}
			word = word.ToLower();
			if (table.ContainsKey(word))
			{
				return table[word];
			}
			return 0;
		}

		public override void Run()
        {
			string[] wordlist = AssortedMethods.GetLongTextBlobAsStringList();
			Dictionary<string, int> dictionary = SetupDictionary(wordlist);

			string[] words = { "the", "Lara", "and", "outcropping", "career", "it" };
			foreach (string word in words)
			{
				Console.WriteLine(word + ": " + GetFrequency(dictionary, word));
			}
		}
    }
}
