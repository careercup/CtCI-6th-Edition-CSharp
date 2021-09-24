using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_13_ReSpace
{
	// 暴力解
	// Time complexity: O(2^n)
	// n: 字元數目
	public class Q17_13_ReSpaceA : Question
    {
		public static string BestSplitA(HashSet<string> dictionary, string sentence)
		{
			ParseResult r = Split(dictionary, sentence, 0);
			return r?.Parsed;
		}

		public static ParseResult Split(HashSet<string> dictionary, string sentence, int start)
		{
			if (start >= sentence.Length)
			{
				return new ParseResult(0, "");
			}

			int bestInvalid = int.MaxValue;
			string bestParsing = null;

			string partial = "";
			int index = start;
			while (index < sentence.Length)
			{
				char c = sentence[index];
				partial += c;
				int invalid = dictionary.Contains(partial) ? 0 :
					partial.Length;
				if (invalid < bestInvalid)
				{   
					// Short circuit
					/* Recurse, putting a space after this character. If this
					 * is better than the current best option, replace the best
					 * option. */
					ParseResult result = Split(dictionary, sentence, index + 1);
					if (invalid + result.Invalid < bestInvalid)
					{
						bestInvalid = invalid + result.Invalid;
						bestParsing = partial + " " + result.Parsed;
						if (bestInvalid == 0) break;
					}
				}

				index++;
			}
			return new ParseResult(bestInvalid, bestParsing);
		}


		public static string Clean(string str)
		{
			char[] punctuation = { ',', '"', '!', '.', '\'', '?', ',' };
			foreach (char c in punctuation)
			{
				str = str.Replace(c, ' ');
			}
			return str.Replace(" ", "").ToLower();
		}

		public override void Run()
        {
			HashSet<string> dictionary = new HashSet<string>(AssortedMethods.GetListOfWords());
			string sentence = "As one of the top companies in the world, Google"; // will surely attract the attention of computer gurus. This does not, however, mean the company is for everyone.";
			sentence = Clean(sentence);
			Console.WriteLine(sentence);
			Console.WriteLine(BestSplitA(dictionary, sentence));
		}
    }
}
