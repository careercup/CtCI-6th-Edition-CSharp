using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Introduction
{
	// Time complexity: O(n)
	// Space complexity: O(n)
	public class FibonacciB : Question
    {
		public static ulong Fibonacci(int n)
		{
			return Fibonacci(n, new ulong[n + 1]);
		}

		public static ulong Fibonacci(int i, ulong[] memo)
		{
			if (i == 0) return 0;
			else if (i == 1) return 1;

			if (memo[i] == 0)
			{
				memo[i] = Fibonacci(i - 1, memo) + Fibonacci(i - 2, memo);
			}
			return memo[i];
		}

		public override void Run()
        {
			int max = 100; // Make this as big as you want! (Though you'll exceed the bounds of a long around 46)
			int trials = 10; // Run code multiple times to compute average time.
			double[] times = new double[max]; // Store times

			for (int j = 0; j < trials; j++)
			{ // Run this 10 times to compute
				for (int i = 0; i < max; i++)
				{
					var start = DateTime.Now;
					Console.WriteLine(Fibonacci(i));
					var end = DateTime.Now;
					var time = end - start;
					times[i] += time.TotalMilliseconds;
				}
			}

			for (int j = 0; j < max; j++)
			{
				//Console.WriteLine(j + ": " + times[j] / trials + "ms");
			}
		}
    }
}
