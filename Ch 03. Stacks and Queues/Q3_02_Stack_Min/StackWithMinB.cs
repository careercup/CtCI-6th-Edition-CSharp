using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_02_Stack_Min
{
    public class StackWithMinB:Stack<int>
    {
        private Stack<int> stack;

        public StackWithMinB()
        {
            this.stack = new Stack<int>();
        }

		public void Push(int value)
		{
			if (value <= Min())
			{
				stack.Push(value);
			}
			base.Push(value);
		}

		public int Pop()
		{
			int value = base.Pop();
			if (value == Min())
			{
				stack.Pop();
			}
			return value; 
		}

		public int Min()
		{
			if (stack.Count==0)
			{
				return int.MaxValue;
			}
			else
			{
				return stack.Peek();
			}
		}
	}
}
