using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_14_Smallest_K
{
	// 方案4: 選擇排名演算法(若元素均不同)
	public class Q17_14_Smallest_K_D : Question
    {
		public static int[] SmallestK_D(int[] array, int k)
		{
			if (k <= 0 || k > array.Length) throw new InvalidEnumArgumentException();

			int threshold = Rank(array, k - 1);
			int[] smallest = new int[k];
			int count = 0;
			foreach (int a in array)
			{
				if (a < threshold)
				{
					smallest[count] = a;
					count++;
				}
			}

			while (count < k)
			{
				smallest[count] = threshold;
				count++;
			}

			return smallest;
		}

		/* Find value with rank k in array. */
		public static int Rank(int[] array, int k)
		{
			if (k >= array.Length)
			{
				throw new InvalidEnumArgumentException();
			}
			return Rank(array, k, 0, array.Length - 1);
		}

		/* Find value with rank k in sub array between start and end. */
		private static int Rank(int[] array, int k, int start, int end)
		{
			/* Partition array around an arbitrary pivot. */
			int pivot = array[RandomIntInRange(start, end)];
			PartitionResult partition = Partition(array, start, end, pivot);
			int leftSize = partition.LeftSize;
			int middleSize = partition.MiddleSize;

			if (k < leftSize)
			{ // Rank k is on left half
				return Rank(array, k, start, start + leftSize - 1);
			}
			else if (k < leftSize + middleSize)
			{ // Rank k is in middle
				return pivot; // middle is all pivot values
			}
			else
			{ // Rank k is on right
				return Rank(array, k - leftSize - middleSize, start + leftSize + middleSize, end);
			}
		}

		/* Partition result into < pivot, equal to pivot -> bigger than pivot. */
		private static PartitionResult Partition(int[] array, int start, int end, int pivot)
		{
			int left = start; /* Stays at (right) edge of left side. */
			int right = end;  /* Stays at (left) edge of right side. */
			int middle = start; /* Stays at (right) edge of middle. */
			while (middle <= right)
			{
				if (array[middle] < pivot)
				{
					/* Middle is smaller than the pivot. Left is either 
					 * smaller or equal to the pivot. Either way, swap
					 * them. Then middle and left should move by one.
					 */
					Swap(array, middle, left);
					middle++;
					left++;
				}
				else if (array[middle] > pivot)
				{
					/* Middle is bigger than the pivot. Right could have
					 * any value. Swap them, then we know that the new
					 * right is bigger than the pivot. Move right by one.
					 */
					Swap(array, middle, right);
					right--;
				}
				else if (array[middle] == pivot)
				{
					/* Middle is equal to the pivot. Move by one. */
					middle++;
				}
			}
			/* Return sizes of left and middle. */
			return new PartitionResult(left - start, right - left + 1);
		}

		public static int RandomIntInRange(int min, int max)
		{
			Random rand = new Random();
			return rand.Next(max + 1 - min) + min;
		}

		/* Swap values at index i and j. */
		public static void Swap(int[] array, int i, int j)
		{
			int t = array[i];
			array[i] = array[j];
			array[j] = t;
		}

		public override void Run()
        {
			int[] array = { 1, 5, 2, 3, 2, 9, -1, 11, 6, 13, 15, 2 };
			int[] smallest = SmallestK_D(array, 6);
			Console.WriteLine(AssortedMethods.ArrayToString(smallest));
		}
    }
}
