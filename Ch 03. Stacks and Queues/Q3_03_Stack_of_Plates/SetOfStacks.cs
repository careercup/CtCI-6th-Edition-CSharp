

using Ch_03._Stacks_and_Queues.Helpers;
using System.Collections.Generic;

namespace Ch_03._Stacks_and_Queues.Q3_03_Stack_of_Plates
{
	public class SetOfStacks
	{
		private List<Stack> stacks = new List<Stack>();
		public int Capacity { get; set; }

		public SetOfStacks(int capacity)
		{
			this.Capacity = capacity;
		}

		public Stack GetLastStack()
		{
			if (stacks.Count == 0)
			{
				return null;
			}
			return stacks[stacks.Count - 1];
		}

		public void Push(int v)
		{
			Stack last = GetLastStack();
			if (last != null && !last.IsFull())
			{ // add to last
				last.Push(v);
			}
			else
			{ // must create new stack
				Stack stack = new Stack(Capacity);
				stack.Push(v);
				stacks.Add(stack);
			}
		}

		public int Pop()
		{
			Stack last = GetLastStack();
			if (last == null) throw new EmptyStackException();
			int v = last.Pop();
			if (last.Size == 0)
			{
				stacks.RemoveAt(stacks.Count - 1);
			}
			return v;
		}

		public int PopAt(int index)
		{
			return LeftShift(index, true);
		}

		public int LeftShift(int index, bool removeTop)
		{
			Stack stack = stacks[index];
			int removed_item;
			if (removeTop) removed_item = stack.Pop();
			else removed_item = stack.RemoveBottom();
			if (stack.IsEmpty())
			{
				stacks.RemoveAt(index);
			}
			else if (stacks.Count > index + 1)
			{
				int v = LeftShift(index + 1, false);
				stack.Push(v);
			}
			return removed_item;
		}

		public bool IsEmpty()
		{
			Stack last = GetLastStack();
			return last == null || last.IsEmpty();
		}
	}
}
