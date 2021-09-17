using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_04_Missing_Number
{
    // Time complexity: O(N)
    public class Q17_04_Missing_Number : Question
    {
        public static int FindMissing(IList<BitInteger> array)
        {
            return FindMissing(array, BitInteger.INTEGER_SIZE - 1);
        }

        private static int FindMissing(IList<BitInteger> input, int column)
        {
            if (column < 0)
            { // Base case and error condition
                return 0;
            }
            IList<BitInteger> oneBits = new List<BitInteger>(input.Count / 2);
            IList<BitInteger> zeroBits = new List<BitInteger>(input.Count / 2);
            foreach (BitInteger t in input)
            {
                if (t.Fetch(column) == 0)
                {
                    zeroBits.Add(t);
                }
                else
                {
                    oneBits.Add(t);
                }
            }
            if (zeroBits.Count <= oneBits.Count)
            {
                int v = FindMissing(zeroBits, column - 1);
                Console.WriteLine("0");
                return (v << 1) | 0;
            }
            else
            {
                int v = FindMissing(oneBits, column - 1);
                Console.WriteLine("1");
                return (v << 1) | 1;
            }
        }

        /* Create a random array of numbers from 0 to n, but skip 'missing' */
        public static IList<BitInteger> Initialize(int n, int missing)
        {
            BitInteger.INTEGER_SIZE = Convert.ToString(n, 2).Length;
            IList<BitInteger> array = new List<BitInteger>();

            for (int i = 1; i <= n; i++)
            {
                array.Add(new BitInteger(i == missing ? 0 : i));
            }

            // Shuffle the array once.
            for (int i = 0; i < n; i++)
            {
                int rand = i + (int)(new Random().NextDouble() * (n - i));
                array[i].SwapValues(array[rand]);
            }

            return array;
        }


        public override void Run()
        {
            Random rand = new Random();
            int n = rand.Next(300000) + 1;
            int missing = rand.Next(n + 1);
            IList<BitInteger> array = Initialize(n, missing);
            Console.WriteLine("The array contains all numbers but one from 0 to " + n + ", except for " + missing);

            int result = FindMissing(array);
            if (result != missing)
            {
                Console.WriteLine("Error in the algorithm!\n" + "The missing number is " + missing + ", but the algorithm reported " + result);
            }
            else
            {
                Console.WriteLine("The missing number is " + result);
            }
        }
    }
}
