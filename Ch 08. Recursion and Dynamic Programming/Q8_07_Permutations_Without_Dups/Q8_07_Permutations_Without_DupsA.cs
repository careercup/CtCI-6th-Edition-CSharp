using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_07_Permutations_Without_Dups
{
	// 從前 n-1 個字元的排列組合開始建構
    public class Q8_07_Permutations_Without_DupsA : Question
    {
		public static IList<string> GetPerms(string str)
		{
			if (str == null)
			{
				return null;
			}
			IList<string> permutations = new List<string>();
			if (str.Length == 0)
			{ // base case
				permutations.Add("");
				return permutations;
			}

			char first = str[0]; // get the first character
			string remainder = str.Substring(1); // remove the first character
			IList<string> words = GetPerms(remainder);
			foreach (string word in words)
			{
				for (int j = 0; j <= word.Length; j++)
				{
					string s = InsertCharAt(word, first, j);
					permutations.Add(s);
				}
			}
			return permutations;
		}

		public static string InsertCharAt(string word, char c, int i)
		{
			string start = word.Substring(0, i);
			string end = word.Substring(i);
			return start + c + end;
		}

		public override void Run()
        {
			IList<string> list = GetPerms("abcde");
			Console.WriteLine("There are " + list.Count + " permutations.");
			foreach (string s in list)
			{
				Console.WriteLine(s);
			}
		}
    }
}
