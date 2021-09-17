using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_05_Letters_and_Numbers
{
	// 暴力解
	// Time complexity: O(N^3)
	public class Q17_05_Letters_and_NumbersA : Question
    {
		public static char[] FindLongestSubarrayA(char[] array)
		{
			for (int len = array.Length; len > 1; len--)
			{
				for (int i = 0; i <= array.Length - len; i++)
				{
					if (HasEqualLettersNumbers(array, i, i + len - 1))
					{
						return ExtractSubarray(array, i, i + len - 1);
						// return array.Skip(i).Take(i + len).ToArray();
					}
				}
			}
			return null;
		}


		public static bool HasEqualLettersNumbers(char[] array, int start, int end)
		{
			int counter = 0;
			for (int i = start; i <= end; i++)
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

		public static char[] ExtractSubarray(char[] array, int start, int end)
		{
			if (start > end) return null;
			char[] subarray = new char[end - start + 1];
			for (int i = start; i <= end; i++)
			{
				subarray[i - start] = array[i];
			}
			return subarray;
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
			char[] max = FindLongestSubarrayA(array);
			Console.WriteLine(max.Length);
			for (int i = 0; i < max.Length; i++)
			{
				Console.Write(max[i] + " ");
			}
			Console.WriteLine("\nIs Valid? " + HasEqualLettersNumbers(max, 0, max.Length - 1));
		}
    }
}
