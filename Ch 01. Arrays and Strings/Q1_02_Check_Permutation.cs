using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter01
{
    public class Q1_02_Check_Permutation : Question
    {
        private bool IsPermutationA(string original, string valueToTest)
        {
            // Time complexity: O(nlogn)
            // Space complexity: O(n)
            if (original.Length != valueToTest.Length)
            {
                return false;
            }

            else return new string(original.OrderBy(c => c).ToArray()) == new string(valueToTest.OrderBy(c => c).ToArray());
        }

        private bool IsPermutationB(string original, string valueToTest)
        {
            // Time complexity: O(n)
            // Space complexity: O(1)
            if (original.Length != valueToTest.Length) return false;// Permutations must be same length
            else
            {
                int[] letters = new int[128];// Assumption: ASCII
                foreach (var c in original)
                {
                    letters[c]++;
                }
                foreach (var c in valueToTest)
                {
                    letters[c]--;
                    if (letters[c] < 0) return false;
                }
                return true; // letters array has no negative values, and therefore no positive values either
            }
        }

        public override void Run()
        {
            string[][] pairs =
            {
                new string[]{"apple", "papel"},
                new string[]{"carrot", "tarroc"},
                new string[]{"hello", "llloh"}
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                var result1 = IsPermutationA(word1, word2);
                var result2 = IsPermutationB(word1, word2);
                Console.WriteLine("{0}, {1}: {2} / {3}", word1, word2, result1, result2);
            }
        }
    }
}