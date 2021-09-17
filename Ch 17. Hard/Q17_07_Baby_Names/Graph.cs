using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_07_Baby_Names
{
	public class Graph
	{
		private IList<GraphNode> nodes;
		private IDictionary<string, GraphNode> map;

		public Graph()
		{
			map = new Dictionary<string, GraphNode>();
			nodes = new List<GraphNode>();
		}

		public bool HasNode(string name)
		{
			return map.ContainsKey(name);
		}

		public GraphNode CreateNode(string name, int freq)
		{
			if (map.ContainsKey(name))
			{
				return GetNode(name);
			}

			GraphNode node = new GraphNode(name, freq);
			nodes.Add(node);
			map[name] = node;
			return node;
		}

		private GraphNode GetNode(string name)
		{
			return map.ContainsKey(name) ? map[name] : null;
		}

		public IList<GraphNode> GetNodes()
		{
			return nodes;
		}

		public void AddEdge(string startName, string endName)
		{
			GraphNode start = GetNode(startName);
			GraphNode end = GetNode(endName);
			if (start != null && end != null)
			{
				start.AddNeighbor(end);
				end.AddNeighbor(start);
			}
		}
	}
}
