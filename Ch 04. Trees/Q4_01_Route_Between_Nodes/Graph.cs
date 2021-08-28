using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_01_Route_Between_Nodes
{
	public class Graph
	{
		private static int MAX_VERTICES = 6;
		private Node[] vertices;
		public int Count { get; private set; }
		public Graph()
		{
			vertices = new Node[MAX_VERTICES];
			Count = 0;
		}

		public void AddNode(Node x)
		{
			if (Count < vertices.Length)
			{
				vertices[Count] = x;
				Count++;
			}
			else
			{
				Console.Write("Graph full");
			}
		}

		public Node[] GetNodes()
		{
			return vertices;
		}
	}
}
