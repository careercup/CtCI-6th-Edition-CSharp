using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_21_Sum_Swap
{
	// 另一種方案
	// Time complexity: O(A + B) 一開始陣列已排序
	// Time complexity: O(A log A + B log B) 陣列一開始未排序
	public class Q16_21_Sum_SwapD : Question
    {
		public static int[] FindSwapValuesD(int[] array1, int[] array2)
		{
			int? target = GetTarget(array1, array2);
			if (target == null) return null;
			return FindDifference(array1, array2, (int)target);
		}

		public static int[] FindDifference(int[] array1, int[] array2, int target)
		{
			Array.Sort(array1);
			Array.Sort(array2);

			int a = 0;
			int b = 0;

			while (a < array1.Length && b < array2.Length)
			{
				int difference = array1[a] - array2[b];
				/* Compare difference to target. If difference is too small, then
				 * make it bigger by moving a to a bigger value. If it is too big,
				 * then make it smaller by moving b to a bigger value. If it's
				 * just right, return this pair. */
				if (difference == target)
				{
					int[] values = { array1[a], array2[b] };
					return values;
				}
				else if (difference < target)
				{
					a++;
				}
				else
				{
					b++;
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
            int[] array1 = { 1, 1, 1, 2, 2, 4 };
            int[] array2 = { 3, 3, 3, 6 };
            int[] swaps = FindSwapValuesD(array1, array2);
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
