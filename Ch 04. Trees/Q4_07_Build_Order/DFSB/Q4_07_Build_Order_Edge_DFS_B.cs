using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_07_Build_Order.DFSB
{
    // Time complexity: O(P+D) P:專案數量、D:相依配對數量
    public class Q4_07_Build_Order_Edge_DFS_B : Question
    {
        public static Stack<Project> FindBuildOrderB(string[] projects, string[][] dependencies)
        {
            Graph graph = BuildGraph(projects, dependencies);
            return OrderProjects(graph.GetNodes());
        }

        /* Build the graph, adding the edge (a, b) if b is dependent on a. 
	 * Assumes a pair is listed in “build order” (which is the reverse 
	 * of dependency order). The pair (a, b) in dependencies indicates
	 * that b depends on a and a must be built before a. */
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

        public static Stack<Project> OrderProjects(IList<Project> projects)
        {
            Stack<Project> stack = new Stack<Project>();
            foreach (Project project in projects)
            {
                if (project.GetState() == State.BLANK)
                {
                    if (!DoDFS(project, stack))
                    {
                        return null;
                    }
                }
            }
            return stack;
        }

        public static bool DoDFS(Project project, Stack<Project> stack)
        {
            if (project.GetState() == State.PARTIAL)
            {
                return false; // Cycle
            }

            if (project.GetState() == State.BLANK)
            {
                project.SetState(State.PARTIAL);
                IList<Project> children = project.GetChildren();
                foreach (Project child in children)
                {
                    if (!DoDFS(child, stack))
                    {
                        return false;
                    }
                }
                project.SetState(State.COMPLETE);
                stack.Push(project);
            }
            return true;
        }



        public static string[] ConvertTostringList(Stack<Project> projects)
        {
            string[] buildOrder = new string[projects.Count];
            for (int i = 0; i < buildOrder.Length; i++)
            {
                buildOrder[i] = projects.Pop().GetName();
            }
            return buildOrder;
        }



        public static string[] BuildOrderWrapper(string[] projects, string[][] dependencies)
        {
            Stack<Project> buildOrder = FindBuildOrderB(projects, dependencies);
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
