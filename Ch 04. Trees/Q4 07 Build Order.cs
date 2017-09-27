using System;
using System.Collections.Generic;
using System.Text;
using ctci.Contracts;
using ctci.Library;

namespace Chapter04
{
    public class Q4_07_Build_Order : Question
    {
        // I wrote the solution based on Topological sort in the Algorithms Book, 
        // and its code is here. https://github.com/kevin-wayne/algs4.
        // In topological sort, you are using a directed graph.
        // If a -> b, then it means, b depends on a,
        // in other words, 'a' needs to be built before 'b.'
        // After a topological sort, you expect all the nodes to be arranged such that it is flowing in one direction. 
        // Since a cycle is not allowed, the code checks if a cycle exists and returns.
        // In real life, jobs cannot have circular dependencies.
        public override void Run()
        {
            var diGraph = new DirectedGraph('f');
            diGraph.AddEdge('a', 'd'); // d depends on a
            diGraph.AddEdge('f', 'b'); // b depends on f
            diGraph.AddEdge('b', 'd');
            diGraph.AddEdge('f', 'a');
            diGraph.AddEdge('d', 'c');

            var topological = new Topological(diGraph);
            var order = topological.Order();
            AssortedMethods.PrintList(order);
        }

        public class DirectedGraph
        {
            Dictionary<char, IList<char>> AdjacentVertexes;
            List<char> Vertexes;

            public DirectedGraph(char v)
            {
                Vertexes = new List<char>();
                AdjacentVertexes = new Dictionary<char, IList<char>>();
                for (var a = 'a'; a <= v; a++)
                {
                    AdjacentVertexes[a] = new List<char>();
                    Vertexes.Add(a);
                }
            }

            public void AddEdge(char v, char w)
            {
                AdjacentVertexes[v].Add(w);
            }
            public IEnumerable<char> GetVertexes()
            {
                return Vertexes;
            }

            public IEnumerable<char> GetAdjacentVertexes(char v)
            {
                return AdjacentVertexes[v];
            }
        }

        public class DirectedCycle
        {
            HashSet<char> marked;
            Dictionary<char, char> edgeTo;

            Stack<char> cycle;
            Dictionary<char, bool> onStack;

            public DirectedCycle(DirectedGraph G)
            {
                onStack = new Dictionary<char, bool>();
                edgeTo = new Dictionary<char, char>();
                marked = new HashSet<char>();
                foreach (var vertex in G.GetVertexes())
                    if (!marked.Contains(vertex)) DepthFirstCycleDetection(G, vertex);
            }

            private void DepthFirstCycleDetection(DirectedGraph graph, char vertex)
            {
                onStack[vertex] = true;
                marked.Add(vertex);
                foreach (var adjVertexes in graph.GetAdjacentVertexes(vertex))
                {
                    if (this.HasCycle()) return;
                    else if (!marked.Contains(adjVertexes))
                    {
                        edgeTo[adjVertexes] = vertex;
                        DepthFirstCycleDetection(graph, adjVertexes);
                    }
                    else if (onStack[adjVertexes])
                    {
                        cycle = new Stack<char>();
                        for (char x = vertex; x != adjVertexes; x = edgeTo[x])
                            cycle.Push(x);
                        cycle.Push(adjVertexes);
                        cycle.Push(vertex);
                    }
                }
                onStack[vertex] = false;
            }

            public bool HasCycle()
            {
                return cycle != null;
            }
        }

        public class DepthFirstOrder
        {
            HashSet<char> marked;
            Stack<char> reversePost;

            public DepthFirstOrder(DirectedGraph graph)
            {
                reversePost = new Stack<char>();
                marked = new HashSet<char>();

                foreach (var vertex in graph.GetVertexes())
                    if (!marked.Contains(vertex))
                        DepthFirstSearch(graph, vertex);
            }

            private void DepthFirstSearch(DirectedGraph graph, char vertex)
            {
                marked.Add(vertex);
                foreach (var adjVertex in graph.GetAdjacentVertexes(vertex))
                    if (!marked.Contains(adjVertex))
                        DepthFirstSearch(graph, adjVertex);
                reversePost.Push(vertex);
            }

            public IEnumerable<char> ReversePost()
            {
                return reversePost;
            }
        }

        public class Topological
        {
            IEnumerable<char> order;

            public Topological(DirectedGraph graph)
            {
                var cycleFinder = new DirectedCycle(graph);
                if (!cycleFinder.HasCycle())
                {
                    var depthFirstOrder = new DepthFirstOrder(graph);
                    order = depthFirstOrder.ReversePost();
                }
            }

            public IEnumerable<char> Order() { return order; }
        }
    }
}
