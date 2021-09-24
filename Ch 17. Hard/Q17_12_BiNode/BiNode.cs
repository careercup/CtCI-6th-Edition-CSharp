using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_12_BiNode
{
	public class BiNode
	{
		public BiNode Node1 { get; set; }
		public BiNode Node2 { get; set; }
		public int Data { get; private set; }
		public BiNode(int d)
		{
			Data = d;
		}
	}
}
