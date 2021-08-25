using Ch_03._Stacks_and_Queues.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_03_Stack_of_Plates
{
	public class Stack
	{
		private int capacity;
		public Node Top { get; private set; }
		public Node Bottom { get; private set; }
		public int Size { get; private set; } = 0;

		public Stack(int capacity)
		{
			this.capacity = capacity;
		}

		public bool IsFull()
		{
			return capacity == Size;
		}

		public void Join(Node above, Node below)
		{
			if (below != null) below.Above = above;
			if (above != null) above.Below = below;
		}

		public bool Push(int v)
		{
			if (Size >= capacity) return false;
			Size++;
			Node n = new Node(v);
			if (Size == 1) Bottom = n;
			Join(n, Top);
			Top = n;
			return true;
		}

		public int Pop()
		{
			if (Top == null) throw new EmptyStackException();
			Node t = Top;
			Top = Top.Below;
			Size--;
			return t.Value;
		}

		public bool IsEmpty()
		{
			return Size == 0;
		}

		public int RemoveBottom()
		{
			Node b = Bottom;
			Bottom = Bottom.Above;
			if (Bottom != null) Bottom.Below = null;
			Size--;
			return b.Value;
		}
	}
}
