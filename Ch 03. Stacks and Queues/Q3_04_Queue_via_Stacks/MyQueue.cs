using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_04_Queue_via_Stacks
{
    public class MyQueue<T>
    {
		Stack<T> stackNewest, stackOldest;

		public MyQueue()
		{
			stackNewest = new Stack<T>();
			stackOldest = new Stack<T>();
		}

		public int Size()
		{
			return stackNewest.Count + stackOldest.Count;
		}

		public void Add(T value)
		{
			// Push onto stack1
			stackNewest.Push(value);
		}

		/* Move elements from stackNewest into stackOldest. This is usually done so that we can
		 * do operations on stackOldest.
		 */
		private void ShiftStacks()
		{
			if (stackOldest.Count==0)
			{
				while (stackNewest.Count>0)
				{
					stackOldest.Push(stackNewest.Pop());
				}
			}
		}

		public T Peek()
		{
			ShiftStacks();
			return stackOldest.Peek(); // retrieve the oldest item.
		}

		public T Remove()
		{
			ShiftStacks();
			return stackOldest.Pop(); // pop the oldest item.
		}
	}
}
