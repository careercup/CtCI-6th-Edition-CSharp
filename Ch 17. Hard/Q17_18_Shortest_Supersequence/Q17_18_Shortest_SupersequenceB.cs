using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
	// 最佳化
	// Time complexity: O(SB)
	// Space complexity: O(SB)
	// B: bigArray 的長度
	// S: smallArray 的長度
	public class Q17_18_Shortest_SupersequenceB : Question
    {
		public static Range ShortestSupersequenceB(int[] big, int[] small)
		{
			int[][] nextElements = GetNextElementsMulti(big, small);
			int[] closures = GetClosures(nextElements);
			return GetShortestClosure(closures);
		}

		/* Create table of next occurrences. */
		public static int[][] GetNextElementsMulti(int[] big, int[] small)
		{
			int[][] nextElements = new int[small.Length][];
			for (int i = 0; i < small.Length; i++)
			{
				nextElements[i] = new int[big.Length];
				nextElements[i] = GetNextElement(big, small[i]);
			}
			return nextElements;
		}

		/* Do backwards sweep to get a list of the next occurrence of value from each index. */
		public static int[] GetNextElement(int[] bigArray, int value)
		{
			int next = -1;
			int[] nexts = new int[bigArray.Length];
			for (int i = bigArray.Length - 1; i >= 0; i--)
			{
				if (bigArray[i] == value)
				{
					next = i;
				}
				nexts[i] = next;
			}
			return nexts;
		}

		/* Get closure for each index. */
		public static int[] GetClosures(int[][] nextElements)
		{
			int[] maxNextElement = new int[nextElements[0].Length];
			for (int i = 0; i < nextElements[0].Length; i++)
			{
				maxNextElement[i] = GetClosureForIndex(nextElements, i);
			}
			return maxNextElement;
		}



		/* Given an index and the table of next elements, find the closure
		 * for this index (which will be the min of this column. */
		public static int GetClosureForIndex(int[][] nextElements, int index)
		{
			int max = -1;
			for (int i = 0; i < nextElements.Length; i++)
			{
				if (nextElements[i][index] == -1)
				{
					return -1;
				}
				max = Math.Max(max, nextElements[i][index]);
			}
			return max;
		}

		

		/* Get shortest closure. */
		public static Range GetShortestClosure(int[] closures)
		{
			int bestStart = -1;
			int bestEnd = -1;
			for (int i = 0; i < closures.Length; i++)
			{
				if (closures[i] == -1)
				{
					break;
				}
				int current = closures[i] - i;
				if (bestStart == -1 || current < bestEnd - bestStart)
				{
					bestStart = i;
					bestEnd = closures[i];
				}
			}
			if (bestStart < 0 || bestEnd < 0)
			{
				return null;
			}
			return new Range(bestStart, bestEnd);
		}

		

		public override void Run()
        {
			int[] array = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 9, 7 };
			int[] set = { 1, 5, 9 };
			Console.WriteLine(array.Length);
			Range shortest = ShortestSupersequenceB(array, set);
			Console.WriteLine(shortest.GetStart() + ", " + shortest.GetEnd());
		}
    }
}
