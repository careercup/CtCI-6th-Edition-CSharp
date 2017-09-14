using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter10
{
    public class Q10_11_Peaks_and_Valleys : Question
    {
        public static void Swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        #region Solution A

        public void SortValleyPeak(int[] array)
        {
            Array.Sort(array);
            for (int i = 1; i < array.Length; i += 2)
            {
                Swap(array, i - 1, i);
            }
        }

        #endregion Solution A

        #region Solution B

        public void SortValleyPeak2(int[] array)
        {
            for (int i = 1; i < array.Length; i += 2)
            {
                int biggestIndex = MaxIndex(array, i - 1, i, i + 1);
                if (i != biggestIndex)
                {
                    Swap(array, i, biggestIndex);
                }
            }
        }

        public int MaxIndex(int[] array, int a, int b, int c)
        {
            int len = array.Length;
            int aValue = a >= 0 && a < len ? array[a] : int.MinValue;
            int bValue = b >= 0 && b < len ? array[b] : int.MinValue;
            int cValue = c >= 0 && c < len ? array[c] : int.MinValue;

            int max = Math.Max(aValue, Math.Max(bValue, cValue));

            if (aValue == max)
            {
                return a;
            }
            else if (bValue == max)
            {
                return b;
            }
            else {
                return c;
            }
        }

        #endregion Solution B

        #region Solution C

        public static void SortValleyPeak3(int[] array)
        {
            for (int i = 1; i < array.Length; i += 2)
            {
                if (array[i - 1] < array[i])
                {
                    Swap(array, i - 1, i);
                }
                if (i + 1 < array.Length && array[i + 1] < array[i])
                {
                    Swap(array, i + 1, i);
                }
            }
        }

        public override void Run()
        {
            int[] array = { 48, 40, 31, 62, 28, 21, 64, 40, 23, 17 };

            Console.WriteLine(AssortedMethods.ArrayToString(array));
            SortValleyPeak(array);
            Console.WriteLine(AssortedMethods.ArrayToString(array));

            int[] array2 = { 48, 40, 31, 62, 28, 21, 64, 40, 23, 17 };
            Console.WriteLine(AssortedMethods.ArrayToString(array2));
            SortValleyPeak2(array2);
            Console.WriteLine(AssortedMethods.ArrayToString(array2));

            int[] array3 = { 48, 40, 31, 62, 28, 21, 64, 40, 23, 17 };
            Console.WriteLine(AssortedMethods.ArrayToString(array3));
            SortValleyPeak3(array3);
            Console.WriteLine(AssortedMethods.ArrayToString(array3));
        }

        #endregion Solution C
    }
}