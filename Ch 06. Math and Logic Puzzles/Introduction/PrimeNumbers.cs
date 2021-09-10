using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Introduction
{
    public class PrimeNumbers : Question
    {
		public static bool PrimeNaive(int n)
		{
			for (int i = 2; i < n; i++)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		public static bool PrimeSlightlyBetter(int n)
		{
			int sqrt = (int)Math.Sqrt(n);
			for (int i = 2; i <= sqrt; i++)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		public override void Run()
        {
			for (int i = 2; i < 100; i++)
			{
				if (PrimeSlightlyBetter(i))
				{
					Console.WriteLine(i);
				}
			}
		}
    }
}
