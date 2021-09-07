using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_10._Sorting_and_Searching.Q10_07_Missing_Int
{
    // 只有 10MB 記憶體
    public class Q10_07_Missing_IntB : Question
    {
        private readonly int size = 8; // Byte.SIZE=8

        public int FindOpenNumber(string filename)
        {
            int rangeSize = (1 << 20); // 2^20 bits (2^17 bytes)

            /* Get count of number of values within each block. */
            int[] blocks = GetCountPerBlock(filename, rangeSize);

            /* Find a block with a missing value. */
            int blockIndex = FindBlockWithMissing(blocks, rangeSize);
            if (blockIndex < 0) return -1;

            /* Create bit vector for items within this range. */
            byte[] bitVector = GetBitVectorForRange(filename, blockIndex, rangeSize);

            /* Find a zero in the bit vector */
            int offset = FindZero(bitVector);
            if (offset < 0) return -1;

            /* Compute missing value. */
            return blockIndex * rangeSize + offset;
        }

        /* Get count of items within each range. */
        public int[] GetCountPerBlock(string filename, int rangeSize)
        {

            int arraySize = (int.MaxValue / rangeSize) + 1;
            int[] blocks = new int[arraySize];

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    int value = int.Parse(sr.ReadLine());
                    blocks[value / rangeSize]++;
                }
            }
            return blocks;
        }

        /* Find a block whose count is low. */
        public int FindBlockWithMissing(int[] blocks, int rangeSize)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] < rangeSize)
                {
                    return i;
                }
            }
            return -1;
        }

        /* Create a bit vector for the values within a specific range. */
        public byte[] GetBitVectorForRange(string filename, int blockIndex, int rangeSize)
        {

            int startRange = blockIndex * rangeSize;
            int endRange = startRange + rangeSize;
            byte[] bitVector = new byte[rangeSize / size];

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    int value = int.Parse(sr.ReadLine());
                    /* If the number is inside the block that's missing 
			         * numbers, we record it */
                    if (startRange <= value && value < endRange)
                    {
                        int offset = value - startRange;
                        int mask = (1 << (offset % size));
                        bitVector[offset / size] |= (byte)mask;
                    }
                }
            }

            return bitVector;
        }

        /* Find bit index that is 0 within byte. */
        public int FindZero(byte b)
        {
            for (int i = 0; i < size; i++)
            {
                int mask = 1 << i;
                if ((b & mask) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        /* Find a zero within the bit vector and return the index. */
        public int FindZero(byte[] bitVector)
        {
            for (int i = 0; i < bitVector.Length; i++)
            {
                if (bitVector[i] != 255)
                { // If not all 1s
                    int bitIndex = FindZero(bitVector[i]);
                    return i * 8 + bitIndex;
                }
            }
            return -1;
        }

        public static void GenerateFile(string filename, int max, int missing)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < max && i >= 0; i++)
                {
                    if (i != missing)
                    {
                        sw.WriteLine(i);
                    }
                    if (i % 10000 == 0)
                    {
                        Console.WriteLine("Now at location: " + i);
                    }
                }
            }
        }

        public override void Run()
        {
            string filename = Path.Combine(Directory.GetCurrentDirectory(), "Q10_07_Missing_Int", "output.txt");
            int max = 10000000;
            int missing = 1234325;
            Console.WriteLine("Generating file...");
            GenerateFile(filename, max, missing);
            Console.WriteLine("Generated file from 0 to " + max + " with " + missing + " missing.");
            Console.WriteLine("Searching for missing number...");
            Console.WriteLine("Missing value: " + FindOpenNumber(filename));
        }
    }
}
