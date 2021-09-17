using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_08_Circus_Tower
{
	// 方案1: 遞迴
	// Time complexity: O(2^n)
	// 可使用 memoization 降低時間複雜度
	// 推測: 記錄各 index最佳解，防止重算
	public class Q17_08_Circus_TowerA : Question
    {
		public static IList<HtWt> LongestIncreasingSeqA(IList<HtWt> items)
		{
			((List<HtWt>)items).Sort();
			return BestSeqAtIndex(items, new List<HtWt>(), 0);
		}

		private static IList<HtWt> BestSeqAtIndex(IList<HtWt> array, IList<HtWt> sequence, int index)
		{
			if (index >= array.Count) return sequence;

			HtWt value = array[index];

			IList<HtWt> bestWith = null;
			if (CanAppend(sequence, value))
			{
				IList<HtWt> sequenceWith = sequence.ToList();
				sequenceWith.Add(value);
				bestWith = BestSeqAtIndex(array, sequenceWith, index + 1);
			}

			IList<HtWt> bestWithout = BestSeqAtIndex(array, sequence, index + 1);
			return Max(bestWith, bestWithout);
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
			IList<HtWt> solution = LongestIncreasingSeqA(items);
			PrintList(solution);
		}
    }
}
