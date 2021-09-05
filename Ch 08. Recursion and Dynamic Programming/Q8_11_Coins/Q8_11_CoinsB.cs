using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_11_Coins
{
    // memo
    public class Q8_11_CoinsB : Question
    {
		public static int MakeChangeB(int n, int[] denoms)
		{
			int[][] map = new int[n + 1][];
            for (int i = 0; i < n+1; i++)
            {
				map[i] = new int[denoms.Length];
            }
			return MakeChangeHelper(n, denoms, 0, map);
		}

		public static int MakeChangeHelper(int total, int[] denoms, int index, int[][] map)
		{
			/* Check cache for prior result. */
			if (map[total][index] > 0)
			{ // retrieve value
				return map[total][index];
			}

			int coin = denoms[index];
			if (index == denoms.Length - 1)
			{
				int remaining = total % coin;
				return remaining == 0 ? 1 : 0;
			}
			int numberOfWays = 0;
			/* Try 1 coin, then 2 coins, 3 three, ... (recursing each time on rest). */
			for (int amount = 0; amount <= total; amount += coin)
			{
				numberOfWays += MakeChangeHelper(total - amount, denoms, index + 1, map); // go to next denom
			}

			/* Update cache with current result. */
			map[total][index] = numberOfWays;

			return numberOfWays;
		}

		public override void Run()
        {
			int[] denoms = { 25, 10, 5, 1 };
			int ways = MakeChangeB(10, denoms);
			Console.WriteLine(ways);
		}
    }
}
