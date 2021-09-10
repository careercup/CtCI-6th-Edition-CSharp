using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_10._Sorting_and_Searching.Introduction
{
	// 平均和最差: Time complexity: O(nlogn)
	// Space complexity: 看情況
	public class MergeSortB : Question
    {
		public static void Mergesort(int[] array)
		{
			int[] helper = new int[array.Length];
			Mergesort(array, helper, 0, array.Length - 1);
		}

		public static void Mergesort(int[] array, int[] helper, int low, int high)
		{
			if (low < high)
			{
				int middle = low + (high - low) / 2;
				Mergesort(array, helper, low, middle); // Sort left half
				Mergesort(array, helper, middle + 1, high); // Sort right half
				Merge(array, helper, low, middle, high); // Merge them
			}
		}

		public static void Merge(int[] array, int[] helper, int low, int middle, int high)
		{
			/* Copy both halves into a helper array */
			for (int i = low; i <= high; i++)
			{
				helper[i] = array[i];
			}

			int helperLeft = low;
			int helperRight = middle + 1;
			int current = low;

			/* Iterate through helper array. Compare the left and right
			 * half, copying back the smaller element from the two halves
			 * into the original array. */
			while (helperLeft <= middle && helperRight <= high)
			{
				if (helper[helperLeft] <= helper[helperRight])
				{
					array[current] = helper[helperLeft];
					helperLeft++;
				}
				else
				{ // If right element is smaller than left element
					array[current] = helper[helperRight];
					helperRight++;
				}
				current++;
			}

			/* Copy the rest of the left side of the array into the
			 * target array */
			int remaining = middle - helperLeft;
			for (int i = 0; i <= remaining; i++)
			{
				array[current + i] = helper[helperLeft + i];
			}
		}

		public override void Run()
        {
			int size = 20;
			int[] array = AssortedMethods.RandomArray(size, 0, size - 1);
			int[] validate = new int[size];
			AssortedMethods.PrintIntArray(array);
			for (int i = 0; i < size; i++)
			{
				validate[array[i]]++;
			}
			Mergesort(array);
			for (int i = 0; i < size; i++)
			{
				validate[array[i]]--;
			}
			AssortedMethods.PrintIntArray(array);
			for (int i = 0; i < size; i++)
			{
				if (validate[i] != 0 || (i < (size - 1) && array[i] > array[i + 1]))
				{
					Console.WriteLine("ERROR");
				}
			}
		}
    }
}
