using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_01_Triple_Step
{
    // 暴力解
    // Time complexity: O(3^n)
    public class Q8_01_Triple_StepA : Question
    {
        public static int CountWays(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else
            {
                return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);
            }
        }

        public override void Run()
        {
            int n = 20;
            int ways = CountWays(n);
            Console.WriteLine(ways);
        }
    }
}
