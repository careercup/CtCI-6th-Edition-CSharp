using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter10
{
    public class Q10_02_Group_Anagrams : Question
    {
        private class AnagramComparator : IComparer
        {
            private string SortChars(string s)
            {
                char[] content = s.ToCharArray();
                Array.Sort<char>(content);
                return new string(content);
            }

            int IComparer.Compare(Object x, Object y)
            {
                return SortChars((string)x).CompareTo(SortChars((string)y));
            }
        }

        private string SortChars(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort<char>(content);
            return new string(content);
        }

        private void Sort(string[] array)
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
            string[] array = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
            Console.WriteLine(AssortedMethods.StringArrayToString(array));
            Array.Sort(array, new AnagramComparator());
            Console.WriteLine(AssortedMethods.StringArrayToString(array));

            string[] array2 = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
            Sort(array);
            Console.WriteLine(AssortedMethods.StringArrayToString(array));
        }
    }
}