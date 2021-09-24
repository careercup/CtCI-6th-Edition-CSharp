using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_10_Majority_Element
{
	// 方案1(最佳化)
	// Time complexity: O(N)
	// Space complexity: O(1)
	public class Q17_10_Majority_ElementB : Question
    {
		public static int FindMajorityElementB(int[] array)
		{
			int candidate = GetCandidate(array);
			return Validate(array, candidate) ? candidate : -1;
		}

		public static int GetCandidate(int[] array)
		{
			int majority = 0;
			int count = 0;
			foreach (int n in array)
			{
				if (count == 0)
				{
					majority = n;
				}
				if (n == majority)
				{
					count++;
				}
				else
				{
					count--;
				}
			}
			return majority;
		}

		public static bool Validate(int[] array, int majority)
		{
			int count = 0;
			foreach (int n in array)
			{
				if (n == majority)
				{
					count++;
				}
			}

			return count > array.Length / 2;
		}



		public override void Run()
        {
			int[] array = { 0, 0, 1, 2, 2, 0, 1, 0, 1, 1, 1, 1, 1 };
			Console.WriteLine(array.Length);
			Console.WriteLine(FindMajorityElementB(array));
		}
    }
}
