using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_04_Power_Set
{
    public class Q8_04_Power_SetB : Question
    {
		// 組合數學
		// Time complexity: O(2^n)
		// Space complexity: O(2^n)
		public static IList<IList<int>> GetSubsetsB(IList<int> set)
		{
			IList<IList<int>> allsubsets = new List<IList<int>>();
			int max = 1 << set.Count; /* Compute 2^n */
			for (int k = 0; k < max; k++)
			{
				IList<int> subset = ConvertIntToSet(k, set);
				allsubsets.Add(subset);
			}
			return allsubsets;
		}
		public static IList<int> ConvertIntToSet(int x, IList<int> set)
		{
			IList<int> subset = new List<int>();
			int index = 0;
			for (int k = x; k > 0; k >>= 1)
			{
				if ((k & 1) == 1)
				{
					subset.Add(set[index]);
				}
				index++;
			}
			return subset;
		}


		public override void Run()
        {
			IList<int> list = new List<int>();
			for (int i = 0; i < 3; i++)
			{
				list.Add(i);
			}

			IList<IList<int>> subsets2 = GetSubsetsB(list);
			foreach (var subset in subsets2)
			{
				foreach (var item in subset)
				{
					Console.Write($"{item}, ");
				}
				Console.WriteLine();
			}
		}
    }
}
