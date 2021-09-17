using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_21_Sum_Swap
{
	// 最佳化方案
	// Time complexity: O(A + B)
	// 最佳可想像執行時間(Best Conceivable Runtime, BCR)
	public class Q16_21_Sum_SwapC : Question
    {
		public static int[] FindSwapValuesC(int[] array1, int[] array2)
		{
			int? target = GetTarget(array1, array2);
			if (target == null) return null;
			return FindDifference(array1, array2, (int)target);
		}

		public static int[] FindDifference(int[] array1, int[] array2, int target)
		{
			HashSet<int> contents2 = new HashSet<int>(array2);
			foreach (int one in array1)
			{
				int two = one - target;
				if (contents2.Contains(two))
				{
					int[] values = { one, two };
					return values;
				}
			}

			return null;
		}

		public static int? GetTarget(int[] array1, int[] array2)
		{
			int sum1 = array1.Sum();
			int sum2 = array2.Sum();

			if ((sum1 - sum2) % 2 != 0) return null;

			return (sum1 - sum2) / 2;
		}

		public override void Run()
        {
			int[] array1 = { -9, -1, -4, 8, 9, 6, -5, -7, 3, 9 };
			int[] array2 = { 6, 6, 4, -1, 7, -6, -9, 4, -8, 8 };
			int[] swaps = FindSwapValuesC(array1, array2);
			if (swaps == null)
			{
				Console.WriteLine("null");
			}
			else
			{
				Console.WriteLine(swaps[0] + " " + swaps[1]);
			}
		}
    }
}
