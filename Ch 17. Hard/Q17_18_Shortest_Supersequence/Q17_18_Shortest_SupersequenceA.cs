using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
	// 暴力解
	// Time complexity: O(SB^2)
	// Space complexity: O(1)
	// B: bigArray 的長度
	// S: smallArray 的長度
	public class Q17_18_Shortest_SupersequenceA : Question
    {
		public static Range ShortestSupersequenceA(int[] bigArray, int[] smallArray)
		{
			int bestStart = -1;
			int bestEnd = -1;
			for (int i = 0; i < bigArray.Length; i++)
			{
				int end = FindClosure(bigArray, smallArray, i);
				if (end == -1) break;
				if (bestStart == -1 || end - i < bestEnd - bestStart)
				{
					bestStart = i;
					bestEnd = end;
				}
			}
			if (bestStart < 0 || bestEnd < 0)
			{
				return null;
			}
			return new Range(bestStart, bestEnd);
		}

		/* Given an index, find the closure (i.e., the element which terminates a complete
		 * subarray containing all elements in smallArray). This will be the max of the
		 * next locations of each element in smallArray. */
		public static int FindClosure(int[] bigArray, int[] smallArray, int index)
		{
			int max = -1;
			for (int i = 0; i < smallArray.Length; i++)
			{
				int next = FindNextInstance(bigArray, smallArray[i], index);
				if (next == -1)
				{
					return -1;
				}
				max = Math.Max(next, max);
			}
			return max;
		}

		/* Find next instance of element starting from index. */
		public static int FindNextInstance(int[] array, int element, int index)
		{
			for (int i = index; i < array.Length; i++)
			{
				if (array[i] == element)
				{
					return i;
				}
			}
			return -1;
		}

		

		public override void Run()
        {
			int[] array = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 9, 7 };
			int[] set = { 1, 5, 9 };
			Console.WriteLine(array.Length);
			Range shortest = ShortestSupersequenceA(array, set);
			Console.WriteLine(shortest.GetStart() + ", " + shortest.GetEnd());
		}
    }
}
