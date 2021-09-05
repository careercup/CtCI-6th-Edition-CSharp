using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_05_Recursive_Multiply
{
    public class Q8_05_Recursive_MultiplyB : Question
    {
		public static int Counter { get; private set; } = 0;


		public static int MinProductB(int a, int b)
		{
			int bigger = a < b ? b : a;
			int smaller = a < b ? a : b;

			int[] memo = new int[Sum(smaller, 1)];
			return MinProduct(smaller, bigger, memo);
		}

		public static int MinProduct(int smaller, int bigger, int[] memo)
		{
			if (smaller == 0)
			{
				return 0;
			}
			else if (smaller == 1)
			{
				return bigger;
			}
			else if (memo[smaller] > 0)
			{
				return memo[smaller];
			}

			/* Compute half. If uneven, compute other half. If even,
			 * double it. */
			int s = smaller >> 1; // Divide by 2
			int side1 = MinProduct(s, bigger, memo); // Compute half
			int side2 = side1;
			if (smaller % 2 == 1)
			{
				Counter++;
				side2 = MinProduct(smaller - s, bigger, memo);
			}

			/* Sum and cache.*/
			Counter++;
			memo[smaller] = side1 + side2;
			return memo[smaller];
		}

		public static int Sum(int x, int y)
		{
			Counter += 1;
			return x + y;
		}

		public override void Run()
        {
			int a = 13494;
			int b = 22323;
			int product = a * b;
			int minProduct = MinProductB(a, b);
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
