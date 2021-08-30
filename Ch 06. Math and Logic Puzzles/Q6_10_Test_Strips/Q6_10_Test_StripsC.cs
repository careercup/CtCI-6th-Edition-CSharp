using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_10_Test_Strips
{
	// 最佳化方法: 最差情況需要 7 天
	// 2^T >= B
	// T: 試紙數量
	// B: 瓶子數量
	public class Q6_10_Test_StripsC : Question
    {
		
		public static int FindPoisonedBottleC(IList<Bottle> bottles, IList<TestStrip> strips)
		{
			RunTests(bottles, strips);
			IList<int> positive = GetPositiveOnDay(strips, 7);
			return SetBits(positive);
		}

		/* Add bottles to test strips */
		public static void RunTests(IList<Bottle> bottles, IList<TestStrip> testStrips)
		{
			foreach (Bottle bottle in bottles)
			{
				int id = bottle.GetId();
				int bitIndex = 0;
				while (id > 0)
				{
					if ((id & 1) == 1)
					{
						testStrips[bitIndex].AddDropOnDay(0, bottle);
					}
					bitIndex++;
					id >>= 1;
				}
			}
		}

		/* Get test strips that are positive on a particular day. */
		public static IList<int> GetPositiveOnDay(IList<TestStrip> testStrips, int day)
		{
			IList<int> positive = new List<int>();
			foreach (TestStrip testStrip in testStrips)
			{
				int id = testStrip.GetId();
				if (testStrip.IsPositiveOnDay(day))
				{
					positive.Add(id);
				}
			}
			return positive;
		}

		/* Create number by setting bits with indices specified in positive. */
		public static int SetBits(IList<int> positive)
		{
			int id = 0;
			foreach (var bitIndex in positive)
			{
				id |= 1 << bitIndex;
			}
			return id;
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
				int poisonedId = FindPoisonedBottleC(bottles, testStrips);
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
