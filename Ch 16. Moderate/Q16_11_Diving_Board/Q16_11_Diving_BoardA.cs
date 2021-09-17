using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_11_Diving_Board
{
	// 遞迴方案
	// Time complexity: O(2^K)
	// K: 深度
	// 每次有2種選擇
	public class Q16_11_Diving_BoardA : Question
    {
		public static int counter = 0;

		public static HashSet<int> AllLengths(int k, int shorter, int longer)
		{
			HashSet<int> lengths = new HashSet<int>();
			GetAllLengths(k, 0, shorter, longer, lengths);
			return lengths;
		}

		public static void GetAllLengths(int k, int total, int shorter, int longer, HashSet<int> lengths)
		{
			counter++;
			if (k == 0)
			{
				lengths.Add(total);
				return;
			}
			GetAllLengths(k - 1, total + shorter, shorter, longer, lengths);
			GetAllLengths(k - 1, total + longer, shorter, longer, lengths);
		}

		public override void Run()
        {
			HashSet<int> lengths = AllLengths(12, 1, 3);
            foreach (var l in lengths)
            {
				Console.Write($"{l}, ");
            }
			Console.WriteLine();
			Console.WriteLine(counter);
		}
    }
}
