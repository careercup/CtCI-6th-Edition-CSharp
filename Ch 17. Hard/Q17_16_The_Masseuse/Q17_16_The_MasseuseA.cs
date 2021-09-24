using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_16_The_Masseuse
{
	// 方案1: 遞迴
	// Time complexity: O(2^n)
	// Space complexity: O(n)
	// n: 按摩數(陣列長度)
	public class Q17_16_The_MasseuseA : Question
    {
		public static int MaxMinutesA(int[] massages)
		{
			return MaxMinutes(massages, 0);
		}

		public static int MaxMinutes(int[] massages, int index)
		{
			if (index >= massages.Length)
			{ // Out of bounds
				return 0;
			}

			/* Best with this reservation. */
			int bestWith = massages[index] + MaxMinutes(massages, index + 2);

			/* Best without this reservation. */
			int bestWithout = MaxMinutes(massages, index + 1);

			/* Return best of this subarray, starting from index. */
			return Math.Max(bestWith, bestWithout);
		}

		public override void Run()
        {
			int[] massages = { 30, 15, 60, 75, 45, 15, 15, 45 };
			Console.WriteLine(MaxMinutesA(massages));
		}
    }
}
