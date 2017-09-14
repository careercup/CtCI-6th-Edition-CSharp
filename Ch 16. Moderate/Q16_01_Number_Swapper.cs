using ctci.Contracts;
using System;

namespace Chapter16
{
    public class Q16_01_Number_Swapper : Question
    {
        void SwapNumbers(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public override void Run()
        {
            var a = 5;
            var b = 10;
            Console.WriteLine($"Before {a}   {b}");
            SwapNumbers(ref a, ref b);
            Console.WriteLine($"After  {a}   {b}");
        }
    }
}
