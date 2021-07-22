using ctci.Contracts;
using System;

namespace Chapter01
{
    public class Q1_05_One_Edit_Away : Question
    {
        public override void Run()
        {
            String a = "pse";
            String b = "pale";
            var c = "ple";
            var d = "pele";
            Console.WriteLine($"{a}, {b}: {OneEditAway(a, b)} / {OneEditAwayBook(a, b)}");
            Console.WriteLine($"{b}, {c}: {OneEditAway(b, c)} / {OneEditAwayBook(b, c)}");
            Console.WriteLine($"{b}, {d}: {OneEditAway(b, d)} / {OneEditAwayBook(b, d)}");


        }
        public static bool OneEditReplace(String s1, String s2)
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

        public static bool OneEditInsert(String s1, String s2)
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
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        public static bool OneEditAway(String first, String second)
        {
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

        public static bool OneEditAwayBook(String first, String second)
        {
            /* Length checks. */
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            /* Get shorter and longer string.*/
            String shorter = first.Length < second.Length ? first : second;
            String longer = first.Length < second.Length ? second : first;

            int indexS = 0;
            int indexL = 0;
            bool foundDifference = false;
            while (indexL < longer.Length && indexS < shorter.Length)
            {
                if (shorter[indexS] != longer[indexL])
                {
                    /* Ensure that this is the first difference found.*/
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (shorter.Length == longer.Length)
                    { // On replace, move shorter pointer
                        indexS++;
                    }
                }
                else
                {
                    indexS++; // If matching, move shorter pointer
                }
                indexL++; // Always move pointer for longer string
            }
            return true;
        }

    }
}