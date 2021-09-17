using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_06_Count_of_2s
{
	// 暴力解
    public class Q17_06_Count_of_2sA : Question
    {
		public static int NumberOf2sInRange(int n)
		{
			int count = 0;
			for (int i = 2; i <= n; i++)
			{ // Might as well start at 2
				count += NumberOf2s(i);
			}
			return count;
		}

		public static int NumberOf2s(int n)
		{
			int count = 0;
			while (n > 0)
			{
				if (n % 10 == 2)
				{
					count++;
				}
				n /= 10;
			}
			return count;
		}
	

		public override void Run()
        {
			for (int i = 0; i < 1000; i++)
			{
				int v = NumberOf2sInRange(i);
				Console.WriteLine("Between 0 and " + i + ": " + v);
			}
		}
    }
}
