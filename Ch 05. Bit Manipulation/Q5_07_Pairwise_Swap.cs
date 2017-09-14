using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter05
{
    public class Q5_07_Pairwise_Swap : Question
    {
        public static int SwapOddEvenBits(int x)
        {
            return (int)(((x & 0xaaaaaaaa) >> 1) | ((x & 0x55555555) << 1));
        }

        public override void Run()
        {
            var a = 103217;
            Console.WriteLine(a + ": " + AssortedMethods.ToFullBinarystring(a));
            var b = SwapOddEvenBits(a);
            Console.WriteLine(b + ": " + AssortedMethods.ToFullBinarystring(b));
        }
    }
}