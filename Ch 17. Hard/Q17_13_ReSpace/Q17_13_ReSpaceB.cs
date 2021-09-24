using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_13_ReSpace
{
	// 最佳化
	// 使用 memo表(cache)
	// Time complexity: O(n^2)
	// n: 字元數目
	public class Q17_13_ReSpaceB : Question
    {
		public static string BestSplitB(HashSet<string> dictionary, string sentence)
		{
			ParseResult[] memo = new ParseResult[sentence.Length];
			ParseResult r = Split(dictionary, sentence, 0, memo);
			return r?.Parsed;
		}

		public static ParseResult Split(HashSet<string> dictionary, string sentence, int start, ParseResult[] memo)
		{
			if (start >= sentence.Length)
			{
				return new ParseResult(0, "");
			}
			if (memo[start] != null)
			{
				return memo[start];
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
					ParseResult result = Split(dictionary, sentence, index + 1, memo);
					if (invalid + result.Invalid < bestInvalid)
					{
						bestInvalid = invalid + result.Invalid;
						bestParsing = partial + " " + result.Parsed;
						if (bestInvalid == 0) break; // Short circuit
					}
				}

				index++;
			}
			memo[start] = new ParseResult(bestInvalid, bestParsing);
			return memo[start];
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
			Console.WriteLine(BestSplitB(dictionary, sentence));
		}
    }
}
