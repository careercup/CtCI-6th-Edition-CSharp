using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
	public class BFSData
	{
		public Queue<PathNode> ToVisit { get; set; } = new Queue<PathNode>();
		public Dictionary<int, PathNode> Visited { get; set; } = new Dictionary<int, PathNode>();

		public BFSData(Person root)
		{
			PathNode sourcePath = new PathNode(root, null);
			ToVisit.Enqueue(sourcePath);
			Visited[root.GetID()]= sourcePath;
		}

		public bool IsFinished()
		{
			return ToVisit.Count==0;
		}
	}
}
