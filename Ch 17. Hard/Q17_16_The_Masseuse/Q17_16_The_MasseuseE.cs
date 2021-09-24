using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_16_The_Masseuse
{
    // 方案5: 迭代 (順向)
    // Time complexity: O(n)
    // Space complexity: O(n)
    // n: 按摩數(陣列長度)
    public class Q17_16_The_MasseuseE : Question
    {
        public static int MaxMinutesE(int[] massages)
        {
            int n = massages.Length;
            if (n == 0) return 0;
            else if (n == 1) return massages[1];
            else
            {
                int[] dp = new int[n + 1];
                dp[0] = 0;
                dp[1] = massages[0];
                for (int i = 2; i <= n; i++)
                {
                    dp[i] = Math.Max(dp[i - 1], dp[i - 2] + massages[i - 1]);
                }
                return dp[n];
            }
        }

        public override void Run()
        {
            int[] massages = { 2 * 15, 1 * 15, 4 * 15, 5 * 15, 3 * 15, 1 * 15, 1 * 15, 3 * 15 };
            Console.WriteLine(MaxMinutesE(massages));
        }
    }
}
