using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_04_Queue_via_Stacks
{
    public class Q3_04_Queue_via_Stacks : Question
    {
        public override void Run()
        {
			MyQueue<int> my_queue = new MyQueue<int>();

			// Let's test our code against a "real" queue
			Queue<int> test_queue = new Queue<int>();

			for (int i = 0; i < 100; i++)
			{
				int choice = AssortedMethods.RandomIntInRange(0, 10);
				if (choice <= 5)
				{ // enqueue
					int element = AssortedMethods.RandomIntInRange(1, 10);
					test_queue.Enqueue(element);
					my_queue.Add(element);
					Console.WriteLine("Enqueued " + element);
				}
				else if (test_queue.Count > 0)
				{
					int top1 = test_queue.Dequeue();
					int top2 = my_queue.Remove();
					if (top1 != top2)
					{ // Check for error
						Console.WriteLine("******* FAILURE - DIFFERENT TOPS: " + top1 + ", " + top2);
					}
					Console.WriteLine("Dequeued " + top1);
				}

				if (test_queue.Count == my_queue.Size())
				{
					if (test_queue.Count > 0 && test_queue.Peek() != my_queue.Peek())
					{
						Console.WriteLine("******* FAILURE - DIFFERENT TOPS: " + test_queue.Peek() + ", " + my_queue.Peek() + " ******");
					}
				}
				else
				{
					Console.WriteLine("******* FAILURE - DIFFERENT SIZES ******");
				}
			}
		}
    }
}
