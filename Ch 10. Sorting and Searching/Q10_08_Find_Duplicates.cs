using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter10
{
    public class Q10_08_Find_Duplicates : Question
    {
        public class BitSet
        {
            private int[] bitset;

            public BitSet(int size)
            {
                bitset = new int[(size >> 5) + 1]; // divide by 32
            }

            public bool Get(int pos)
            {
                int wordNumber = (pos >> 5); // divide by 32
                int bitNumber = (pos & 0x1F); // mod 32
                return (bitset[wordNumber] & (1 << bitNumber)) != 0;
            }

            public void Set(int pos)
            {
                int wordNumber = (pos >> 5); // divide by 32
                int bitNumber = (pos & 0x1F); // mod 32
                bitset[wordNumber] |= 1 << bitNumber;
            }
        }

        public static void checkDuplicates(int[] array)
        {
            BitSet bs = new BitSet(32000);
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                int num0 = num - 1; // bitset starts at 0, numbers start at 1
                if (bs.Get(num0))
                {
                    Console.WriteLine(num);
                }
                else {
                    bs.Set(num0);
                }
            }
        }

        public override void Run()
        {
            int[] array = AssortedMethods.RandomArray(30, 1, 30);
            Console.WriteLine(AssortedMethods.ArrayToString(array));
            checkDuplicates(array);
        }
    }
}