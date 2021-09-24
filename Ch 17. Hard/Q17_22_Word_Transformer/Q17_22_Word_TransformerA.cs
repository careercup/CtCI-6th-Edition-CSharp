using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_22_Word_Transformer
{
	// 暴力解
	// DFS
	public class Q17_22_Word_TransformerA : Question
    {
		public static LinkedList<string> TransformA(string start, string stop, string[] words)
		{
			HashSet<string> dict = SetupDictionary(words);
			HashSet<string> visited = new HashSet<string>();
			return Transform(visited, start, stop, dict);
		}

		public static HashSet<string> SetupDictionary(string[] words)
		{
			HashSet<string> hash = new HashSet<string>();
			foreach (string word in words)
			{
				hash.Add(word.ToLower());
			}
			return hash;
		}

		public static LinkedList<string> Transform(HashSet<string> visited, string startWord, string stopWord, HashSet<string> dictionary)
		{
			if (startWord.Equals(stopWord))
			{
				LinkedList<string> path = new LinkedList<string>();
				path.AddLast(startWord);
				return path;
			}
			else if (visited.Contains(startWord) || !dictionary.Contains(startWord))
			{
				return null;
			}

			visited.Add(startWord);
			IList<string> words = WordsOneAway(startWord);

			foreach (string word in words)
			{
				LinkedList<string> path = Transform(visited, word, stopWord, dictionary);
				if (path != null)
				{
					path.AddFirst(startWord);
					return path;
				}
			}

			return null;
		}

		public static IList<string> WordsOneAway(string word)
		{
			IList<string> words = new List<string>();
			for (int i = 0; i < word.Length; i++)
			{
				for (char c = 'a'; c <= 'z'; c++)
				{
					string w = word.Substring(0, i) + c + word.Substring(i + 1);
					words.Add(w);
				}
			}
			return words;
		}

		public override void Run()
        {
			string[] words = { "maps", "tan", "tree", "apple", "cans", "help", "aped", "pree", "pret", "apes", "flat", "trap", "fret", "trip", "trie", "frat", "fril" };
			LinkedList<string> list = TransformA("tree", "flat", words);

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
