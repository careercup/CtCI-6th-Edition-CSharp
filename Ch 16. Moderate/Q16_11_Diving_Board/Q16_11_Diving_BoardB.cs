using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_11_Diving_Board
{
	// 記憶化方案
	// Time complexity: O(K^2) O((K+1)^2)
	// K: 木板數
	public class Q16_11_Diving_BoardB : Question
    {
		public static int counter = 0;

		public static HashSet<int> AllLengths(int k, int shorter, int longer)
		{
			HashSet<int> lengths = new HashSet<int>();
			HashSet<string> visited = new HashSet<string>();
			GetAllLengths(k, 0, shorter, longer, lengths, visited);
			return lengths;
		}

		public static void GetAllLengths(int k, int total, int shorter, int longer, HashSet<int> lengths, HashSet<String> visited)
		{
			counter++;
			if (k == 0)
			{
				lengths.Add(total);
				return;
			}
			string key = k + " " + total;
			if (visited.Contains(key))
			{
				return;
			}
			GetAllLengths(k - 1, total + shorter, shorter, longer, lengths, visited);
			GetAllLengths(k - 1, total + longer, shorter, longer, lengths, visited);
			visited.Add(key);
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
