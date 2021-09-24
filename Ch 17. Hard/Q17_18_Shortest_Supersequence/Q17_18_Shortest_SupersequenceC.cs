using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
	// 更為最佳化(節省空間)
	// Time complexity: O(SB)
	// Space complexity: O(B)
	// B: bigArray 的長度
	// S: smallArray 的長度
	public class Q17_18_Shortest_SupersequenceC : Question
    {
		public static Range ShortestSupersequenceC(int[] big, int[] small)
		{
			int[] closures = GetClosures(big, small);
			return GetShortestClosure(closures);
		}

		/* Get closure for each index. */
		public static int[] GetClosures(int[] big, int[] small)
		{
			int[] closure = new int[big.Length];
			for (int i = 0; i < small.Length; i++)
			{
				SweepForClosure(big, closure, small[i]);
			}
			return closure;
		}

		/* Do backwards sweep and update the closures list with the next occurrence of value, if it's later than the current closure*/
		public static void SweepForClosure(int[] big, int[] closures, int value)
		{
			int next = -1;
			for (int i = big.Length - 1; i >= 0; i--)
			{
				if (big[i] == value)
				{
					next = i;
				}
				if ((next == -1 || closures[i] < next) && (closures[i] != -1))
				{
					closures[i] = next;
				}
			}
		}

		/* Get shortest closure. */
		public static Range GetShortestClosure(int[] closures)
		{
			if (closures == null || closures.Length == 0) return null;
			Range shortest = new Range(0, closures[0]);
			for (int i = 1; i < closures.Length; i++)
			{
				if (closures[i] == -1)
				{
					break;
				}
				Range range = new Range(i, closures[i]);
				if (!shortest.ShorterThan(range))
				{
					shortest = range;
				}
			}
			if (shortest.Length() <= 0) return null;
			return shortest;
		}

		public override void Run()
        {
			int[] array = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 9, 7 };
			int[] set = { 1, 5, 9 };
			Console.WriteLine(array.Length);
			Range shortest = ShortestSupersequenceC(array, set);
			if (shortest == null)
			{
				Console.WriteLine("not found");
			}
			else
			{
				Console.WriteLine(shortest.GetStart() + ", " + shortest.GetEnd());
			}
		}
    }
}
