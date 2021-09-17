using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_08_Circus_Tower
{
	// 方案2: 迭代
	// Time complexity: O(n^2)
	public class Q17_08_Circus_TowerB : Question
    {
		public static IList<HtWt> LongestIncreasingSeqB(IList<HtWt> array)
		{
			((List<HtWt>)array).Sort();

			IList<IList<HtWt>> solutions = new List<IList<HtWt>>();
			IList<HtWt> bestSequence = null;
			for (int i = 0; i < array.Count; i++)
			{
				IList<HtWt> longestAtIndex = BestSeqAtIndex(array, solutions, i);
				solutions.Add(longestAtIndex);
				bestSequence = Max(bestSequence, longestAtIndex);
			}

			return bestSequence;
		}

		private static IList<HtWt> BestSeqAtIndex(IList<HtWt> array, IList<IList<HtWt>> solutions, int index)
		{
			HtWt value = array[index];

			IList<HtWt> bestSequence = new List<HtWt>();

			for (int i = 0; i < index; i++)
			{
				IList<HtWt> solution = solutions[i];
				if (CanAppend(solution, value))
				{
					bestSequence = Max(solution, bestSequence);
				}
			}

			IList<HtWt> best = bestSequence.ToList();
			best.Add(value);

			return best;
		}

		private static bool CanAppend(IList<HtWt> solution, HtWt value)
		{
			if (solution == null)
			{
				return false;
			}
			if (solution.Count == 0)
			{
				return true;
			}
			HtWt last = solution[solution.Count - 1];
			return last.isBefore(value);
		}

		// Returns longer sequence
		private static IList<HtWt> Max(IList<HtWt> seq1, IList<HtWt> seq2)
		{
			if (seq1 == null)
			{
				return seq2;
			}
			else if (seq2 == null)
			{
				return seq1;
			}
			return seq1.Count > seq2.Count ? seq1 : seq2;
		}


		public static IList<HtWt> Initialize()
		{
			IList<HtWt> items = new List<HtWt>();

			HtWt item = new HtWt(65, 60);
			items.Add(item);

			item = new HtWt(70, 150);
			items.Add(item);

			item = new HtWt(56, 90);
			items.Add(item);

			item = new HtWt(75, 190);
			items.Add(item);

			item = new HtWt(60, 95);
			items.Add(item);

			item = new HtWt(68, 110);
			items.Add(item);

			item = new HtWt(35, 65);
			items.Add(item);

			item = new HtWt(40, 60);
			items.Add(item);

			item = new HtWt(45, 63);
			items.Add(item);

			return items;
		}

		public static void PrintList(IList<HtWt> list)
		{
			foreach (HtWt item in list)
			{
				Console.WriteLine(item.ToString() + " ");
			}
		}

		public override void Run()
        {
			IList<HtWt> items = Initialize();
			IList<HtWt> solution = LongestIncreasingSeqB(items);
			PrintList(solution);
		}
    }
}
