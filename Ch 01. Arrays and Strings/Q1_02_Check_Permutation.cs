using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace Chapter01
{
    public class Q1_02_Check_Permutation : Question
    {
        private bool IsPermutation(string original, string valueToTest)
        {
            if (original.Length != valueToTest.Length)
            {
                return false;
            }

            var originalAsArray = original.ToCharArray();
            Array.Sort(originalAsArray);
            original = new string(originalAsArray);

            var valueToTestAsArray = valueToTest.ToCharArray();
            Array.Sort(valueToTestAsArray);
            valueToTest = new string(valueToTestAsArray);

            return original.Equals(valueToTest);
        }

        private bool IsPermutation2(string original, string valueToTest)
        {
            if (original.Length != valueToTest.Length)
            {
                return false;
            }

            var letterCount = new Dictionary<char, int>();

            foreach (var character in original)
            {
                if (letterCount.ContainsKey(character))
                    letterCount[character]++;
                else
                    letterCount[character] = 1;
            }

            foreach (var character in valueToTest)
            {
                if (letterCount.ContainsKey(character))
                {
                    letterCount[character]--;
                    if (letterCount[character] < 0)
                    {
                        return false;
                    }
                }
                else return false;
            }

            return true;
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
                var result1 = IsPermutation(word1, word2);
                var result2 = IsPermutation2(word1, word2);
                Console.WriteLine("{0}, {1}: {2} / {3}", word1, word2, result1, result2);
            }
        }
    }
}