using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_10_Majority_Element
{
	// 方案1(慢)
	// Time complexity: O(N^2)
	// Space complexity: O(1)
	public class Q17_10_Majority_ElementA : Question
    {
		public static int FindMajorityElementA(int[] array)
		{
			foreach (int x in array)
			{
				if (Validate(array, x))
				{
					return x;
				}
			}
			return -1;
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
			Console.WriteLine(FindMajorityElementA(array));
		}
    }
}
