using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_10_Test_Strips
{
	// 簡單方式，最多需要28天
    public class Q6_10_Test_StripsA : Question
    {
		public static int FindPoisonedBottleA(IList<Bottle> bottles, IList<TestStrip> strips)
		{
			int today = 0;

			while (bottles.Count > 1 && strips.Count > 0)
			{
				/* Run tests. */
				RunTestSet(bottles, strips, today);

				/* Wait for results. */
				today += TestStrip.DAYS_FOR_RESULT;

				/* Check results. */
				foreach (TestStrip strip in strips)
				{
					if (strip.IsPositiveOnDay(today))
					{
						bottles = strip.GetLastWeeksBottles(today);
						strips.Remove(strip);
						break;
					}
				}
			}

			if (bottles.Count == 1)
			{
				Console.WriteLine("Suspected bottle is " + bottles[0].GetId() + " on day " + today);
				return bottles[0].GetId();
			}
			return -1;
		}

		public static void RunTestSet(IList<Bottle> bottles, IList<TestStrip> strips, int day)
		{
			int index = 0;
			foreach (Bottle bottle in bottles)
			{
				TestStrip strip = strips[index];
				strip.AddDropOnDay(day, bottle);
				index = (index + 1) % strips.Count;
			}
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
				int poisonedId = FindPoisonedBottleA(bottles, testStrips);
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
