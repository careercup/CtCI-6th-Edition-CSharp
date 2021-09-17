using ctci.Contracts;
using System;

namespace Chapter16
{
    public class Q16_01_Number_Swapper : Question
    {
		public static void SwapA(int a, int b)
		{
			// Example for a = 9, b = 4
			a = a - b; // a = 9 - 4 = 5
			b = a + b; // b = 5 + 4 = 9
			a = b - a; // a = 9 - 5

			Console.WriteLine("a: " + a);
			Console.WriteLine("b: " + b);
		}

		public static void SwapB(int a, int b)
		{
			a = a ^ b;
			b = a ^ b;
			a = a ^ b;

			Console.WriteLine("a: " + a);
			Console.WriteLine("b: " + b);
		}

		public override void Run()
        {
			int a = 1672;
			int b = 9332;

			Console.WriteLine("a: " + a);
			Console.WriteLine("b: " + b);

			SwapA(a, b);
			SwapB(a, b);
		}
    }
}
