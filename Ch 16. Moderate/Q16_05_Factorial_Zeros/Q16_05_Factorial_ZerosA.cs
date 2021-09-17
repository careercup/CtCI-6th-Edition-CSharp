using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_05_Factorial_Zeros
{
    public class Q16_05_Factorial_ZerosA : Question
    {
		public static int FactorsOf5(int i)
		{
			int count = 0;
			while (i % 5 == 0)
			{
				count++;
				i /= 5;
			}
			return count;
		}

		public static int CountFactZeros(int num)
		{
			int count = 0;
			for (int i = 2; i <= num; i++)
			{
				count += FactorsOf5(i);
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
