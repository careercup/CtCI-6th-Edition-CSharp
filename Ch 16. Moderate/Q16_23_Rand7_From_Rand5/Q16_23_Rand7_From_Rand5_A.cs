using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_23_Rand7_From_Rand5
{
    public class Q16_23_Rand7_From_Rand5_A : Question
    {
		public static int Rand7()
		{
			while (true)
			{
				int num = 5 * Rand5() + Rand5();
				if (num < 21)
				{
					return num % 7;
				}
			}
		}

		public static int Rand5()
		{
			return (int)(new Random().NextDouble() * 100) % 5;
		}

		public override void Run()
        {
			/* Test: call rand7 many times and inspect the results. */
			int[] arr = new int[7];
			int test_size = 1000000;
			for (int k = 0; k < test_size; k++)
			{
				arr[Rand7()]++;
			}

			for (int i = 0; i < 7; i++)
			{
				double percent = 100.0 * arr[i] / test_size;
				Console.WriteLine(i + " appeared " + percent + "% of the time.");
			}
		}
    }
}
