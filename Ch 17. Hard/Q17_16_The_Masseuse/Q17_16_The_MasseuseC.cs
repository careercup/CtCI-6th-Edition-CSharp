using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_16_The_Masseuse
{
    // 方案3: 迭代(反向)
    // Time complexity: O(n)
    // Space complexity: O(n)
    // n: 按摩數(陣列長度)
    public class Q17_16_The_MasseuseC : Question
    {
        public static int MaxMinutesC(int[] massages)
        {
            /* Allocating two extra slots in the array so we don't have to do bounds
               * checking on lines 7 and 8. */
            int[] memo = new int[massages.Length + 2];
            memo[massages.Length] = 0;
            memo[massages.Length + 1] = 0;
            for (int i = massages.Length - 1; i >= 0; i--)
            {
                int bestWith = massages[i] + memo[i + 2];
                int bestWithout = memo[i + 1];
                memo[i] = Math.Max(bestWith, bestWithout);
            }
            return memo[0];
        }

        public override void Run()
        {
            int[] massages = { 2 * 15, 1 * 15, 4 * 15, 5 * 15, 3 * 15, 1 * 15, 1 * 15, 3 * 15 };
            Console.WriteLine(MaxMinutesC(massages));
        }
    }
}
