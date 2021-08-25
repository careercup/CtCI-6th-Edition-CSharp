using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_02_Stack_Min
{
    public class NodeWithMin
    {
        public int Value { get; private set; }
        public int Min { get; private set; }
        public NodeWithMin(int v, int min)
        {
            Value = v;
            this.Min = min;
        }
    }
}
