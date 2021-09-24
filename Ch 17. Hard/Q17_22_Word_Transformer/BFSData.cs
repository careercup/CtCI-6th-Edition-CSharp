using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_22_Word_Transformer
{
	public class BFSData
	{
		public Queue<PathNode> ToVisit { get; private set; } = new Queue<PathNode>();
		public Dictionary<string, PathNode> Visited { get; private set; } = new Dictionary<string, PathNode>();

		public BFSData(string root)
		{
			PathNode sourcePath = new PathNode(root, null);
			ToVisit.Enqueue(sourcePath);
			Visited.Add(root, sourcePath);
		}

		public bool IsFinished()
		{
			return ToVisit.Count == 0;
		}
	}
}
