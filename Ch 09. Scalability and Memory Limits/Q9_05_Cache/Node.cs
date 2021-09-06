using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_05_Cache
{
	public class Node
	{
		public Node Prev { get; set; }
		public Node Next { get; set; }
		public string[] Results { get; set; }
		public string Query { get; private set; }

		public Node(string q, string[] res)
		{
			Results = res;
			Query = q;
		}
	}
}
