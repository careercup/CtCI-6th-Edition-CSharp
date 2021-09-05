using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_09_Parens
{
    public class Q8_09_ParensA : Question
    {
		public static HashSet<string> GenerateParensA(int remaining)
		{
			HashSet<string> set = new HashSet<string>();
			if (remaining == 0)
			{
				set.Add("");
			}
			else
			{
				HashSet<string> prev = GenerateParensA(remaining - 1);
				foreach (string str in prev)
				{
					for (int i = 0; i < str.Length; i++)
					{
						if (str[i] == '(')
						{
							string s = InsertInside(str, i);
							/* Add s to set if it is not already in there. Note: 	
							 * HashHashSet automatically checks for duplicates before
							 * adding, so an explicit check is not necessary. */
							set.Add(s);
						}
					}
					set.Add("()" + str);
				}
			}
			return set;
		}


		public static string InsertInside(string str, int leftIndex)
		{
			string left = str.Substring(0, leftIndex + 1);
			string right = str.Substring(leftIndex + 1);
			return left + "()" + right;
		}

		

		public override void Run()
        {
			HashSet<string> list = GenerateParensA(4);
			foreach (string s in list)
			{
				Console.WriteLine(s);
			}
			Console.WriteLine(list.Count);
		}
    }
}
