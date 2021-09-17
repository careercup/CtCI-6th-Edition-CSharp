using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_07_Baby_Names
{
	// 最佳化方案
	// Graph
	// Time complexity: O(B + P)
	// B: 嬰兒名字
	// P: 成對別名數量
	public class Q17_07_Baby_NamesB : Question
    {
		public static IDictionary<string, int> TrulyMostPopularB(IDictionary<string, int> names, string[][] synonyms)
		{
			Graph graph = ConstructGraph(names);
			ConnectEdges(graph, synonyms);
			IDictionary<string, int> rootNames = GetTrueFrequencies(graph);
			return rootNames;
		}


		/* Add all names to graph as nodes. */
		public static Graph ConstructGraph(IDictionary<string, int> names)
		{
			Graph graph = new Graph();
			foreach (var entry in names)
			{
				string name = entry.Key;
				int frequency = entry.Value;
				graph.CreateNode(name, frequency);
			}
			return graph;
		}

		/* Connect synonymous spellings. */
		public static void ConnectEdges(Graph graph, string[][] synonyms)
		{
			foreach (string[] entry in synonyms)
			{
				string name1 = entry[0];
				string name2 = entry[1];
				graph.AddEdge(name1, name2);
			}
		}

		/* Do DFS of each component. If a node has been visited before,
		 * then its component has already been computed. */
		public static IDictionary<string, int> GetTrueFrequencies(Graph graph)
		{
			IDictionary<string, int> rootNames = new Dictionary<string, int>();
			foreach (GraphNode node in graph.GetNodes())
			{
				if (!node.IsVisited())
				{
					int frequency = GetComponentFrequency(node);
					string name = node.GetName();
					rootNames[name] = frequency;
				}
			}
			return rootNames;
		}

		/* Do depth-first search to find the total frequency of this 
		 * component, and mark each node as visited.*/
		public static int GetComponentFrequency(GraphNode node)
		{
			if (node.IsVisited())
			{
				return 0;
			}
			node.SetIsVisited(true);
			int sum = node.GetFrequency();
			foreach (GraphNode child in node.GetNeighbors())
			{
				sum += GetComponentFrequency(child);
			}
			return sum;
		}

		

		

		public override void Run()
        {
			IDictionary<string, int> names = new Dictionary<string, int>();

			names.Add("John", 3);
			names.Add("Jonathan", 4);
			names.Add("Johnny", 5);
			names.Add("Chris", 1);
			names.Add("Kris", 3);
			names.Add("Brian", 2);
			names.Add("Bryan", 4);
			names.Add("Carleton", 4);

			string[][] synonyms ={
				new string[] {"John", "Jonathan"},
			 new string[] {"Jonathan", "Johnny"},
			 new string[] {"Chris", "Kris"},
			 new string[] {"Brian", "Bryan"}
			};

			IDictionary<string, int> finalList = TrulyMostPopularB(names, synonyms);
			foreach (var entry in finalList)
			{
				string name = entry.Key;
				int frequency = entry.Value;
				Console.WriteLine(name + ": " + frequency);
			}
		}
    }
}
