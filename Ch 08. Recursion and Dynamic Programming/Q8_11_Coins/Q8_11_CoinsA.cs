using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_11_Coins
{
    public class Q8_11_CoinsA : Question
    {

		public static int MakeChangeA(int amount, int[] denoms)
		{
			return MakeChangeHelper(amount, denoms, 0);
		}
		public static int MakeChangeHelper(int total, int[] denoms, int index)
		{
			int coin = denoms[index];
			if (index == denoms.Length - 1)
			{ // One denom left, either you can do it or not
				int remaining = total % coin;
				return remaining == 0 ? 1 : 0;
			}
			int ways = 0;
			/* Try 1 coin, then 2 coins, 3 three, ... (recursing each time on rest). */
			for (int amount = 0; amount <= total; amount += coin)
			{
				ways += MakeChangeHelper(total - amount, denoms, index + 1); // go to next denom
			}
			return ways;
		}

		

		public override void Run()
        {
			int[] denoms = { 25, 10, 5, 1 };
			int ways = MakeChangeA(10, denoms);
			Console.WriteLine(ways);
		}
    }
}
