using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
    public class Q17_18_Shortest_SupersequenceE : Question
    {
		/* Find shortest subarray which contains all elements from small. */
		public static Range ShortestSupersequenceE(int[] big, int[] small)
		{
			if (big.Length < small.Length) return null;

			CountedLookup countedLookup = new CountedLookup(small);
			Range best = null;
			int right = 0;
			countedLookup.IncrementIfFound(big[0]); // Take in left
			for (int left = 0; left < big.Length; left++)
			{
				right = FindClosure(big, right, countedLookup); // Move right to closure end
				if (!countedLookup.AreAllFulfilled())
				{ // No closure -> break
					break;
				}

				/* Update biggest range. */
				int length = right - left + 1;
				if (best == null || best.Length() > length)
				{
					best = new Range(left, right);
				}
				countedLookup.DecrementIfFound(big[left]); // Drop leftmost element
			}
			return best;
		}

		/* Find closure for index, and update countedlookup */
		public static int FindClosure(int[] big, int startIndex, CountedLookup countedLookup)
		{
			int index = startIndex;

			/* Move forward until everything is fulfilled. */
			while (!countedLookup.AreAllFulfilled() && index + 1 < big.Length)
			{
				index++;
				countedLookup.IncrementIfFound(big[index]);
			}
			return index;
		}

		public override void Run()
        {
			int[] array = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 9, 7 };
			int[] set = { 1, 5, 9 };
			Console.WriteLine(array.Length);
			Range shortest = ShortestSupersequenceE(array, set);
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
