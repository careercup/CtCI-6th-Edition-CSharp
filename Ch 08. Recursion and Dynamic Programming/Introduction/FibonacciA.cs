using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Introduction
{
    // Time complexity: O(2^n)
    // Space complexity: O(1)
    public class FibonacciA : Question
    {
        public static int Fibonacci(int i)
        {
            if (i == 0)
            {
                return 0;
            }
            if (i == 1)
            {
                return 1;
            }
            return Fibonacci(i - 1) + Fibonacci(i - 2);
        }

        public override void Run()
        {
            int max = 35; // WARNING: If you make this above 40ish, your computer may serious slow down.
            int trials = 10; // Run code multiple times to compute average time.
            double[] times = new double[max]; // Store times


            for (int j = 0; j < trials; j++)
            { // Run this 10 times to compute
                for (int i = 0; i < max; i++)
                {
                    var start = DateTime.Now;
                    Fibonacci(i);
                    var end = DateTime.Now;
                    var time = end - start;
                    times[i] += time.TotalMilliseconds;
                }
            }

            for (int j = 0; j < max; j++)
            {
                 Console.WriteLine(j + ": " + times[j] / trials + "ms");
            }
        }
    }
}
