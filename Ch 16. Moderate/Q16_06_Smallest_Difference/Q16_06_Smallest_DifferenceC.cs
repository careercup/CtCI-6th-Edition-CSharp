using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_06_Smallest_Difference
{
	// 最佳化
	// Time complexity: O(A logA + B log A) or O(B logB + A logB) 看 A 和 B 陣列 哪個比較多元素
	public class Q16_06_Smallest_DifferenceC : Question
    {
		public static int FindSmallestDifference(int[] shorter, int[] longer)
		{
			if (shorter.Length == 0 || longer.Length == 0) return -1;
			if (shorter.Length > longer.Length) return FindSmallestDifference(longer, shorter);

			Array.Sort(shorter);

			int smallestDifference = int.MaxValue;
			foreach (int target in longer)
			{
				int closest = GetClosestValue(shorter, target);
				smallestDifference = Math.Min(smallestDifference, Math.Abs(closest - target));
			}

			return smallestDifference;
		}

		public static int GetClosestValue(int[] array, int target)
		{
			int low = 0;
			int high = array.Length - 1;
			int mid;

			while (low <= high)
			{
				mid = low + (high - low) / 2;
				if (array[mid] < target)
				{
					low = mid + 1;
				}
				else if (array[mid] > target)
				{
					high = mid - 1;
				}
				else
				{
					return array[mid];
				}
			}

			int valueA = low < 0 || low >= array.Length ? int.MaxValue : array[low];
			int valueB = high < 0 || high >= array.Length ? int.MaxValue : array[high];
			return Math.Abs(valueA - target) < Math.Abs(valueB - target) ? valueA : valueB; // return closest value
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
