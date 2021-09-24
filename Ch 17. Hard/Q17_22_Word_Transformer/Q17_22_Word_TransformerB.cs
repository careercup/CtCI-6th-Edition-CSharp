using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_22_Word_Transformer
{
    // 最佳化方案
	// DFS
    public class Q17_22_Word_TransformerB : Question
    {
		/* find path to transform startWord into endWord. */
		public static LinkedList<string> TransformB(string start, string stop, string[] words)
		{
			DictionaryList<string, string> wildcardToWordList = CreateWildcardToWordMap(words);
			HashSet<string> visited = new HashSet<string>();
			return Transform(visited, start, stop, wildcardToWordList);
		}

		/* Do a depth-first search from start to stop, traveling through each word that is one edit away. */
		public static LinkedList<string> Transform(HashSet<string> visited, string start, string stop, DictionaryList<string, string> wildcardToWordList)
		{
			if (start.Equals(stop))
			{
				LinkedList<string> path = new LinkedList<string>();
				path.AddLast(start);
				return path;
			}
			else if (visited.Contains(start))
			{
				return null;
			}

			visited.Add(start);
			IList<string> words = GetValidLinkedWords(start, wildcardToWordList);

			foreach (string word in words)
			{
				LinkedList<string> path = Transform(visited, word, stop, wildcardToWordList);
				if (path != null)
				{
					path.AddFirst(start);
					return path;
				}
			}

			return null;
		}

		/* Insert words in dictionary into mapping from wildcard form -> word. */
		public static DictionaryList<string, string> CreateWildcardToWordMap(string[] words)
		{
			DictionaryList<string, string> wildcardToWords = new DictionaryList<string, string>();
			foreach (string word in words)
			{
				IList<string> linked = GetWildcardRoots(word);
				foreach (string linkedWord in linked)
				{
					wildcardToWords.Add(linkedWord, word);
				}
			}
			return wildcardToWords;
		}

		/* Get list of wildcards associated with word. */
		public static IList<string> GetWildcardRoots(string w)
		{
			IList<string> words = new List<string>();
			for (int i = 0; i < w.Length; i++)
			{
				string word = w.Substring(0, i) + "_" + w.Substring(i + 1);
				words.Add(word);
			}
			return words;
		}


		/* Return words that are one edit away. */
		public static IList<string> GetValidLinkedWords(string word, DictionaryList<string, string> wildcardToWords)
		{
			IList<string> wildcards = GetWildcardRoots(word);
			IList<string> linkedWords = new List<string>();
			foreach (string wildcard in wildcards)
			{
				IList<string> words = wildcardToWords.Get(wildcard);
				foreach (string linkedWord in words)
				{
					if (!linkedWord.Equals(word))
					{
						linkedWords.Add(linkedWord);
					}
				}
			}
			return linkedWords;
		}

		public override void Run()
        {
			string[] words = { "maps", "tan", "tree", "apple", "cans", "help", "aped", "pree", "pret", "apes", "flat", "trap", "fret", "trip", "trie", "frat", "fril" };
			LinkedList<string> list = TransformB("tree", "flat", words);

			if (list == null)
			{
				Console.WriteLine("No path.");
			}
			else
			{
				for (int i = 0; i < list.Count; i++)
				{
					Console.Write(list.ElementAt(i));
					if (i != list.Count - 1) Console.Write(" -> ");
				}
				Console.WriteLine();
			}
		}
    }
}
