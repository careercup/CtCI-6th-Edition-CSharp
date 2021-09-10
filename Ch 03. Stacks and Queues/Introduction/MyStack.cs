using Ch_03._Stacks_and_Queues.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Introduction
{
	public class MyStack<T>
	{
		
		private StackNode<T> top;

		public T Pop()
		{
			if (top == null) throw new EmptyStackException();
			T item = top.Data;
			top = top.Next;
			return item;
		}

		public void Push(T item)
		{
			StackNode<T> t = new StackNode<T>(item);
			t.Next = top;
			top = t;
		}

		public T Peek()
		{
			if (top == null) throw new EmptyStackException();
			return top.Data;
		}

		public bool IsEmpty()
		{
			return top == null;
		}
	}
}
