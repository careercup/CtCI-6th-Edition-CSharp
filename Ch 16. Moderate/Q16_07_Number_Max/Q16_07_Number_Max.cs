using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_07_Number_Max
{
    public class Q16_07_Number_Max : Question
    {
		/* Flips a 1 to a 0 and a 0 to a 1 */
		public static int Flip(int bit)
		{
			return 1 ^ bit;
		}

		/* Returns 1 if a is positive, and 0 if a is negative */
		public static int Sign(int a)
		{
			return Flip((a >> 31) & 0x1);
		}
		// a-b 溢位時會有問題
		public static int GetMaxNaiveA(int a, int b)
		{
			int k = Sign(a - b);
			int q = Flip(k);
			return a * k + b * q;
		}


		public static int GetMaxB(int a, int b)
		{
			int c = a - b;

			int sa = Sign(a); // if a >= 0, then 1 else 0
			int sb = Sign(b); // if b >= 0, then 1 else 0
			int sc = Sign(c); // depends on whether or not a - b overflows

			/* We want to define a value k which is 1 if a > b and 0 if a < b. 
			 * (if a = b, it doesn't matter what value k is) */

			int use_sign_of_a = sa ^ sb; // If a and b have different signs, then k = sign(a)
			int use_sign_of_c = Flip(sa ^ sb); // If a and b have the same sign, then k = sign(a - b)

			/* We can't use a comparison operator, but we can multiply values by 1 or 0 */
			int k = use_sign_of_a * sa + use_sign_of_c * sc;
			int q = Flip(k); // opposite of k

			return a * k + b * q;
		}

		public override void Run()
        {
			int a = 26;
			int b = -15;

			Console.WriteLine("max_naive(" + a + ", " + b + ") = " + GetMaxNaiveA(a, b));
			Console.WriteLine("max(" + a + ", " + b + ") = " + GetMaxB(a, b));

			a = -15;
			b = 2147483647;

			Console.WriteLine("max_naive(" + a + ", " + b + ") = " + GetMaxNaiveA(a, b));
			Console.WriteLine("max(" + a + ", " + b + ") = " + GetMaxB(a, b));
		}
    }
}
