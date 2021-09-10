using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_O
{
    public class QVI_11_Print_Sorted_Strings : Question
    {
		public static int numChars = 26;

		public static void PrintSortedStrings(int remaining)
		{
			PrintSortedStrings(remaining, "");
		}

		public static void PrintSortedStrings(int remaining, string prefix)
		{
			if (remaining == 0)
			{
				if (IsInOrder(prefix))
				{
					Console.WriteLine(prefix);
				}
			}
			else
			{
				for (int i = 0; i < numChars; i++)
				{
					char c = IthLetter(i);
					PrintSortedStrings(remaining - 1, prefix + c);
				}
			}
		}

		public static bool IsInOrder(string s)
		{
			bool isInOrder = true;
			for (int i = 1; i < s.Length; i++)
			{
				int prev = IthLetter(s[i - 1]);
				int curr = IthLetter(s[i]);
				if (prev > curr)
				{
					isInOrder = false;
				}
			}
			return isInOrder;
		}

		public static char IthLetter(int i)
		{
			return (char)(((int)'a') + i);
		}

		public override void Run()
        {
			PrintSortedStrings(5);
		}
    }
}
