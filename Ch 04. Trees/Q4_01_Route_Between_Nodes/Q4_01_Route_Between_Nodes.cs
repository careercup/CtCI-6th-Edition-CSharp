using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_01_Route_Between_Nodes
{
    public class Q4_01_Route_Between_Nodes : Question
    {
        //BFS
        public static bool Search(Graph g, Node start, Node end)
        {
            LinkedList<Node> q = new LinkedList<Node>();
            foreach (Node u in g.GetNodes())
            {
                u.State = State.Unvisited;
            }
            start.State = State.Visiting;
            q.AddLast(start);
            while (q.Count>0)
            {
                Node u = q.Last();
                q.RemoveFirst();
                if (u != null)
                {
                    foreach (Node v in u.GetAdjacent())
                    {
                        if (v.State == State.Unvisited)
                        {
                            if (v == end)
                            {
                                return true;
                            }
                            else
                            {
                                v.State = State.Visiting;
                                q.AddLast(v);
                            }
                        }
                    }
                    u.State = State.Visited;
                }
            }
            return false;
        }


        public static Graph CreateNewGraph()
        {
            Graph g = new Graph();
            Node[] temp = new Node[6];

            temp[0] = new Node("a", 3);
            temp[1] = new Node("b", 0);
            temp[2] = new Node("c", 0);
            temp[3] = new Node("d", 1);
            temp[4] = new Node("e", 1);
            temp[5] = new Node("f", 0);

            temp[0].AddAdjacent(temp[1]);
            temp[0].AddAdjacent(temp[2]);
            temp[0].AddAdjacent(temp[3]);
            temp[3].AddAdjacent(temp[4]);
            temp[4].AddAdjacent(temp[5]);
            for (int i = 0; i < 6; i++)
            {
                g.AddNode(temp[i]);
            }
            return g;
        }

        public override void Run()
        {
            Graph g = CreateNewGraph();
            Node[] n = g.GetNodes();
            Node start = n[3];
            Node end = n[5];
            Console.WriteLine(Search(g, start, end));
        }
    }
}
