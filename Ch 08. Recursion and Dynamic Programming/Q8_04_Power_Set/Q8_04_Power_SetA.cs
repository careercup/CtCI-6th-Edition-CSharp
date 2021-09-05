using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_04_Power_Set
{
	// 遞迴
	// Time complexity: O(n*2^n)
	// Space complexity: O(n*2^n)
	public class Q8_04_Power_SetA : Question
    {
		public static List<IList<int>> GetSubsets(IList<int> set, int index)
		{
			List<IList<int>> allsubsets;
			if (set.Count == index)
			{ // Base case - add empty set
				allsubsets = new List<IList<int>>();
				allsubsets.Add(new List<int>());
			}
			else
			{
				allsubsets = GetSubsets(set, index + 1);
				int item = set[index];
				IList<IList<int>> moresubsets = new List<IList<int>>();
				foreach (IList<int> subset in allsubsets)
				{
					List<int> newsubset = new List<int>();
					newsubset.AddRange(subset);
					newsubset.Add(item);
					moresubsets.Add(newsubset);
				}
				allsubsets.AddRange(moresubsets);
			}
			return allsubsets;
		}

		public override void Run()
        {
			IList<int> list = new List<int>();
			for (int i = 0; i < 3; i++)
			{
				list.Add(i);
			}
			IList<IList<int>> subsets = GetSubsets(list, 0);
            foreach (var subset in subsets)
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
