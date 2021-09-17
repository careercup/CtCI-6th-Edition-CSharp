using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_25_LRU_Cache
{
	public class LinkedListNode
	{
		public LinkedListNode Next { get; set; }
		public LinkedListNode Prev { get; set; }
		public int Key { get; private set; }
		public string Value { get; private set; }
		public LinkedListNode(int k, string v)
		{
			Key = k;
			Value = v;
		}

		public string PrintForward()
		{
			string data = "(" + Key + "," + Value + ")";
			if (Next != null)
			{
				return data + "->" + Next.PrintForward();
			}
			else
			{
				return data;
			}
		}
	}
}
