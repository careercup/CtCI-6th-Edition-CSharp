using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_10_Test_Strips
{
	// 最佳化方法: 最差情況需要 10 天
    public class Q6_10_Test_StripsB : Question
    {

		public static int FindPoisonedBottleB(IList<Bottle> bottles, IList<TestStrip> strips)
		{
			if (bottles.Count > 1000 || strips.Count< 10) return -1;

			int tests = 4; // three digits, plus one extra
			int nTestStrips = strips.Count;

			/* Run tests. */
			for (int day = 0; day < tests; day++)
			{
				RunTestSet(bottles, strips, day);
			}

			/* Get results. */
			HashSet<int> previousResults = new HashSet<int>();
			int[] digits = new int[tests];
			for (int day = 0; day < tests; day++)
			{
				int resultDay = day + TestStrip.DAYS_FOR_RESULT;
				digits[day] = GetPositiveOnDay(strips, resultDay, previousResults);
				previousResults.Add(digits[day]);
			}

			/* If day 1's results matched day 0's, update the digit. */
			if (digits[1] == -1)
			{
				digits[1] = digits[0];
			}

			/* If day 2 matched day 0 or day 1, check day 3. Day 3 is
			 * the same as day 2, but incremented by 1. */
			if (digits[2] == -1)
			{
				if (digits[3] == -1)
				{ /* Day 3 didn't give new result */
					/* Digit 2 equals digit 0 or digit 1. But, digit 2, when incremented also matches 
					 * digit 0 or digit 1. This means that digit 0 incremented matches digit 1, or the
					 * other way around. */
					digits[2] = ((digits[0] + 1) % nTestStrips) == digits[1] ? digits[0] : digits[1];
				}
				else
				{
					digits[2] = (digits[3] - 1 + nTestStrips) % nTestStrips;
				}
			}

			return digits[0] * 100 + digits[1] * 10 + digits[2];
		}

		/* Run set of tests for this day. */
		public static void RunTestSet(IList<Bottle> bottles, IList<TestStrip> strips, int day)
		{
			if (day > 3) return; // only works for 3 days (digits) + one extra

			foreach (Bottle bottle in bottles)
			{
				int index = GetTestStripIndexForDay(bottle, day, strips.Count);
				TestStrip testStrip = strips[index];
				testStrip.AddDropOnDay(day, bottle);
			}
		}

		/* Get test strip index that should be used on this bottle on this day. */
		public static int GetTestStripIndexForDay(Bottle bottle, int day, int nTestStrips)
		{
			int id = bottle.GetId();
			switch (day)
			{
				case 0: return id / 100;
				case 1: return (id % 100) / 10;
				case 2: return id % 10;
				case 3: return (id % 10 + 1) % nTestStrips;
				default: return -1;
			}
		}

		/* Get results that are positive for a particular day, excluding prior results. */
		public static int GetPositiveOnDay(IList<TestStrip> testStrips, int day, HashSet<int> previousResults)
		{
			foreach (TestStrip testStrip in testStrips)
			{
				int id = testStrip.GetId();
				if (testStrip.IsPositiveOnDay(day) && !previousResults.Contains(id))
				{
					return testStrip.GetId();
				}
			}
			return -1;
		}

		public static IList<Bottle> CreateBottles(int nBottles, int poisoned)
		{
			IList<Bottle> bottles = new List<Bottle>();
			for (int i = 0; i < nBottles; i++)
			{
				bottles.Add(new Bottle(i));
			}

			if (poisoned == -1)
			{
				Random random = new Random();
				poisoned = random.Next(nBottles);
			}
			bottles[poisoned].SetAsPoisoned();

			Console.WriteLine("Added poison to bottle " + poisoned);

			return bottles;
		}

		public static IList<TestStrip> CreateTestStrips(int nTestStrips)
		{
			IList<TestStrip> testStrips = new List<TestStrip>();
			for (int i = 0; i < nTestStrips; i++)
			{
				testStrips.Add(new TestStrip(i));
			}
			return testStrips;
		}

		public override void Run()
        {
			int nBottles = 1000;
			int nTestStrips = 10;
			for (int poisoned = 0; poisoned < nBottles; poisoned++)
			{
				IList<Bottle> bottles = CreateBottles(nBottles, poisoned);
				IList<TestStrip> testStrips = CreateTestStrips(nTestStrips);
				int poisonedId = FindPoisonedBottleB(bottles, testStrips);
				Console.WriteLine("Suspected Bottle: " + poisonedId);
				if (poisonedId != poisoned)
				{
					Console.WriteLine("ERROR");
					break;
				}
			}
		}
    }
}
