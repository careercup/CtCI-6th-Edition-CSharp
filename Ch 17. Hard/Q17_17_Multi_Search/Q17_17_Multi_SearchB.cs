using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_17_Multi_Search
{
	// 方案2
	// Total:
	// Time complexity: O(b^2 + kt)
	// 建構 Trie:
	// Time complexity: O(b^2)
	// 搜尋位置:
	// Time complexity: O(kt)
	// k: T 中(陣列中)的最長字串長度
	// b: 較大字串的長度(big)
	// t: T (陣列)的數量
	// 若 b 很大，方案1 的 O(kbt) 比較好
	// 但 t 很多，方案2 的 O(b^2 + kt) 可能比較好
	public class Q17_17_Multi_SearchB : Question
    {
		public static DictionaryList<string, int> SearchAllB(string big, string[] smalls)
		{
			DictionaryList<string, int> lookup = new DictionaryList<string, int>();
			Trie tree = CreateTrieFromstring(big);
			foreach (string s in smalls)
			{
				/* Get terminating location of each occurrence.*/
				IList<int> locations = tree.Search(s);

				/* Adjust to starting location. */
				SubtractValue(locations, s.Length);

				/* Insert. */
				lookup.Add(s, locations);
			}

			return lookup;
		}

		public static Trie CreateTrieFromstring(string s)
		{
			Trie trie = new Trie();
			for (int i = 0; i < s.Length; i++)
			{
				string suffix = s.Substring(i);
				trie.InsertString(suffix, i);
			}
			return trie;
		}

		public static void SubtractValue(IList<int> locations, int delta)
		{
			if (locations == null) return;
			for (int i = 0; i < locations.Count; i++)
			{
				locations[i]= locations[i] - delta;
			}
		}

		

		public override void Run()
        {
			string big = "mississippi";
			string[] smalls = { "is", "ppi", "hi", "sis", "i", "mississippi" };
			DictionaryList<string, int> locations = SearchAllB(big, smalls);
			Console.WriteLine(locations.ToString());
		}
    }
}
