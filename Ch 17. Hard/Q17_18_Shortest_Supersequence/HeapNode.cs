using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
    public class HeapNode : IComparable<HeapNode>
    {
        public int LocationWithinList { get; set; }
        public int ListId { get; private set; }

        public HeapNode(int location, int list)
        {
            LocationWithinList = location;
            ListId = list;
        }

        public int CompareTo(HeapNode n)
        {
            return LocationWithinList - n.LocationWithinList;
        }
    }
}
