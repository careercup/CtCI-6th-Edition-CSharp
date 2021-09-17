using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_02_Word_Frequencies
{
	// 單一查詢
	// Time complexity: O(n)

	public class Q16_02_Word_FrequenciesA : Question
    {
		public static int GetFrequency(string[] book, string word)
		{
			word = word.Trim().ToLower();
			int count = 0;
			foreach (string w in book)
			{
				if (w.Trim().ToLower().Equals(word))
				{
					count++;
				}
			}
			return count;
		}

		public override void Run()
        {
			string[] wordlist = AssortedMethods.GetLongTextBlobAsstringList();

			string[] words = { "the", "Lara", "and", "outcropping", "career", "it" };
			foreach (string word in words)
			{
				Console.WriteLine(word + ": " + GetFrequency(wordlist, word));
			}
		}
    }
}
