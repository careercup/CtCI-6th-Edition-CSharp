using ctci.Contracts;
using MoreComplexDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_20_Continuous_Median
{
    // 使用最大堆積和最小堆積
    // 中位數查詢
    // Time complexity: O(1)
    // 元素更新
    // Time complexity: O(logn)
    public class Q17_20_Continuous_Median : Question
    {
        private MaxHeap<int> maxHeap;
        private MinHeap<int> minHeap;
        private List<int> minHeapArray;
        private List<int> maxHeapArray;

        public void AddNewNumberAndPrintMedianA(int randomNumber)
        {
            AddNewNumber(randomNumber);
            Console.WriteLine("Random Number = " + randomNumber);
            PrintMinHeapAndMaxHeap();
            Console.WriteLine("\nMedian = " + GetMedian() + "\n");
        }


        public void AddNewNumber(int randomNumber)
        {
            /* Note: addNewNumber maintains a condition that maxHeap.size() >= minHeap.size() */
            if (maxHeap.Count == minHeap.Count)
            {
                if ((minHeap.Count > 0) &&
                        randomNumber > minHeap.Peek())
                {
                    int value = minHeap.ExtractMin();                
                    maxHeap.Insert(value);                    
                    minHeap.Insert(randomNumber);

                    // 因為套件無法直接轉換成 List 或 Array，輔助看結果用
                    minHeapArray.RemoveAt(minHeapArray.FindIndex(n=>n==value));
                    maxHeapArray.Add(value);
                    minHeapArray.Add(randomNumber);
                }
                else
                {
                    maxHeap.Insert(randomNumber);

                    // 因為套件無法直接轉換成 List 或 Array，輔助看結果用
                    maxHeapArray.Add(randomNumber);
                }
            }
            else
            {
                if (randomNumber < maxHeap.Peek())
                {
                    int value = maxHeap.ExtractMax();
                    minHeap.Insert(value);
                    maxHeap.Insert(randomNumber);

                    // 因為套件無法直接轉換成 List 或 Array，輔助看結果用
                    maxHeapArray.RemoveAt(maxHeapArray.FindIndex(n => n == value));
                    minHeapArray.Add(value);
                    maxHeapArray.Add(randomNumber);
                }
                else
                {
                    minHeap.Insert(randomNumber);

                    // 因為套件無法直接轉換成 List 或 Array，輔助看結果用
                    minHeapArray.Add(randomNumber);
                }
            }
        }

        public double GetMedian()
        {
            /* maxHeap is always at least as big as minHeap. So if maxHeap is empty, then minHeap is also. */
            if (maxHeap.Count==0)
            {
                return 0;
            }
            if (maxHeap.Count == minHeap.Count)
            {
                return (minHeap.Peek() + maxHeap.Peek()) / 2.0;
            }
            else
            {
                /* If maxHeap and minHeap are of different sizes, then maxHeap must have one extra element. Return maxHeap�s top element.*/
                return maxHeap.Peek();
            }
        }
        public void PrintMinHeapAndMaxHeap()
        {
            minHeapArray.Sort((a,b)=>b.CompareTo(a));
            maxHeapArray.Sort((a, b) => b.CompareTo(a));

            Console.Write("MinHeap =");
            for (int i = minHeapArray.Count - 1; i >= 0; i--)
            {
                Console.Write(" " + minHeapArray[i]);
            }
            Console.Write("\nMaxHeap =");
            for (int i = 0; i < maxHeapArray.Count; i++)
            {
                Console.Write(" " + maxHeapArray[i]);
            }
        }

        public override void Run()
        {
            int arraySize = 10;
            int range = 7;

            maxHeap = new MaxHeap<int>();
            minHeap = new MinHeap<int>();
            maxHeapArray = new List<int>();
            minHeapArray=new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                int randomNumber = new Random().Next(range + 1);
                AddNewNumberAndPrintMedianA(randomNumber);
            }
        }
    }
}
