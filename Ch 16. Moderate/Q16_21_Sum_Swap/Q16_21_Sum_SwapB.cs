using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_21_Sum_Swap
{
	// 暴力解
	// 查詢目標方法
	// Time complexity: O(AB)
	public class Q16_21_Sum_SwapB : Question
    {
		public static int[] FindSwapValuesB(int[] array1, int[] array2)
		{
			int? target = GetTarget(array1, array2);
			if (target == null) return null;

			foreach (int one in array1)
			{
				foreach (int two in array2)
				{
					if (one - two == target)
					{
						int[] values = { one, two };
						return values;
					}
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
            int[] swaps = FindSwapValuesB(array1, array2);
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
