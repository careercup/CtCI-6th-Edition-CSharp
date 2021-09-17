using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_24_Pairs_With_Sum
{
	// 暴力解
	// 會有重複配對產生
    public class Q16_24_Pairs_With_SumA : Question
    {
		public static IList<Pair> PrintPairSums(int[] array, int sum)
		{
			IList<Pair> result = new List<Pair>();
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[i] + array[j] == sum)
					{
						result.Add(new Pair(array[i], array[j]));
					}
				}
			}
			return result;
		}

		public override void Run()
        {
			int[] test = { 9, 3, 6, 5, 5, 7, -1, 13, 14, -2, 12, 0 };
			IList<Pair> pairs = PrintPairSums(test, 12);
			foreach (Pair p in pairs)
			{
				Console.WriteLine(p.ToString());
			}
		}
    }
}
