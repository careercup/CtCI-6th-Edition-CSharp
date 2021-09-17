using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_24_Pairs_With_Sum
{
	// 另一種方案
	// Time complexity: O(N log N) 排序 + O(N) 尋找配對 = O(N log N)
	public class Q16_24_Pairs_With_SumC : Question
    {
		public static IList<Pair> PrintPairSums(int[] array, int sum)
		{
			IList<Pair> result = new List<Pair>();
			Array.Sort(array);
			int first = 0;
			int last = array.Length - 1;
			while (first < last)
			{
				int s = array[first] + array[last];
				if (s == sum)
				{
					result.Add(new Pair(array[first], array[last]));
					++first;
					--last;
				}
				else
				{
					if (s < sum)
					{
						++first;
					}
					else
					{
						--last;
					}
				}
			}
			return result;
		}

		public override void Run()
        {
			int[] test = { 9, 3, 6, 5, 7, 7, -1, 13, 14, -2, 12, 0 };
			IList<Pair> pairs = PrintPairSums(test, 12);
			foreach (Pair p in pairs)
			{
				Console.WriteLine(p.ToString());
			}
		}
    }
}
