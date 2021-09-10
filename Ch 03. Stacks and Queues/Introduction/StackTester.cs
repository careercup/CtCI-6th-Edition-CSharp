using Ch_03._Stacks_and_Queues.Helpers;
using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Introduction
{
    public class StackTester : Question
    {
        public override void Run()
        {
			int[] array = AssortedMethods.RandomArray(100, -100, 100);
			MyStack<int> stack1 = new MyStack<int>();
			Stack<int> stack2 = new Stack<int>();

			foreach (int a in array)
			{
				if (a < 0)
				{
					int top1, top2;
					try
					{
						top1 = stack1.Pop();
					}
					catch (EmptyStackException ex)
					{
						top1 = int.MinValue;
					}
					try
					{
						top2 = stack2.Pop();
					}
					catch (Exception ex)
					{
						top2 = int.MinValue;
					}
					if (top1 != top2)
					{
						Console.WriteLine("ERROR: mismatching tops");
					}
					else
					{
						Console.WriteLine("SUCCESS: matching tops: " + top1);
					}
				}
				else
				{
					stack1.Push(a);
					stack2.Push(a);
				}
			}

			while (!stack1.IsEmpty() || stack2.Count>0)
			{
				int top1, top2;
				try
				{
					top1 = stack1.Pop();
				}
				catch (EmptyStackException ex)
				{
					top1 = int.MinValue;
				}
				try
				{
					top2 = stack2.Pop();
				}
				catch (Exception ex)
				{
					top2 = int.MinValue;
				}
				if (top1 != top2)
				{
					Console.WriteLine("ERROR: mismatching tops");
				}
				else
				{
					Console.WriteLine("SUCCESS: matching tops: " + top1);
				}
			}
		}
    }
}
