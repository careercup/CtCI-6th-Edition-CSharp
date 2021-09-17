using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_05_Letters_and_Numbers
{
	// 最佳化方案
	// Time complexity: O(N)
	public class Q17_05_Letters_and_NumbersB : Question
    {
		public static char[] FindLongestSubarrayB(char[] array)
		{
			/* Compute deltas betw count of numbers and count of letters. */
			int[] deltas = ComputeDeltaArray(array);

			/* Find pair in deltas with matching values and largest span. */
			int[] match = FindLongestMatch(deltas);

			/* Return the subarray. Note that it starts one *after* the 
			 * initial occurence of this delta. */
			return Extract(array, match[0] + 1, match[1]);
		}

		/* Compute the difference between the number of letters and 
		 * numbers between the beginning of the array and each index. */
		public static int[] ComputeDeltaArray(char[] array)
		{
			int[] deltas = new int[array.Length];
			int delta = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (char.IsLetter(array[i]))
				{
					delta++;
				}
				else if (char.IsDigit(array[i]))
				{
					delta--;
				}
				deltas[i] = delta;
			}
			return deltas;
		}

		/* Find the matching pair of values in the deltas array with the 
		 * largest difference in indices. */
		public static int[] FindLongestMatch(int[] deltas)
		{
			IDictionary<int, int> map = new Dictionary<int, int>();
			map[0] = -1;
			int[] max = new int[2];
			for (int i = 0; i < deltas.Length; i++)
			{
				if (!map.ContainsKey(deltas[i]))
				{
					map.Add(deltas[i], i);
				}
				else
				{
					int match = map[deltas[i]];
					int distance = i - match;
					int longest = max[1] - max[0];
					if (distance > longest)
					{
						max[1] = i;
						max[0] = match;
					}
				}
			}
			return max;
		}

		public static char[] Extract(char[] array, int start, int end)
		{
			if (start > end) return null;
			char[] subarray = new char[end - start + 1];
			for (int i = start; i <= end; i++)
			{
				subarray[i - start] = array[i];
			}
			return subarray;
		}
		

		public static bool IsEqual(char[] array, int start, int end)
		{
			int counter = 0;
			for (int i = start; i < end; i++)
			{
				if (char.IsLetter(array[i]))
				{
					counter++;
				}
				else if (char.IsDigit(array[i]))
				{
					counter--;
				}
			}
			return counter == 0;
		}

		public override void Run()
        {
			char b = '1';
			char a = 'a';
			char[] array = { a, b, a, b, a, b, b, b, b, b, a, a, a, a, a, b, a, b, a, b, b, a, a, a, a, a, a, a };
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i] + " ");
			}
			Console.WriteLine();
			char[] max = FindLongestSubarrayB(array);
			if (max == null)
			{
				Console.WriteLine("No equal subarray");
			}
			else
			{
				Console.WriteLine(max.Length);
				for (int i = 0; i < max.Length; i++)
				{
					Console.Write(max[i] + " ");
				}

				Console.WriteLine("\nIs Valid? " + IsEqual(max, 0, max.Length));
			}
		}
    }
}
