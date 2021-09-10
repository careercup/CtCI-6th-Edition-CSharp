using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_07_FizzBuzz
{
	// 單一執行緒
    public class Q15_07_FizzBuzzA : Question
    {
		public static void fizzbuzz(int n)
		{
			for (int i = 1; i <= n; i++)
			{
				if (i % 3 == 0 && i % 5 == 0)
				{
					Console.WriteLine("FizzBuzz");
				}
				else if (i % 3 == 0)
				{
					Console.WriteLine("Fizz");
				}
				else if (i % 5 == 0)
				{
					Console.WriteLine("Buzz");
				}
				else
				{
					Console.WriteLine(i);
				}
			}
		}

		public override void Run()
        {
			fizzbuzz(100);
		}
    }
}
