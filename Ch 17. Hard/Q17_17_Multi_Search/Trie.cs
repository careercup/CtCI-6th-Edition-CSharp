using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_17_Multi_Search
{
	public class Trie
	{
		private TrieNode root = new TrieNode();

		public IList<int> Search(string s)
		{
			return root.Search(s);
		}

		public void InsertString(string str, int location)
		{
			root.InsertString(str, location);
		}

		public TrieNode GetRoot()
		{
			return root;
		}
	}
}
