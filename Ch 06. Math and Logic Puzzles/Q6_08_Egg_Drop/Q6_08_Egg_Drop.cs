using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_08_Egg_Drop
{
	// x(x+1)/2=樓層高度
    public class Q6_08_Egg_Drop : Question
    {
		public static int breakingPoint = 89;
		public static int countDrops = 0;

		public static int FindBreakingPoint(int floors)
		{
			int interval = 14;
			int previousFloor = 0;
			int egg1 = interval;

			/* Drop egg1 at decreasing intervals. */
			while (!WillBreak(egg1) && egg1 <= floors)
			{
				interval -= 1;
				previousFloor = egg1;
				egg1 += interval;
			}

			/* Drop egg2 at 1 unit increments. */
			int egg2 = previousFloor + 1;
			while (egg2 < egg1 && egg2 <= floors && !WillBreak(egg2))
			{
				egg2 += 1;
			}

			/* If it didn’t break, return -1. */
			return egg2 > floors ? -1 : egg2;
		}


		public static bool WillBreak(int floor)
		{
			countDrops++;
			return floor >= breakingPoint;
		}
	

		public override void Run()
        {
			int max = 0;
			for (int i = 1; i <= 100; i++)
			{
				countDrops = 0;
				breakingPoint = i;
				int bp = FindBreakingPoint(100);

				if (bp == breakingPoint)
				{
					Console.WriteLine("SUCCESS: " + i + " -> " + bp + " -> " + countDrops);
				}
				else
				{
					Console.WriteLine("ERROR: " + i + " -> " + bp + " vs " + breakingPoint);
					break;
				}
				max = countDrops > max ? countDrops : max;
			}
			Console.WriteLine(max);
		}
    }
}
