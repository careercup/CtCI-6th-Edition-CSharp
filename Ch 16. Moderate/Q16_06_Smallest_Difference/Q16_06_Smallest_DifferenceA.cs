using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_06_Smallest_Difference
{
	// 暴力解
	// Time complexity: O(AB)
	public class Q16_06_Smallest_DifferenceA : Question
    {
		public static int FindSmallestDifference(int[] arrayA, int[] arrayB)
		{
			if (arrayA.Length == 0 || arrayB.Length == 0) return -1;

			int smallestDifference = int.MaxValue;
			foreach (int a in arrayA)
			{
				foreach (int b in arrayB)
				{
					smallestDifference = Math.Min(smallestDifference, Math.Abs(a - b));
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