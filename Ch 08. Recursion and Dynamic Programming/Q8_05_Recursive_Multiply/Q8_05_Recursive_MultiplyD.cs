using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_05_Recursive_Multiply
{
    public class Q8_05_Recursive_MultiplyD : Question
    {
		public static int Counter { get; private set; } = 0;

		/* This is an algorithm called the peasant algorithm. 
		 * https://en.wikipedia.org/wiki/Multiplication_algorithm#Peasant_or_binary_multiplication 
		 */
		public static int MinProductD(int a, int b)
		{
			if (a < b) return MinProductD(b, a);
			int value = 0;
			while (a > 0)
			{
				Counter++;
				if ((a % 10) % 2 == 1)
				{
					value += b;
				}
				a >>= 1;
				b <<= 1;
			}
			return value;
		}

		public override void Run()
        {
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					int prod1 = MinProductD(i, j);
					int prod2 = i * j;
					if (prod1 != prod2)
					{
						Console.WriteLine("ERROR: " + i + " * " + j + " = " + prod2 + ", not " + prod1);
					}
				}
			}
		}
    }
}
