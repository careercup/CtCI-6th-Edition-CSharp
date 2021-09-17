using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_11_Diving_Board
{
    // 最佳化方案
    // Time complexity: O(K)
    // K: 木板數
    public class Q16_11_Diving_BoardC : Question
    {
        public static int counter = 0;

        public static HashSet<int> AllLengths(int k, int shorter, int longer)
        {
            counter++;
            HashSet<int> lengths = new HashSet<int>();
            for (int nShorter = 0; nShorter <= k; nShorter++)
            {
                int nLonger = k - nShorter;
                int length = nShorter * shorter + nLonger * longer;
                lengths.Add(length);
            }
            return lengths;
        }

        public override void Run()
        {
            HashSet<int> lengths = AllLengths(12, 1, 3);
            foreach (var l in lengths)
            {
                Console.Write($"{l}, ");
            }
            Console.WriteLine();
            Console.WriteLine(counter);
        }
    }
}
