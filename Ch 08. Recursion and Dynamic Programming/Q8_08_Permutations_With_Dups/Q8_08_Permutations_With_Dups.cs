using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_08_Permutations_With_Dups
{
    public class Q8_08_Permutations_With_Dups : Question
    {
		public static IList<string> PrintPerms(string s)
		{
			IList<string> result = new List<string>();
			Dictionary<char, int> map = BuildFreqTable(s);
			PrintPerms(map, "", s.Length, result);
			return result;
		}

		public static Dictionary<char, int> BuildFreqTable(string s)
		{
			Dictionary<char, int> map = new Dictionary<char, int>();
			foreach (char c in s)
			{
				if (!map.ContainsKey(c))
				{
					map[c] = 0;
				}
				map[c]++;
			}
			return map;
		}

		public static void PrintPerms(Dictionary<char, int> map, string prefix, int remaining, IList<string> result)
		{
			if (remaining == 0)
			{
				result.Add(prefix);
				return;
			}

			foreach (var c in map.Keys)
			{
				int count = map[c];
				if (count > 0)
				{
					map[c] = count - 1;
					PrintPerms(map, prefix + c, remaining - 1, result);
					map[c] = count;
				}
			}
		}
	


		public override void Run()
        {
			string s = "aabbccc";
			IList<string> result = PrintPerms(s);
			Console.WriteLine("Count: " + result.Count);
			foreach (string r in result)
			{
				Console.WriteLine(r);
			}
		}
    }
}
