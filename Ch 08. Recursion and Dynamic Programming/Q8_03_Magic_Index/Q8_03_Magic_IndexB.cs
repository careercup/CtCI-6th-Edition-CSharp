using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_03_Magic_Index
{
	// 陣列中有相同的值發生
    public class Q8_03_Magic_IndexB : Question
    {
		// Time complexity: O(n)
		public static int MagicSlowA1(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == i)
				{
					return i;
				}
			}
			return -1;
		}

		// Time complexity: O(logn)
		public static int MagicFastB(int[] array)
		{
			return MagicFastB(array, 0, array.Length - 1);
		}

		public static int MagicFastB(int[] array, int start, int end)
		{
			if (end < start)
			{
				return -1;
			}
			int midIndex = (start + end) / 2;
			int midValue = array[midIndex];
			if (midValue == midIndex)
			{
				return midIndex;
			}
			/* Search left */
			int leftIndex = Math.Min(midIndex - 1, midValue);
			int left = MagicFastB(array, start, leftIndex);
			if (left >= 0)
			{
				return left;
			}

			/* Search right */
			int rightIndex = Math.Max(midIndex + 1, midValue);
			int right = MagicFastB(array, rightIndex, end);

			return right;
		}
		

		/* Creates an array that is sorted */
		public static int[] GetSortedArray(int size)
		{
			int[] array = AssortedMethods.RandomArray(size, -1 * size, size);
			Array.Sort(array);
			return array;
		}

		public override void Run()
        {
			for (int i = 0; i < 1000; i++)
			{
				int size = AssortedMethods.RandomIntInRange(5, 20);
				int[] array = GetSortedArray(size);
				int v2 = MagicFastB(array);
				if (v2 == -1 && MagicSlowA1(array) != -1)
				{
					int v1 = MagicSlowA1(array);
					Console.WriteLine("Incorrect value: index = -1, actual = " + v1 + " " + i);
					Console.WriteLine(AssortedMethods.ArrayToString(array));
					break;
				}
				else if (v2 > -1 && array[v2] != v2)
				{
					Console.WriteLine("Incorrect values: index= " + v2 + ", value " + array[v2]);
					Console.WriteLine(AssortedMethods.ArrayToString(array));
					break;
				}
			}
		}
    }
}
