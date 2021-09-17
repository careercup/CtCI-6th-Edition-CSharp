using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_07_Baby_Names
{
	public class GraphNode
	{
		private IList<GraphNode> neighbors;
		private IDictionary<string, GraphNode> map;
		private string name;
		private int frequency;
		private bool visited = false;

		public GraphNode(string nm, int freq)
		{
			name = nm;
			frequency = freq;
			neighbors = new List<GraphNode>();
			map = new Dictionary<string, GraphNode>();
		}

		public string GetName()
		{
			return name;
		}

		public int GetFrequency()
		{
			return frequency;
		}

		public bool AddNeighbor(GraphNode node)
		{
			if (map.ContainsKey(node.GetName()))
			{
				return false;
			}
			neighbors.Add(node);
			map[node.GetName()] = node;
			return true;
		}

		public IList<GraphNode> GetNeighbors()
		{
			return neighbors;
		}

		public bool IsVisited()
		{
			return visited;
		}

		public void SetIsVisited(bool v)
		{
			visited = v;
		}
	}
}
