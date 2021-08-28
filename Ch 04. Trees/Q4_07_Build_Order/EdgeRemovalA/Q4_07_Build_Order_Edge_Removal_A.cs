using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_07_Build_Order.EdgeRemovalA
{
	// Topological sort
	// Time complexity: O(P+D) P:專案數量、D:相依配對數量
	public class Q4_07_Build_Order_Edge_Removal_A : Question
    {

		public static Project[] FindBuildOrderA(string[] projects, string[][] dependencies)
		{
			Graph graph = BuildGraph(projects, dependencies);
			return OrderProjects(graph.GetNodes());
		}

		/* Build the graph, adding the edge (a, b) if b is dependent on a. 
	 * Assumes a pair is listed in “build order”. The pair (a, b) in 
	 * dependencies indicates that b depends on a and a must be built
	 * before b. */
		public static Graph BuildGraph(string[] projects, string[][] dependencies)
		{
			Graph graph = new Graph();
			foreach (string project in projects)
			{
				graph.GetOrCreateNode(project);
			}

			foreach (string[] dependency in dependencies)
			{
				string first = dependency[0];
				string second = dependency[1];
				graph.AddEdge(first, second);
			}

			return graph;
		}

		public static Project[] OrderProjects(IList<Project> projects)
		{
			Project[] order = new Project[projects.Count];

			/* Add “roots” to the build order first.*/
			int endOfList = AddNonDependent(order, projects, 0);

			int toBeProcessed = 0;
			while (toBeProcessed < order.Length)
			{
				Project current = order[toBeProcessed];

				/* We have a circular dependency since there are no remaining
				 * projects with zero dependencies. */
				if (current == null)
				{
					return null;
				}

				/* Remove myself as a dependency. */
				IList<Project> children = current.GetChildren();
				foreach (Project child in children)
				{
					child.DecrementDependencies();
				}

				/* Add children that have no one depending on them. */
				endOfList = AddNonDependent(order, children, endOfList);

				toBeProcessed++;
			}

			return order;
		}

		/* A helper function to insert projects with zero dependencies 
		 * into the order array, starting at index offset. */
		public static int AddNonDependent(Project[] order, IList<Project> projects, int offset)
		{
			foreach (Project project in projects)
			{
				if (project.GetNumberDependencies() == 0)
				{
					order[offset] = project;
					offset++;
				}
			}
			return offset;
		}

		

		public static string[] ConvertTostringList(Project[] projects)
		{
			string[] buildOrder = new string[projects.Length];
			for (int i = 0; i < projects.Length; i++)
			{
				buildOrder[i] = projects[i].GetName();
			}
			return buildOrder;
		}

		


		public static string[] BuildOrderWrapper(string[] projects, string[][] dependencies)
		{
			Project[] buildOrder = FindBuildOrderA(projects, dependencies);
			if (buildOrder == null) return null;
			string[] buildOrderstring = ConvertTostringList(buildOrder);
			return buildOrderstring;
		}

		public override void Run()
        {
			// test1
			//string[] projects = { "a", "b", "c", "d", "e", "f" };
			//string[][] dependencies = {
			//	new string[] {"a", "d"},
			//	new string[] {"f", "b"},
			//	new string[] {"b", "d"},
			//	new string[] {"f", "a"},
			//	new string[] {"d", "c"}};

			// test2
			//string[] projects = { "a", "b", "c", "d", "e", "f", "g" };
			//string[][] dependencies = {
			//    new string[] {"f", "c"},
			//    new string[] {"c", "a"},
			//    new string[] {"a", "e"},
			//    new string[] {"f", "a"},
			//    new string[] {"f", "b"},
			//    new string[] {"b", "a"},
			//    new string[] {"b", "e"},
			//    new string[] {"d", "g"},
			//};

			// test3
			string[] projects = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			string[][] dependencies = {
				new string[] {"a", "b"},
				new string[] {"b", "c"},
				new string[] {"a", "c"},
				new string[] {"a", "c"},
				new string[] {"d", "e"},
				new string[] {"b", "d"},
				new string[] {"e", "f"},
				new string[] {"a", "f"},
				new string[] {"h", "i"},
				new string[] {"h", "j"},
				new string[] {"i", "j"},
				new string[] {"g", "j"}};


			string[] buildOrder = BuildOrderWrapper(projects, dependencies);
			if (buildOrder == null)
			{
				Console.WriteLine("Circular Dependency.");
			}
			else
			{
				foreach (string s in buildOrder)
				{
					Console.WriteLine(s);
				}
			}
		}
    }
}
