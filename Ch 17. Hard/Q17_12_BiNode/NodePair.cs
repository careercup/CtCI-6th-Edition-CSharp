using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_12_BiNode
{
	public class NodePair
	{
		public BiNode Head { get; private set; }
		public BiNode Tail { get; private set; }

		public NodePair(BiNode head, BiNode tail)
		{
			this.Head = head;
			this.Tail = tail;
		}
	}
}
