using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_21_Sum_Swap
{
    // 暴力解
    // Time complexity: O(AB)
    public class Q16_21_Sum_SwapA : Question
    {
        public static int[] FindSwapValuesA(int[] array1, int[] array2)
        {
            int sum1 = array1.Sum();
            int sum2 = array2.Sum();

            foreach (int one in array1)
            {
                foreach (int two in array2)
                {
                    int newSum1 = sum1 - one + two;
                    int newSum2 = sum2 - two + one;
                    if (newSum1 == newSum2)
                    {
                        int[] values = { one, two };
                        return values;
                    }
                }
            }

            return null;
        }


        public override void Run()
        {
            int[] array1 = { 1, 1, 1, 2, 2, 4 };
            int[] array2 = { 3, 3, 3, 6 };
            int[] swaps = FindSwapValuesA(array1, array2);
            if (swaps == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(swaps[0] + " " + swaps[1]);
            }
        }
    }
}
