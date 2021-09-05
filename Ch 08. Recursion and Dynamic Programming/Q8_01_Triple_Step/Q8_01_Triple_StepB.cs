using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_01_Triple_Step
{
    public class Q8_01_Triple_StepB : Question
    {
        // n>37 後會超過
        // Time complexity: O(n)
        public static int CountWays(int n)
        {
            int[] map = Enumerable.Repeat(-1, n + 1).ToArray();
            return CountWays(n, map);
        }

        public static int CountWays(int n, int[] memo)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else if (memo[n] > -1)
            {
                return memo[n];
            }
            else
            {
                memo[n] = CountWays(n - 1, memo) + CountWays(n - 2, memo) + CountWays(n - 3, memo);
                return memo[n];
            }
        }

        public override void Run()
        {
            int n = 50;
            int ways = CountWays(n);
            Console.WriteLine(ways);
        }
    }
}
