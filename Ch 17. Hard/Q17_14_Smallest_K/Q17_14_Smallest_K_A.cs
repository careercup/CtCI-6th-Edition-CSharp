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
	// 方案1: 排序
	// Time complexity: O(nlogn)
	// n: 陣列長度
	public class Q17_14_Smallest_K_A : Question
    {
		public static int[] SmallestK_A(int[] array, int k)
		{
			if (k <= 0 || k > array.Length)
			{
				throw new InvalidEnumArgumentException();
			}

			/* Sort array. */
			Array.Sort(array);

			/* Copy first k elements. */
			int[] smallest = new int[k];
			for (int i = 0; i < k; i++)
			{
				smallest[i] = array[i];
			}
			return smallest;
		}


		public override void Run()
        {
			int[] array = { 1, 5, 2, 9, 1, 11, 6, 13, 15 };
			int[] smallest = SmallestK_A(array, 3);
			Console.WriteLine(AssortedMethods.ArrayToString(smallest));
		}
    }
}
