using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter16
{
    public class Q16_06_Smallest_Difference : Question
    {
        public override void Run()
        {
            var input1 = new int[] {1,3,15,11,2 };
            var input2 = new int[] { 23, 127, 235, 19, 8 };
            var smallestPair = GetSmallestDifferencePair(input1, input2);
            var difference = Math.Abs(smallestPair.Item1 - smallestPair.Item2);
            Console.WriteLine($"Pair {smallestPair.Item1},{smallestPair.Item2} has the smallest difference of {difference}");
        }

        public Tuple<int,int> GetSmallestDifferencePair(int[] input1, int[] input2)
        {
            Array.Sort(input1);
            Array.Sort(input2);
            var item1 = default(int);
            var item2 = default(int);
            var minDifference = int.MaxValue;
            var index1 = 0;
            var index2 = 0;
            while (index1 < input1.Length && index2 < input2.Length)
            {
                var value1 = input1[index1];
                var value2 = input2[index2];
                var difference = Math.Abs(value1 - value2);
                if (difference < minDifference)
                {
                    minDifference = difference;
                    item1 = value1;
                    item2 = value2;
                }
                if (value1 < value2)
                    index1++;
                else
                    index2++;
            }

            return Tuple.Create(item1, item2);
        }
    }
}
