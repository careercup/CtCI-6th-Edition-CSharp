using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_09_Parens
{
    public class Q8_09_ParensB : Question
    {
		public static IList<string> GenerateParens(int count)
		{
			char[] str = new char[count * 2];
			IList<string> list = new List<string>();
			AddParen(list, count, count, str, 0);
			return list;
		}

		public static void AddParen(IList<string> list, int leftRem, int rightRem, char[] str, int index)
		{
			if (leftRem < 0 || rightRem < leftRem) return; // invalid state

			if (leftRem == 0 && rightRem == 0)
			{ /* all out of left and right parentheses */
				list.Add(new string(str));
			}
			else
			{
				str[index] = '('; // Add left and recurse
				AddParen(list, leftRem - 1, rightRem, str, index + 1);

				str[index] = ')'; // Add right and recurse
				AddParen(list, leftRem, rightRem - 1, str, index + 1);
			}
		}


		public override void Run()
        {
			IList<string> list = GenerateParens(6);
			foreach (string s in list)
			{
				Console.WriteLine(s);
			}
			Console.WriteLine(list.Count);
		}
    }
}
