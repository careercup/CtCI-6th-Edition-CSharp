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
	// 雙向 BFS
	// Time complexity: O(E^(D/2))
	// E: 一個字有 E 個相隔一個修改的字
	// D: 起點與目的地字的距離
	public class Q17_22_Word_TransformerC : Question
    {
		public static LinkedList<string> TransformC(string startWord, string stopWord, string[] words)
		{
			DictionaryList<string, string> wildcardToWordList = GetWildcardToWordList(words);

			BFSData sourceData = new BFSData(startWord);
			BFSData destData = new BFSData(stopWord);

			while (!sourceData.IsFinished() && !destData.IsFinished())
			{
				/* Search out from source. */
				string collision = SearchLevel(wildcardToWordList, sourceData, destData);
				if (collision != null)
				{
					return MergePaths(sourceData, destData, collision);
				}

				/* Search out from destination. */
				collision = SearchLevel(wildcardToWordList, destData, sourceData);
				if (collision != null)
				{
					return MergePaths(sourceData, destData, collision);
				}
			}

			return null;
		}

		/* Search one level and return collision, if any. */
		public static string SearchLevel(DictionaryList<string, string> wildcardToWordList, BFSData primary, BFSData secondary)
		{
			/* We only want to search one level at a time. Count how many nodes are currently in the primary's
			 * level and only do that many nodes. We'll continue to add nodes to the end. */
			int count = primary.ToVisit.Count;
			for (int i = 0; i < count; i++)
			{
				/* Pull out first node. */
				PathNode pathNode = primary.ToVisit.Dequeue();
				string word = pathNode.GetWord();

				/* Check if it's already been visited. */
				if (secondary.Visited.ContainsKey(word))
				{
					return pathNode.GetWord();
				}

				/* Add friends to queue. */
				IList<string> words = GetValidLinkedWords(word, wildcardToWordList);
				foreach (string w in words)
				{
					if (!primary.Visited.ContainsKey(w))
					{
						PathNode next = new PathNode(w, pathNode);
						primary.Visited.Add(w, next);
						primary.ToVisit.Enqueue(next);
					}
				}
			}
			return null;
		}

		public static LinkedList<string> MergePaths(BFSData bfs1, BFSData bfs2, string connection)
		{
			PathNode end1 = bfs1.Visited[connection]; // end1 -> source
			PathNode end2 = bfs2.Visited[connection]; // end2 -> dest
			LinkedList<string> pathOne = end1.Collapse(false); // forward: source -> connection
			LinkedList<string> pathTwo = end2.Collapse(true); // reverse: connection -> dest
			pathTwo.RemoveFirst(); // remove connection
            // add second path
            foreach (var path in pathTwo)
            {
				pathOne.AddLast(path);
            }
			return pathOne;
		}

		

		/* Insert words in dictionary into mapping from wildcard form -> word. */
		public static DictionaryList<string, string> GetWildcardToWordList(string[] words)
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
		public static IList<string> GetWildcardRoots(string word)
		{
			IList<string> words = new List<string>();
			for (int i = 0; i < word.Length; i++)
			{
				string w = word.Substring(0, i) + "_" + word.Substring(i + 1);
				words.Add(w);
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
			LinkedList<string> list = TransformC("tree", "flat", words);

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
