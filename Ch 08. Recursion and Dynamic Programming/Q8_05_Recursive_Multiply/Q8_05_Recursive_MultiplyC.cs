using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_05_Recursive_Multiply
{
	// Time complexity: O(logs)
	// s : 2個數字較小的一方
	public class Q8_05_Recursive_MultiplyC : Question
    {
		public static int Counter { get; private set; } = 0;

		public static int MinProductC(int a, int b)
		{
			int bigger = a < b ? b : a;
			int smaller = a < b ? a : b;

			return MinProductHelper(smaller, bigger);
		}

		public static int MinProductHelper(int smaller, int bigger)
		{
			if (smaller == 0)
			{
				return 0;
			}
			else if (smaller == 1)
			{
				return bigger;
			}

			int s = smaller >> 1;
			int halfProd = MinProductHelper(s, bigger);

			if (smaller % 2 == 0)
			{
				Counter++;
				return halfProd + halfProd;
			}
			else
			{
				Counter += 2;
				return halfProd + halfProd + bigger;
			}
		}


		public override void Run()
        {
			int a = 13494;
			int b = 22323;
			int product = a * b;
			int minProduct = MinProductC(a, b);
			if (product == minProduct)
			{
				Console.WriteLine("Success: " + a + " * " + b + " = " + product);
			}
			else
			{
				Console.WriteLine("Failure: " + a + " * " + b + " = " + product + " instead of " + minProduct);
			}
			Console.WriteLine("Adds: " + Counter);
		}
    }
}
