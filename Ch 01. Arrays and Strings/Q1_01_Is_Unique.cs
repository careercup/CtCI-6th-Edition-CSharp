using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace Chapter01
{
    public class Q1_01_Is_Unique : Question
    {
        private bool IsUniqueCharsA(string str)
        {
            // Time complexity: O(n)
            // Space complexity: O(n)
            var hashset = new HashSet<char>();
            foreach (var c in str)
            {
                if (hashset.Contains(c)) return false;
                hashset.Add(c);
            }

            return true;
        }

        /* Assumes only letters a through z. */
        private bool IsUniqueCharsB(string str)
        {
            // Time complexity: O(n)
            // Space complexity: O(1)
            if (str.Length > 26) return false; // Only 26 characters
            {
                return false;
            }

            var checker = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var val = str[i] - 'a';

                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }

            return true;
        }

        

        public override void Run()
        {
            string[] words = { "abcde", "hello", "apple", "kite", "padle" };

            foreach (var word in words)
            {
                Console.WriteLine(word + ": " + IsUniqueCharsB(word) + " " + IsUniqueCharsA(word));
            }
        }
    }
}