using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace Chapter01
{
    public class Q1_01_Is_Unique : Question
    {
        // This specific solution approach only works for lowercase a-z, 
        // due to amount of bits in a single int (4 bytes, 32 individual bits).
        // 32 bits accommodates enough bit positions so that each alphabet char (26 of them) have a bit.
        private bool IsUniqueChars(string str)
        {
            // 26 chars in the alphabet. If string is longer, then we must have a repeated character.
            if (str.Length > 26)
            {
                return false;
            }
            
            // This int (below) is used for it's 32 bits ONLY. Each bit position corresponds to a specific 
            // character ASCII value e.g. 'a' = 0th bit (from right hand side), 'b' = 1st bit, 'c' = 2nd bit, etc...
            // as ASCII value for 'a' is 0, 'b' is 1, 'c' is 2, etc.
            // The int is used like this: 32 bits=(00000000 00000000 00000000 00000001). This means we've seen char
            // 'a' once so far. (00000000 00000000 00000000 00000011) This means we've seen 'a' once, and 'b' once. 
            int currentCharsSeenBitArray = 0;
            for (int currentChar = 0; currentChar < str.Length; currentChar++)
            {
                // Chars can be cast to ints, since computers represent chars as ASCII values (mentioned above).
                int ASCII_Value = ((int)str[currentChar]) - (int)'a';
                
                // BitWise 'AND' operation below. The idea is that if a bit position in the BitArray (representing
                // a char we've seen in the input string previously) already has a 1 there, then we must have seen
                // this char before. Thus, if you 'AND' two '1' values, you will get a 1 in that bit position. This
                // means you've seen the same char TWICE now. Thus, the BitArray will be larger than 0 as, at-the 
                // end-of-the-day, the BitArray is just an integer value still! 
                if ((currentCharsSeenBitArray & (1 << currentChar)) > 0)
                {
                    return false;
                }
                // BitWise 'OR' will actually save the fact that we have seen the char previously, in the correct bit
                // position. '0' (not seen this char yet) 'OR' '1' (seen this char) will produce '1'. 
                currentCharsSeenBitArray = (currentCharsSeenBitArray | (1 << ASCII_Value));
            }

            return true;  // Iterated through all chars now. No duplicates found, thus return true!
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
