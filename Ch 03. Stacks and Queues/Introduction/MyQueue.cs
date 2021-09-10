using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Introduction
{
	public class MyQueue<T>
	{

		private QueueNode<T> first;
		private QueueNode<T> last;

		public void Add(T item)
		{
			QueueNode<T> t = new QueueNode<T>(item);
			if (last != null)
			{
				last.Next = t;
			}
			last = t;
			if (first == null)
			{
				first = last;
			}
		}

		public T Remove()
		{
			if (first == null) throw new InvalidOperationException();
			T data = first.Data;
			first = first.Next;
			if (first == null)
			{
				last = null;
			}
			return data;
		}

		public T Peek()
		{
			if (first == null) throw new InvalidOperationException();
			return first.Data;
		}

		public bool IsEmpty()
		{
			return first == null;
		}
	}
}
