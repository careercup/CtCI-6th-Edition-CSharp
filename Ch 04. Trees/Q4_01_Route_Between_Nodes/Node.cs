using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_01_Route_Between_Nodes
{
    public class Node
    {
        private Node[] adjacent;
        public int AdjacentCount { get; private set; }
        private string vertex;
        public State State;
        public Node(string vertex, int adjacentLength)
        {
            this.vertex = vertex;
            AdjacentCount = 0;
            adjacent = new Node[adjacentLength];
        }

        public void AddAdjacent(Node x)
        {
            if (AdjacentCount < adjacent.Length)
            {
                this.adjacent[AdjacentCount] = x;
                AdjacentCount++;
            }
            else
            {
                Console.Write("No more adjacent can be added");
            }
        }
        public Node[] GetAdjacent()
        {
            return adjacent;
        }
        public string GetVertex()
        {
            return vertex;
        }
    }
}
