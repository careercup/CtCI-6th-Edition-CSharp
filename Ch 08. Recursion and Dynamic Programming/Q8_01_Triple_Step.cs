using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter08
{
    public class Q8_01_Triple_Step : Question
    {
        public class QuestionA
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
        }

        public class QuestionB
        {
            public static int CountWays(int n)
            {
                int[] map = new int[n + 1];
                AssortedMethods.FillArray<int>(map, -1);
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
        }

        public override void Run()
        {
            for (int i = 0; i < 30; i++)
            {
                int c1 = QuestionB.CountWays(i);
                int c2 = QuestionA.CountWays(i);
               Console.WriteLine($"{i}: {c1} {c2}");
            }
        }
    }
}
