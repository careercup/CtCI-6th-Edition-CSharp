using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_09_Kth_Multiple
{
	// 暴力解
	// Time complexity: O(k^3 log k)
	public class Q17_09_Kth_MultipleA : Question
    {
		public static int GetKthMagicNumberA(int k)
		{
			List<int> possibilities = AllPossibleKFactors(k);
			possibilities.Sort();
			return possibilities[k];
		}

		public static List<int> AllPossibleKFactors(int k)
		{
			List<int> values = new List<int>();
			for (int a = 0; a <= k; a++)
			{ // 3
				double powA = Math.Pow(3, a);
				for (int b = 0; b <= k; b++)
				{ // 5
					double powB = Math.Pow(5, b);
					for (int c = 0; c <= k; c++)
					{ // 7
						double powC = Math.Pow(7, c);
						double value = powA * powB * powC;
						if (value < 0 || powA >= int.MaxValue || powB >= int.MaxValue|| powC >= int.MaxValue || value>= int.MaxValue)
						{
							value = int.MaxValue;
						}
						values.Add((int)value);
					}
				}
			}
			return values;
		}

		

		public override void Run()
        {
			for (int i = 0; i < 50; i++)
			{
				Console.WriteLine(i + " : " + GetKthMagicNumberA(i));
			}
		}
    }
}
