using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Introduction
{
    public class StackNode<T>
    {
		public  T Data { get; private set; }
		public StackNode<T> Next { get; set; }

		public StackNode(T data)
		{
			this.Data = data;
		}
	}
}
