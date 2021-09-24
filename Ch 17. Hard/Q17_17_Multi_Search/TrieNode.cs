using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_17_Multi_Search
{
	public class TrieNode
	{
		private Dictionary<char, TrieNode> children;
		private IList<int> indexes;

		public TrieNode()
		{
			children = new Dictionary<char, TrieNode>();
			indexes = new List<int>();
		}


		public void InsertString(string s, int index)
		{
			if (s == null) return;
			indexes.Add(index);
			if (s.Length > 0)
			{
				char value = s[0];
				TrieNode child = null;
				if (children.ContainsKey(value))
				{
					child = children[value];
				}
				else
				{
					child = new TrieNode();
					children[value]= child;
				}
				string remainder = s.Substring(1);
				child.InsertString(remainder, index + 1);
			}
			else
			{
				children['\0'] = null;
			}
		}

		public IList<int> Search(string s)
		{
			if (s == null || s.Length == 0)
			{
				return indexes;
			}
			else
			{
				char first = s[0];
				if (children.ContainsKey(first))
				{
					string remainder = s.Substring(1);
					return children[first].Search(remainder);
				}
				else return new List<int>();
			}
		}

		public bool Terminates()
		{
			return children.ContainsKey('\0');
		}

		public TrieNode GetChild(char c)
		{
			return children.ContainsKey(c) ? children[c] : null;
		}
	}
}
