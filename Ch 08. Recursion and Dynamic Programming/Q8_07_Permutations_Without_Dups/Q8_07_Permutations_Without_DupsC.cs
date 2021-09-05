using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_07_Permutations_Without_Dups
{
    public class Q8_07_Permutations_Without_DupsC : Question
    {
		public static IList<string> GetPerms(string str)
		{
			IList<string> result = new List<string>();
			GetPerms("", str, result);
			return result;
		}

		public static void GetPerms(string prefix, string remainder, IList<string> result)
		{
			if (remainder.Length == 0)
			{
				result.Add(prefix);
			}
			int len = remainder.Length;
			for (int i = 0; i < len; i++)
			{
				string before = remainder.Substring(0, i);
				string after = remainder.Substring(i + 1);
				char c = remainder[i];
				GetPerms(prefix + c, before + after, result);
			}
		}

		

		public override void Run()
        {
			IList<string> list = GetPerms("abc");
			Console.WriteLine("There are " + list.Count + " permutations.");
			foreach (string s in list)
			{
				Console.WriteLine(s);
			}
		}
    }
}
