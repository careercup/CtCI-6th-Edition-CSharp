using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_16_The_Masseuse
{
    // 方案2: 遞迴 + 記憶化
    // Time complexity: O(n)
    // Space complexity: O(n)
    // n: 按摩數(陣列長度)
    public class Q17_16_The_MasseuseB : Question
    {
		public static int MaxMinutesB(int[] massages)
		{
			int[] memo = new int[massages.Length];
			return MaxMinutes(massages, 0, memo);
		}

		public static int MaxMinutes(int[] massages, int index, int[] memo)
		{
			if (index >= massages.Length)
			{
				return 0;
			}
			if (memo[index] == 0)
			{
				int bestWith = massages[index] + MaxMinutes(massages, index + 2, memo);
				int bestWithout = MaxMinutes(massages, index + 1, memo);
				memo[index] = Math.Max(bestWith, bestWithout);
			}

			return memo[index];
		}

		public override void Run()
        {
			int[] massages = { 2 * 15, 1 * 15, 4 * 15, 5 * 15, 3 * 15, 1 * 15, 1 * 15, 3 * 15 };
			Console.WriteLine(MaxMinutesB(massages));
		}
    }
}
