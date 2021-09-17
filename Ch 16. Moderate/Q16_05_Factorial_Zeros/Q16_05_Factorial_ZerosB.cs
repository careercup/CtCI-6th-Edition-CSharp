using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_05_Factorial_Zeros
{
    public class Q16_05_Factorial_ZerosB : Question
    {
		public static int CountFactZeros(int num)
		{
			int count = 0;
			if (num < 0)
			{
				Console.WriteLine("Factorial is not defined for negative numbers");
				return 0;
			}
			for (int i = 5; num / i > 0; i *= 5)
			{
				count += num / i;
			}
			return count;
		}

		public static int Factorial(int num)
		{
			if (num == 1)
			{
				return 1;
			}
			else if (num > 1)
			{
				return num * Factorial(num - 1);
			}
			else
			{
				return -1; // Error
			}
		}

		public override void Run()
        {
			for (int i = 1; i < 12; i++)
			{
				Console.WriteLine(i + "! (or " + Factorial(i) + ") has " + CountFactZeros(i) + " zeros");
			}
		}
    }
}
