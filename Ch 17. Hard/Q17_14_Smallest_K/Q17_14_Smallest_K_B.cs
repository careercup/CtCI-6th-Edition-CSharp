using ctci.Contracts;
using ctci.Library;
using MoreComplexDataStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_14_Smallest_K
{
    // 方案2: 最大堆積
    // Time complexity: O(nlogk)
    // n: 陣列長度
    // k: 取得元素數目
    public class Q17_14_Smallest_K_B : Question
    {

        public static int[] SmallestK_B(int[] array, int k)
        {
            if (k <= 0 || k > array.Length)
            {
                throw new InvalidEnumArgumentException();
            }

            MaxHeap<int> heap = GetKMaxHeap(array, k);
            return HeapToIntArray(heap);
        }

        /* Create max heap of smallest k elements. */
        public static MaxHeap<int> GetKMaxHeap(int[] array, int k)
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            foreach (int a in array)
            {
                if (heap.Count < k)
                { // If space remaining
                    heap.Insert(a);
                }
                else if (a < heap.Peek())
                { 
                    // If full and top is small
                    heap.ExtractMax(); // remove highest
                    heap.Insert(a); // insert new element
                }
            }
            return heap;
        }

        /* Convert heap to int array. */
        public static int[] HeapToIntArray(MaxHeap<int> heap)
        {
            int[] array = new int[heap.Count];
            while (heap.Count>0)
            {
                array[heap.Count - 1] = heap.ExtractMax();
            }
            return array;
        }

        

        public override void Run()
        {
            int[] array = { 1, 5, 2, 9, -1, 11, 6, 13, 15 };
            int[] smallest = SmallestK_B(array, 3);
            Console.WriteLine(AssortedMethods.ArrayToString(smallest));
        }
    }
}
