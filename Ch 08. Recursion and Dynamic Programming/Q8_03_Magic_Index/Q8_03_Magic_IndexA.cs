using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_03_Magic_Index
{
    public class Q8_03_Magic_IndexA : Question
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
		public static int MagicFastA2(int[] array)
		{
			return MagicFastA2(array, 0, array.Length - 1);
		}

		public static int MagicFastA2(int[] array, int start, int end)
		{
			if (end < start)
			{
				return -1;
			}
			int mid = (start + end) / 2;
			if (array[mid] == mid)
			{
				return mid;
			}
			else if (array[mid] > mid)
			{
				return MagicFastA2(array, start, mid - 1);
			}
			else
			{
				return MagicFastA2(array, mid + 1, end);
			}
		}

		

		/* Creates an array that is distinct and sorted */
		public static int[] GetDistinctSortedArray(int size)
		{
			int[] array = AssortedMethods.RandomArray(size, -1 * size, size);
			Array.Sort(array);
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] == array[i - 1])
				{
					array[i]++;
				}
				else if (array[i] < array[i - 1])
				{
					array[i] = array[i - 1] + 1;
				}
			}
			return array;
		}

		public override void Run()
        {
			for (int i = 0; i < 1000; i++)
			{
				int size = AssortedMethods.RandomIntInRange(5, 20);
				int[] array = GetDistinctSortedArray(size);
				int v2 = MagicFastA2(array);
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
