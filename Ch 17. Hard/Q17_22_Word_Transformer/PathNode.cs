using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_22_Word_Transformer
{
	public class PathNode
	{
		private string word = null;
		private PathNode previousNode = null;
		public PathNode(string word, PathNode previous)
		{
			this.word = word;
			previousNode = previous;
		}

		public string GetWord()
		{
			return word;
		}

		/* Traverse path and return linked list of nodes. */
		public LinkedList<string> Collapse(bool startsWithRoot)
		{
			LinkedList<string> path = new LinkedList<string>();
			PathNode node = this;
			while (node != null)
			{
				if (startsWithRoot)
				{
					path.AddLast(node.word);
				}
				else
				{
					path.AddFirst(node.word);
				}
				node = node.previousNode;
			}
			return path;
		}
	}
}
