using ctci.Contracts;
using System;

namespace Big_O
{
    public class Example_16_Power_of_2 : Question
    {
		public static int PowersOf2(int n)
		{
			if (n < 1)
			{
				return 0;
			}
			else if (n == 1)
			{
				Console.WriteLine(1);
				return 1;
			}
			else
			{
				int prev = PowersOf2(n / 2);
				int curr = prev * 2;
				Console.WriteLine(curr);
				return curr;
			}
		}

		public override void Run()
        {
			PowersOf2(4);
		}
    }
}
