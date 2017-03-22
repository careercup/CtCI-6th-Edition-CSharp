using ctci.Contracts;
using System;

namespace Chapter01
{
    public class Q1_04_Palindrome_Permutation : Question
    {
        public static int GetCharNumber(char c)
        {
            var val = char.ToLower(c) - 'a';
            if (0 <= val && val <= 25)
            {
                return val;
            }
            return -1;
        }

        public static int[] BuildCharFrequencyTable(String phrase)
        {
            int[] table = new int[26];
            foreach (char c in phrase)
            {
                int x = GetCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                }
            }
            return table;
        }

        #region Solution 1

        public static bool CheckMaxOneOdd(int[] table)
        {
            bool foundOdd = false;
            foreach (int count in table)
            {
                if (count % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }
                    foundOdd = true;
                }
            }
            return true;
        }

        public static bool IsPermutationOfPalindrome(String phrase)
        {
            int[] table = BuildCharFrequencyTable(phrase);
            return CheckMaxOneOdd(table);
        }

        #endregion Solution 1

        #region Solution 2

        public static bool IsPermutationOfPalindrome2(String phrase)
        {
            int countOdd = 0;
            int[] table = new int[26];
            foreach (char c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);
                if (x != -1)
                {
                    table[x]++;

                    if (table[x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else {
                        countOdd--;
                    }
                }
            }
            return countOdd <= 1;
        }

        #endregion Solution 2

        #region Solution 3

        /* Toggle the ith bit in the integer. */

        public static int Toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;

            int mask = 1 << index;
            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else {
                bitVector &= ~mask;
            }
            return bitVector;
        }

        /* Create bit vector for string. For each letter with value i,
         * toggle the ith bit. */

        public static int MarkBitForOddCharacterCount(String phrase)
        {
            int bitVector = 0;
            foreach (char c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);
                bitVector = Toggle(bitVector, x);
            }
            return bitVector;
        }

        /* Check that exactly one bit is set by subtracting one from the
         * integer and ANDing it with the original integer. */

        public static bool CheckExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }

        public static bool IsPermutationOfPalindrome3(String phrase)
        {
            int bitVector = MarkBitForOddCharacterCount(phrase);
            return bitVector == 0 || CheckExactlyOneBitSet(bitVector);
        }

        #endregion Solution 3

        public override void Run()
        {
            String[] strings = {"Rats live on no evil star",
                            "A man, a plan, a canal, panama",
                            "Lleve",
                            "Tacotac",
                            "asda"};

            foreach (String s in strings)
            {
                bool a = IsPermutationOfPalindrome(s);
                bool b = IsPermutationOfPalindrome2(s);
                bool c = IsPermutationOfPalindrome3(s);
                Console.WriteLine(s);
                if (a == b && b == c)
                {
                    Console.WriteLine("Agree: " + a);
                }
                else {
                    Console.WriteLine("Disagree: " + a + ", " + b + ", " + c);
                }
                Console.WriteLine();
            }
        }
    }
}