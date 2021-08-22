using ctci.Contracts;
using System;
using System.Text;

namespace Chapter01
{
    public class Q1_06_String_Compression : Question
    {
        public string compressBadA(string str)
        {
            string compressedString = string.Empty;
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;

                /* If next character is different than current, append this char to result.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedString += str[i] + countConsecutive;
                    countConsecutive = 0;
                }
            }
            return compressedString.Length < str.Length ? compressedString : str;
        }
        

        public static String compressB(String str)
        {
            StringBuilder compressed = new StringBuilder();
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;

                /* If next character is different than current, append this char to result.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return compressed.Length < str.Length ? compressed.ToString() : str;
        }

        private string CompressBetterC(string str)
        {
            int finalLength = CountCompression(str);
            if (finalLength >= str.Length) return str;
            else
            {
                StringBuilder compressed = new StringBuilder(finalLength); // initialize capacity
                int countConsecutive = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    countConsecutive++;

                    /* If next character is different than current, append this char to result.*/
                    if (i + 1 >= str.Length || str[i] != str[i + 1])
                    {
                        compressed.Append(str[i]);
                        compressed.Append(countConsecutive);
                        countConsecutive = 0;
                    }
                }
                return compressed.ToString();
            }
            
        }

        private int CountCompression(string str)
        {
            int compressedLength = 0;
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++) 
            {
                countConsecutive++;

                /* If next character is different than current, append this char to result.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedLength += 1 + countConsecutive.ToString().Length;
                    countConsecutive = 0;
                }
            }
            return compressedLength;
        }

        public override void Run()
        {
            const string original = "abbccccccde";
            var compressed = CompressBetterC(original);
            Console.WriteLine("Original  : {0}", original);
            Console.WriteLine("Compressed: {0}", compressed);
        }
    }
}