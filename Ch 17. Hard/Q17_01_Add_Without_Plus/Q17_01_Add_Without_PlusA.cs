using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_01_Add_Without_Plus
{
    public class Q17_01_Add_Without_PlusA : Question
    {
        public static int Add(int a, int b)
        {
            if (b == 0) return a;
            int sum = a ^ b; // add without carrying
            int carry = (a & b) << 1; // carry, but don't add
            return Add(sum, carry); // recurse
        }

        public override void Run()
        {
            int a = int.MaxValue - 50;
            int b = 92;
            int sum = Add(a, b);
            int intendedSum = a + b;
            if (sum != intendedSum)
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                Console.WriteLine("SUCCESS");
            }
            Console.WriteLine(a + " + " + b + " = " + sum + " vs " + intendedSum);
        }
    }
}
