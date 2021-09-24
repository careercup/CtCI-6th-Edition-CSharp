using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_16_The_Masseuse
{
	// 方案4: 時間與空間最佳化的迭代
	// Time complexity: O(n)
	// Space complexity: O(1)
	// n: 按摩數(陣列長度)
	public class Q17_16_The_MasseuseD : Question
    {
		public static int MaxMinutesD(int[] massages)
		{
			int oneAway = 0;
			int twoAway = 0;
			for (int i = massages.Length - 1; i >= 0; i--)
			{
				int bestWith = massages[i] + twoAway;
				int bestWithout = oneAway;
				int current = Math.Max(bestWith, bestWithout);
				twoAway = oneAway;
				oneAway = current;
			}
			return oneAway;
		}

		public override void Run()
        {
			int[] massages = { 2 * 15, 1 * 15, 4 * 15, 5 * 15, 3 * 15, 1 * 15, 1 * 15, 3 * 15 };
			Console.WriteLine(MaxMinutesD(massages));
		}
    }
}
