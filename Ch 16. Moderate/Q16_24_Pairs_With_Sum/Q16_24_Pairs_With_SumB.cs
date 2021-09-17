using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_24_Pairs_With_Sum
{
	// 最佳化方案
	// Time complexity: O(N)
	// Space complexity: O(N)
	// 會輸出重複配對，但不會重複使用相同元素的實例
	public class Q16_24_Pairs_With_SumB : Question
    {
		public static IList<Pair> PrintPairSums(int[] array, int sum)
		{
			IList<Pair> result = new List<Pair>();
			IDictionary<int,int> unpairedCount = new Dictionary<int, int>();
			foreach (int x in array)
			{
				int complement = sum - x;
				if (unpairedCount.ContainsKey(complement))
				{
					result.Add(new Pair(x, complement));
					AdjustCounterBy(unpairedCount, complement, -1); // decrement complement
				}
				else
				{
					AdjustCounterBy(unpairedCount, x, 1); // increment x
				}
			}
			return result;
		}

		public static void AdjustCounterBy(IDictionary<int, int> counter, int key, int delta)
		{
			if (!counter.ContainsKey(key)) counter[key] = 0;
			counter[key] -= delta;
			if (counter[key] == 0) counter.Remove(key);
		}

		public override void Run()
        {
			int[] test = { -1, -1, -1, -1, 0, 0, 0, 0, 1, 1 };
			IList<Pair> pairs = PrintPairSums(test, -1);
			foreach (Pair p in pairs)
			{
				Console.WriteLine(p.ToString());
			}
		}
    }
}
