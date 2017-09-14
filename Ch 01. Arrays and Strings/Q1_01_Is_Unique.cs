using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace Chapter01
{
    public class Q1_01_Is_Unique : Question
    {
        private bool IsUniqueChars(string str)
        {
            if (str.Length > 256)
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

        private bool IsUniqueChars2(String str)
        {
            var hashset = new HashSet<char>();
            foreach(var c in str)
            {
                if (hashset.Contains(c)) return false;
                hashset.Add(c);
            }

            return true;
        }

        public override void Run()
        {
            string[] words = { "abcde", "hello", "apple", "kite", "padle" };

            foreach (var word in words)
            {
                Console.WriteLine(word + ": " + IsUniqueChars(word) + " " + IsUniqueChars2(word));
            }
        }
    }
}