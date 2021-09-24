using ctci.Contracts;
using MoreComplexDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
    // 其他與更為最佳化方案
    // 演算法最糟情況
    // Time complexity: O(B log S)
    // 在 GetShortestClosure 方法中處理 B 元素，一次迴圈需要 O(log S) 時間(從最小堆接插入和刪除時間)。
    // 最大使用空間
    // Space complexity: O(SB)
    // B: bigArray 的長度
    // S: smallArray 的長度
    public class Q17_18_Shortest_SupersequenceD : Question
    {
        public static Range ShortestSupersequenceD(int[] big, int[] small)
        {
            IList<Queue<int>> locations = GetLocationsForElements(big, small);
            if (locations == null) return null;
            return GetShortestClosure(locations);
        }

        /* Get list of queues (linked lists) storing the indices at which
		 * each element in smallArray appears in bigArray. */
        public static IList<Queue<int>> GetLocationsForElements(int[] big, int[] small)
        {
            /* Initialize hash map from item value to locations. */
            Dictionary<int, Queue<int>> itemLocations = new Dictionary<int, Queue<int>>();
            foreach (int s in small)
            {
                Queue<int> queue = new Queue<int>();
                itemLocations.Add(s, queue);
            }

            /* Walk through big array, adding the item locations to hash map */
            for (int i = 0; i < big.Length; i++)
            {
                Queue<int> queue = itemLocations.ContainsKey(big[i]) ? itemLocations[big[i]] : null;
                if (queue != null)
                {
                    queue.Enqueue(i);
                }
            }

            IList<Queue<int>> allLocations = new List<Queue<int>>();
            ((List<Queue<int>>)allLocations).AddRange(itemLocations.Values);

            return allLocations;
        }


        public static Range GetShortestClosure(IList<Queue<int>> lists)
        {
            MinHeap<HeapNode> minHeap = new MinHeap<HeapNode>();
            int max = int.MinValue;

            /* Insert min element from each list. */
            for (int i = 0; i < lists.Count; i++)
            {
                Queue<int> list = lists[i];
                if (list == null || list.Count == 0)
                {
                    return null;
                }
                int head = list.Dequeue();
                minHeap.Insert(new HeapNode(head, i));
                max = Math.Max(max, head);
            }

            int min = minHeap.Peek().LocationWithinList;
            int bestRangeMin = min;
            int bestRangeMax = max;

            while (true)
            {
                /* Remove min node. */
                HeapNode n = minHeap.ExtractMin();
                Queue<int> list = lists[n.ListId];

                /* Compare range to best range. */
                min = n.LocationWithinList;
                if (max - min < bestRangeMax - bestRangeMin)
                {
                    bestRangeMax = max;
                    bestRangeMin = min;
                }

                /* If there are no more elements, then there's no more subsequences and we can break. */
                if (list.Count == 0)
                {
                    break;
                }

                /* Add new head of list to heap. */
                n.LocationWithinList = list.Dequeue();
                minHeap.Insert(n);
                max = Math.Max(max, n.LocationWithinList);
            }

            return new Range(bestRangeMin, bestRangeMax);
        }


        public override void Run()
        {
            int[] array = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 9, 7 };
            int[] set = { 1, 5, 9 };
            Console.WriteLine(array.Length);
            Range shortest = ShortestSupersequenceD(array, set);
            if (shortest == null)
            {
                Console.WriteLine("not found");
            }
            else
            {
                Console.WriteLine(shortest.GetStart() + ", " + shortest.GetEnd());
            }
        }
    }
}
