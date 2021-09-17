using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_09_Kth_Multiple
{
	// 最佳化演算法
	// Time complexity: O(3*k) -> O(k)
	public class Q17_09_Kth_MultipleC : Question
    {
		public static int GetKthMagicNumberC(int k)
		{
			if (k < 0)
			{
				return 0;
			}
			int val = 0;
			Queue<int> queue3 = new Queue<int>();
			Queue<int> queue5 = new Queue<int>();
			Queue<int> queue7 = new Queue<int>();
			queue3.Enqueue(1);
			for (int i = 0; i <= k; i++)
			{ // Include 0th iteration through kth iteration
				int v3 = queue3.Count > 0 ? queue3.Peek() : int.MaxValue;
				int v5 = queue5.Count > 0 ? queue5.Peek() : int.MaxValue;
				int v7 = queue7.Count > 0 ? queue7.Peek() : int.MaxValue;
				val = Math.Min(v3, Math.Min(v5, v7));
				if (val == v3)
				{
					queue3.Dequeue();
					queue3.Enqueue(3 * val);
					queue5.Enqueue(5 * val);
				}
				else if (val == v5)
				{
					queue5.Dequeue();
					queue5.Enqueue(5 * val);
				}
				else if (val == v7)
				{
					queue7.Dequeue();
				}
				queue7.Enqueue(7 * val);
			}
			return val;
		}

		public static void PrintQueue(Queue<int> q, int x)
		{
			Console.Write(x + ": ");
			foreach (int a in q)
			{
				Console.Write(a / x + ", ");
			}
			Console.WriteLine("");
		}

		

		public override void Run()
        {
			for (int i = 0; i < 14; i++)
			{
				Console.WriteLine(i + " : " + GetKthMagicNumberC(i));
			}
		}
    }
}
