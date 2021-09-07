using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter10
{
    // Time complexity: O(nlogn)
    public class Q10_02_Group_Anagrams : Question
    {
        private class AnagramComparator : IComparer<string>
        {
            private string SortChars(string s)
            {
                char[] content = s.ToCharArray();
                Array.Sort(content);
                return new string(content);
            }

            int IComparer<string>.Compare(string x, string y)
            {
                return SortChars(x).CompareTo(SortChars(y));
            }
        }

        private string SortChars(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }

        private void SortB(string[] array)
        {
            Dictionary<string, LinkedList<string>> hash = new Dictionary<string, LinkedList<string>>();

            /* Group words by anagram */
            foreach (string s in array)
            {
                string key = SortChars(s);
                if (!hash.ContainsKey(key))
                {
                    hash.Add(key, new LinkedList<string>());
                }
                LinkedList<string> anagrams = hash[key];
                anagrams.AddLast(s);
            }

            /* Convert hash table to array */
            int index = 0;
            foreach (string key in hash.Keys)
            {
                LinkedList<string> list = hash[key];
                foreach (string t in list)
                {
                    array[index] = t;
                    index++;
                }
            }
        }

        public override void Run()
        {
            // Solution A
            string[] array = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
            Console.WriteLine(AssortedMethods.StringArrayToString(array));
            Array.Sort(array, new AnagramComparator());
            Console.WriteLine(AssortedMethods.StringArrayToString(array));

            // Solution B
            SortB(array);
            Console.WriteLine(AssortedMethods.StringArrayToString(array));
        }
    }
}