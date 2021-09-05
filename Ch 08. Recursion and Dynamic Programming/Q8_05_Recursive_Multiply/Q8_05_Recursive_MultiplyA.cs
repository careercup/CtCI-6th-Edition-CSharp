using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_05_Recursive_Multiply
{
    public class Q8_05_Recursive_MultiplyA : Question
    {
		public static int Counter { get; private set; } = 0;

		public static int MinProductA(int a, int b)
		{
			int bigger = a < b ? b : a;
			int smaller = a < b ? a : b;
			return MinProductHelper(smaller, bigger);
		}

		public static int MinProductHelper(int smaller, int bigger)
		{
			if (smaller == 0)
			{ // 0 x bigger = 0
				return 0;
			}
			else if (smaller == 1)
			{ // 1 x bigger = bigger
				return bigger;
			}

			/* Compute half. If uneven, compute other half. If even,
			 * double it. */
			int s = smaller >> 1; // Divide by 2
			int side1 = MinProductHelper(s, bigger);
			int side2 = side1;
			if (smaller % 2 == 1)
			{
				Counter++;
				side2 = MinProductHelper(smaller - s, bigger);
			}
			Counter++;
			return side1 + side2;
		}

		public static int Sum(int x, int y)
		{
			Counter++;
			return x + y;
		}

		public override void Run()
        {
			int a = 13494;
			int b = 22323;
			int product = a * b;
			int minProduct = MinProductA(a, b);
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
