using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Introduction
{
    public class QueueTester : Question
    {
        public override void Run()
        {
			int[] array = AssortedMethods.RandomArray(100, -100, 100);
			MyQueue<int> queue1 = new MyQueue<int>();
			Queue<int> queue2 = new Queue<int>();

			foreach (int a in array)
			{
				if (a < 0)
				{
					int top1, top2;
					try
					{
						top1 = queue1.Remove();
					}
					catch (InvalidOperationException ex)
					{
						top1 = int.MinValue;
					}
					try
					{
						top2 = queue2.Dequeue();
					}
					catch (InvalidOperationException ex)
					{
						top2 = int.MinValue;
					}
					if (top1 != top2)
					{
						Console.WriteLine("ERROR: mismatching tails");
					}
					else
					{
						Console.WriteLine("SUCCESS: matching tails: " + top1);
					}
				}
				else
				{
					queue1.Add(a);
					queue2.Enqueue(a);
				}
			}

			while (!queue1.IsEmpty() || queue2.Count>0)
			{
				int top1, top2;
				try
				{
					top1 = queue1.Remove();
				}
				catch (InvalidOperationException ex)
				{
					top1 = int.MinValue;
				}
				try
				{
					top2 = queue2.Dequeue();
				}
				catch (InvalidOperationException ex)
				{
					top2 = int.MinValue;
				}
				if (top1 != top2)
				{
					Console.WriteLine("ERROR: mismatching tails");
				}
				else
				{
					Console.WriteLine("SUCCESS: matching tails: " + top1);
				}
			}
		}
    }
}
