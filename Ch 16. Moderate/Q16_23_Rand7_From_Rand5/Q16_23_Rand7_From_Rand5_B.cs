using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_23_Rand7_From_Rand5
{
    public class Q16_23_Rand7_From_Rand5_B : Question
    {
		public static int Rand7()
		{
			while (true)
			{
				int r1 = 2 * Rand5(); /* evens between 0 and 9 */
				int r2 = Rand5(); /* will be later used to generate a 0 or 1 */
				if (r2 != 4)
				{ /* r2 has an extra even number, so discard the extra */
					int rand1 = r2 % 2; /* Generate 0 or 1 */
					int num = r1 + rand1; /* will be in the range 0 through 9 */
					if (num < 7)
					{
						return num;
					}
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
