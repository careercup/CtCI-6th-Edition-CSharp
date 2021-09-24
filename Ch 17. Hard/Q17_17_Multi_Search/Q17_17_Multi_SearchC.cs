using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_17_Multi_Search
{
	// 方案3
	// Total:
	// Time complexity: O(kt + bk)
	// 建構 Trie:
	// Time complexity: O(kt)
	// 搜尋位置:
	// Time complexity: O(bk)
	// k: T 中(陣列中)的最長字串長度
	// b: 較大字串的長度(big)
	// t: T (陣列)的數量
	// 方案1 為 O(kbt)。O(kt + bk) 比 O(kbt) 快
	// 方案2 為 O(b^2 + kt)。由於 b 一定 大於 k(若不是，則我們知道不能從 b 找到 k)，
	// 方案3 也比 方案2 快
	public class Q17_17_Multi_SearchC : Question
    {
		public static DictionaryList<string, int> SearchAllC(string big, string[] smalls)
		{
			DictionaryList<string, int> lookup = new DictionaryList<string, int>();
			TrieNode root = CreateTreeFromStrings(smalls, big.Length).GetRoot();

			for (int i = 0; i < big.Length; i++)
			{
				IList<string> strings = FindStringsAtLoc(root, big, i);
				InsertIntoHashMap(strings, lookup, i);
			}

			return lookup;
		}

		public static Trie CreateTreeFromStrings(string[] smalls, int maxSize)
		{
			Trie tree = new Trie();
			foreach (string s in smalls)
			{
				if (s.Length <= maxSize)
				{
					tree.InsertString(s, 0);
				}
			}
			return tree;
		}

		public static IList<string> FindStringsAtLoc(TrieNode root, string big, int start)
		{
			IList<string> strings = new List<string>();
			int index = start;
			while (index < big.Length)
			{
				root = root.GetChild(big[index]);
				if (root == null) break;
				if (root.Terminates())
				{
					strings.Add(big.Substring(start, index + 1 - start));
				}
				index++;
			}
			return strings;
		}

		public static void InsertIntoHashMap(IList<string> strings, DictionaryList<string, int> map, int index)
		{
			foreach (string s in strings)
			{
				map.Add(s, index);
			}
		}

		

		public override void Run()
        {
			string big = "mississippi";
			string[] smalls = { "is", "ppi", "hi", "sis", "i", "mississippi" };
			DictionaryList<string, int> locations = SearchAllC(big, smalls);
			Console.WriteLine(locations.ToString());
		}
    }
}
