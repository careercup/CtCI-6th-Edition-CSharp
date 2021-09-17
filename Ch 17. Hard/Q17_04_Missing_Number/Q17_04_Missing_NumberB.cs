using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_04_Missing_Number
{
    // Time complexity: O(N)
    public class Q17_04_Missing_NumberB : Question
    {
        public static int FindMissing(int[] array)
        {
            int ans = 0;
            foreach (var num in array)
            {
                ans ^= num;
            }
            return ans;
        }
        
        public int[] Initialize(int n, int missing)
        {
            IList<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i != missing) ans.Add(i);
            }
            return ans.ToArray();
        }

        public static void ShuffleArrayIteratively(int[] cards)
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int k = rand.Next(i + 1); // Generate random between 0 and i (inclusive)
                int temp = cards[k];
                cards[k] = cards[i];
                cards[i] = temp;
            }
        }

        public override void Run()
        {
            Random rand = new Random();
            int n = rand.Next(300000) + 1;
            int missing = rand.Next(n + 1);
            var array = Initialize(n, missing);
            ShuffleArrayIteratively(array);
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
