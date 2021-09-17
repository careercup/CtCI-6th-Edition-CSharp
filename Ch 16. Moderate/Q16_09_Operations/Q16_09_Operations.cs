using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_09_Operations
{
    public class Q16_09_Operations : Question
    {
        // Time complexity: O(a)
        /* Flip a positive sign to negative, or a negative sign to pos */
        public static int Negate(int a)
        {
            int neg = 0;
            int newSign = a < 0 ? 1 : -1;
            while (a != 0)
            {
                neg += newSign;
                a += newSign;
            }
            return neg;
        }

        // Time complexity: O((log a)^2)
        /* Flip a positive sign to negative, or a negative sign to pos */
        public static int NegateOptimized(int a)
        {
            int neg = 0;
            int newSign = a < 0 ? 1 : -1;
            int delta = newSign;
            while (a != 0)
            {
                bool differentSigns = ((a + delta) > 0) != (a > 0);
                if ((a + delta) != 0 && differentSigns)
                { // If delta is too big, reset it.
                    delta = newSign;
                }
                neg += delta;
                a += delta;
                delta += delta; // Double the delta
            }
            return neg;
        }

        /* Subtract two numbers by negating b and adding them */
        public static int Minus(int a, int b)
        {
            return a + Negate(b);
        }

        /* Return absolute value */
        public static int Abs(int a)
        {
            if (a < 0)
            {
                return NegateOptimized(a);
            }
            else return a;
        }

        /* Multiply a by b by adding a to itself b times */
        public static int Multiply(int a, int b)
        {
            if (a < b)
            {
                return Multiply(b, a); // algo is faster if b < a
            }
            int sum = 0;
            for (int i = Abs(b); i > 0; i = Minus(i, 1))
            {
                sum += a;
            }
            if (b < 0)
            {
                sum = NegateOptimized(sum);
            }
            return sum;
        }

        /* Divide a by b by literally counting how many times b can go into
		 * a. That is, count how many times you can add b to itself until you reach a. */
        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArithmeticException("ERROR: Divide by zero.");
            }
            int absA = Abs(a);
            int absB = Abs(b);

            int product = 0;
            int x = 0;
            while (product + absB <= absA)
            { /* don't go past a */
                product += absB;
                x++;
            }

            if ((a < 0 && b < 0) || (a > 0 && b > 0))
            {
                return x;
            }
            else
            {
                return NegateOptimized(x);
            }
        }

        public override void Run()
        {
            int minRange = -100;
            int maxRange = 100;
            int cycles = 100;

            for (int i = 0; i < cycles; i++)
            {
                int a = AssortedMethods.RandomIntInRange(minRange, maxRange);
                int b = AssortedMethods.RandomIntInRange(minRange, maxRange);
                int ans = Minus(a, b);
                if (ans != a - b)
                {
                    Console.WriteLine("ERROR");
                }
                Console.WriteLine(a + " - " + b + " = " + ans);
            }
            for (int i = 0; i < cycles; i++)
            {
                int a = AssortedMethods.RandomIntInRange(minRange, maxRange);
                int b = AssortedMethods.RandomIntInRange(minRange, maxRange);
                int ans = Multiply(a, b);
                if (ans != a * b)
                {
                    Console.WriteLine("ERROR");
                }
                Console.WriteLine(a + " * " + b + " = " + ans);
            }
            for (int i = 0; i < cycles; i++)
            {
                int a = AssortedMethods.RandomIntInRange(minRange, maxRange);
                int b = AssortedMethods.RandomIntInRange(minRange, maxRange);
                Console.Write(a + " / " + b + " = ");
                try
                {
                    int ans = Divide(a, b);
                    if (ans != a / b)
                    {
                        Console.WriteLine("ERROR");
                    }
                    Console.WriteLine(ans);
                }
                catch(ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
