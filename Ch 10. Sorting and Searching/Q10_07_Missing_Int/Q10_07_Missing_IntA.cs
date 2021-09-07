using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_10._Sorting_and_Searching.Q10_07_Missing_Int
{
    public class Q10_07_Missing_IntA : Question
    {
        public static long numberOfInts = ((long)int.MaxValue) + 1;
        public static byte[] bitfield = new byte[(int)(numberOfInts / 8)];

        public static void FindOpenNumber()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Q10_07_Missing_Int", "input.txt");
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    int n = int.Parse(sr.ReadLine());
                    /* Finds the corresponding number in the bitfield by using
                     * the OR operator to set the nth bit of a byte 
                     * (e.g., 10 would correspond to bit 2 of index 1 in
                     * the byte array). */
                    bitfield[n / 8] |= (byte)(1 << (n % 8));
                }
            }

            for (int i = 0; i < bitfield.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    /* Retrieves the individual bits of each byte. When 0 bit
                     * is found, finds the corresponding value. */
                    if ((bitfield[i] & (1 << j)) == 0)
                    {
                        Console.WriteLine(i * 8 + j);
                        return;
                    }
                }
            }
        }

        public override void Run()
        {
            FindOpenNumber();
        }
    }
}
