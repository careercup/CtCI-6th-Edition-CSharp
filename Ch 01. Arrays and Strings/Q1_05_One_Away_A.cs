using ctci.Contracts;
using System;

namespace Chapter01
{
    public class Q1_05_One_Away_A : Question
    {
        public static bool OneEditReplace(string s1, string s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDifference)
                    {
                        return false;
                    }

                    foundDifference = true;
                }
            }
            return true;
        }

        /* Check if you can insert a character into s1 to make s2. */

        public static bool OneEditInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }
                    index2++;
                }
                else {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        public static bool OneEditAwayA(string first, string second)
        {
            // Time complexity: O(n)
            // Space complexity: O(1)
            if (first.Length == second.Length)
            {
                return OneEditReplace(first, second);
            }
            else if (first.Length + 1 == second.Length)
            {
                return OneEditInsert(first, second);
            }
            else if (first.Length - 1 == second.Length)
            {
                return OneEditInsert(second, first);
            }
            return false;
        }

        public static bool OneEditAwayB(string first, string second)
        {
            // Time complexity: O(n)
            // Space complexity: O(1)

            /* Length checks. */
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            /* Get shorter and longer string.*/
            string s1 = first.Length < second.Length ? first : second;
            string s2 = first.Length < second.Length ? second : first;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    /* Ensure that this is the first difference found.*/
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (s1.Length == s2.Length)
                    { // On replace, move shorter pointer
                        index1++;
                    }
                }
                else {
                    index1++; // If matching, move shorter pointer
                }
                index2++; // Always move pointer for longer string
            }
            return true;
        }

        public override void Run()
        {
            string a = "pse";
            string b = "pale";
            bool isOneEdit = OneEditAwayA(a, b);
            Console.WriteLine("{0}, {1}: {2}", a, b, isOneEdit);

            bool isOneEdit2 = OneEditAwayB(a, b);
            Console.WriteLine("{0}, {1}: {2}", a, b, isOneEdit2);
        }
    }
}