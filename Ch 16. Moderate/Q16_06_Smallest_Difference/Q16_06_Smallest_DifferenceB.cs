using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_06_Smallest_Difference
{
	// 最佳化
	// Time complexity: O(A logA + B logB)
	public class Q16_06_Smallest_DifferenceB : Question
    {
		public static int FindSmallestDifference(int[] arrayA, int[] arrayB)
		{
			if (arrayA.Length == 0 || arrayB.Length == 0) return -1;
			Array.Sort(arrayA);
			Array.Sort(arrayB);
			int indexA = 0;
			int indexB = 0;
			int smallestDifference = int.MaxValue;
			while (indexA < arrayA.Length && indexB < arrayB.Length)
			{
				int difference = Math.Abs(arrayA[indexA] - arrayB[indexB]);
				smallestDifference = Math.Min(smallestDifference, difference);

				if (arrayA[indexA] < arrayB[indexB])
				{
					indexA++;
				}
				else
				{
					indexB++;
				}
			}
			return smallestDifference;
		}


		public override void Run()
        {
            int[] array1 = { 1, 3, 15, 11, 2 };
            int[] array2 = { 23, 127, 234, 19, 8 };
            int difference = FindSmallestDifference(array1, array2);
            Console.WriteLine(difference);
        }
    }
}
