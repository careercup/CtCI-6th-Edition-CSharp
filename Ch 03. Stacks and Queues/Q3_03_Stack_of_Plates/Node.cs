using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_03_Stack_of_Plates
{
	public class Node
	{
		public Node Above { get;set; }
		public Node Below { get; set; }
		public int Value { get; private set; }
		public Node(int value)
		{
			this.Value = value;
		}
	}
}
