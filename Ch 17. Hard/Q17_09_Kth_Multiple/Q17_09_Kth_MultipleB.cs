using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_09_Kth_Multiple
{
	// 改善
	// Time complexity: O(k log k) < O(k^2) "JAVA的 Queue可以 remove任意元素"
	public class Q17_09_Kth_MultipleB : Question
    {
		public static int GetKthMagicNumberB(int k)
		{
			if (k < 0)
			{
				return 0;
			}
			int val = 1;
			SortedSet<int> s = new SortedSet<int>();
			AddProducts(s, 1);
			for (int i = 0; i < k; i++)
			{ // Start at 1 since we've already done one iteration
				val = RemoveMin(s);
				AddProducts(s, val);
			}
			return val;
		}

		public static int RemoveMin(SortedSet<int> s)
		{
			int min = s.ElementAt(0);
			s.Remove(min);
			return min;
		}

		public static void AddProducts(SortedSet<int> q, int v)
		{
			q.Add(v * 3);
			q.Add(v * 5);
			q.Add(v * 7);
		}

		

		public override void Run()
        {
			for (int i = 0; i < 14; i++)
			{
				Console.WriteLine(i + " : " + GetKthMagicNumberB(i));
			}
		}
    }
}
