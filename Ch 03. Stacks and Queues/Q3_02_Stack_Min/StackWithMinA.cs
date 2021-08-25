using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_02_Stack_Min
{
    public class StackWithMinA : Stack<NodeWithMin>
    {
        public void Push(int value)
        {
            int newMin = Math.Min(value, Min());
            base.Push(new NodeWithMin(value, newMin));
        }

        public int Min()
        {
            if (this.Count==0)
            {
                return int.MaxValue;
            }
            else
            {
                return Peek().Min;
            }
        }
    }
}
