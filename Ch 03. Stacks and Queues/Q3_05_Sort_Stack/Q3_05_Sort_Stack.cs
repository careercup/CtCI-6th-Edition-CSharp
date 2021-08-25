using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_05_Sort_Stack
{
    public class Q3_05_Sort_Stack : Question
    {
		// 限制只能使用一個額外空間
		public void SortA(Stack<int> s)
		{
			// Time complexity: O(n^2)
			// Space complexity: O(n)
			Stack<int> r = new Stack<int>();
			while (s.Count > 0)
			{
				/* Insert each element in s in sorted order into r. */
				int tmp = s.Pop();
				while (r.Count > 0 && r.Peek() > tmp)
				{
					s.Push(r.Pop());
				}
				r.Push(tmp);
			}

			/* Copy the elements back. */
			while (r.Count > 0)
			{
				s.Push(r.Pop());
			}
		}

		// 不限制使用額外空間數
		public static Stack<int> MergesortB(Stack<int> inStack)
		{
			if (inStack.Count <= 1)
			{
				return inStack;
			}

			Stack<int> left = new Stack<int>();
			Stack<int> right = new Stack<int>();
			int count = 0;
			while (inStack.Count != 0)
			{
				count++;
				if (count % 2 == 0)
				{
					left.Push(inStack.Pop());
				}
				else
				{
					right.Push(inStack.Pop());
				}
			}

			left = MergesortB(left);
			right = MergesortB(right);

			while (left.Count> 0 || right.Count > 0)
			{
				if (left.Count == 0)
				{
					inStack.Push(right.Pop());
				}
				else if (right.Count == 0)
				{
					inStack.Push(left.Pop());
				}
				else if (right.Peek().CompareTo(left.Peek()) <= 0)
				{
					inStack.Push(left.Pop());
				}
				else
				{
					inStack.Push(right.Pop());
				}
			}

			Stack<int> reverseStack = new Stack<int>();
			while (inStack.Count > 0)
			{
				reverseStack.Push(inStack.Pop());
			}

			return reverseStack;
		}


		public override void Run()
        {
			Stack<int> s = new Stack<int>();
			for (int i = 0; i < 10; i++)
			{
				int r = AssortedMethods.RandomIntInRange(0, 1000);
				s.Push(r);
			}

			SortA(s);

			while (s.Count>0)
			{
				Console.WriteLine(s.Pop());
			}
		}
    }
}
