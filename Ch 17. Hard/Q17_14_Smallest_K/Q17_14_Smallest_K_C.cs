using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_14_Smallest_K
{
    // 方案3: 選擇排名演算法(有相同元素)
    public class Q17_14_Smallest_K_C : Question
    {
        public static int[] SmallestK_C(int[] array, int k)
        {
            if (k <= 0 || k > array.Length)
            {
                throw new InvalidEnumArgumentException();
            }

            int threshold = Rank(array, k - 1);
            int[] smallest = new int[k];
            int count = 0;
            foreach (int a in array)
            {
                if (a <= threshold)
                {
                    smallest[count] = a;
                    count++;
                }
            }
            return smallest;
        }

        /* Get item with rank. */
        public static int Rank(int[] array, int rank)
        {
            return Rank(array, 0, array.Length - 1, rank);
        }

        /* Get element with rank between left and right indices. */
        public static int Rank(int[] array, int left, int right, int rank)
        {
            int pivot = array[RandomIntInRange(left, right)];
            int leftEnd = Partition(array, left, right, pivot); // returns end of left partition
            int leftSize = leftEnd - left + 1;
            if (rank == leftSize - 1)
            {
                return Max(array, left, leftEnd);
            }
            else if (rank < leftSize)
            {
                return Rank(array, left, leftEnd, rank);
            }
            else
            {
                return Rank(array, leftEnd + 1, right, rank - leftSize);
            }
        }

        /* Partition array around pivot such that all elements <= pivot
		 * come before all elements > pivot. */
        public static int Partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                if (array[left] > pivot)
                {
                    /* Left is bigger than pivot. Swap it to the right
					 * side, where we know it should be. */
                    Swap(array, left, right);
                    right--;
                }
                else if (array[right] <= pivot)
                {
                    /* Right is smaller than the pivot. Swap it to the 
					 * left side, where we know it should be. */
                    Swap(array, left, right);
                    left++;
                }
                else
                {
                    /* Left and right are in correct places. Expand both
					 * sides. */
                    left++;
                    right--;
                }
            }
            return left - 1;
        }

        /* Get random integer within range, inclusive. */
        public static int RandomIntInRange(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(max + 1 - min) + min;
        }

        /* Swap values at index i and j. */
        public static void Swap(int[] array, int i, int j)
        {
            int t = array[i];
            array[i] = array[j];
            array[j] = t;
        }

        /* Get largest element in array between left and right indices. */
        public static int Max(int[] array, int left, int right)
        {
            int max = int.MinValue;
            for (int i = left; i <= right; i++)
            {
                max = Math.Max(array[i], max);
            }
            return max;
        }

        public override void Run()
        {
            int[] array = { 1, 5, 2, 9, -1, 11, 6, 13, 15 };
            int[] smallest = SmallestK_C(array, 3);
            Console.WriteLine(AssortedMethods.ArrayToString(smallest));
        }
    }
}
