using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter02
{
    public class Q2_02_Return_Kth_To_Last : Question
    {
        private int PrintKthToLastA(LinkedListNode head, int k)
        {
            // Time complexity: O(n)
            // Space complexity: O(n) 考慮Stack空間
            if (k == 0 || head == null)
            {
                return 0;
            }
            else
            {
                var index = PrintKthToLastA(head.Next, k) + 1;

                if (index == k)
                {
                    Console.WriteLine(k + "th to last node is " + head.Data);
                }

                return index;
            }

        }

        private LinkedListNode KthToLastB(LinkedListNode head, int k, ref int i)
        {
            // Time complexity: O(n)
            // Space complexity: O(n) 考慮Stack空間
            if (head == null)
            {
                return null;
            }
            else
            {
                var node = KthToLastB(head.Next, k, ref i);
                i = i + 1;

                if (i == k)
                {
                    return head;
                }

                return node;
            }
            
        }

        private Result KthToLastCHelper(LinkedListNode head, int k)
        {
            if (head == null)
            {
                return new Result(null, 0);
            }

            var result = KthToLastCHelper(head.Next, k);

            if (result.Node == null)
            {
                result.Count++;

                if (result.Count == k)
                {
                    result.Node = head;
                }
            }

            return result;
        }

        private LinkedListNode KthToLastC(LinkedListNode head, int k)
        {
            // Time complexity: O(n)
            // Space complexity: O(n) 考慮Stack空間
            var result = KthToLastCHelper(head, k);

            if (result != null)
            {
                return result.Node;
            }

            return null;
        }

        private LinkedListNode KthToLastD(LinkedListNode head, int k)
        {
            // Time complexity: O(n)
            // Space complexity: O(1)
            var p1 = head;
            var p2 = head;

            /* Move p1 k nodes into the list.*/
            for (int i = 0; i < k; i++)
            {
                if (p1 == null) return null; // Out of bounds
                p1 = p1.Next;
            }

            /* Move them at the same pace. When p1 hits the end, 
             * p2 will be at the right element. */
            while (p1 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p2;
        }

        public override void Run()
        {
            var head = AssortedMethods.RandomLinkedList(10, 0, 10);
            Console.WriteLine(head.PrintForward());
            const int nth = 3;

            var node = KthToLastC(head, nth);
            PrintKthToLastA(head, nth);

            if (node != null)
            {
                Console.WriteLine(nth + "th to last node is " + node.Data);
            }
            else
            {
                Console.WriteLine("Null.  n is out of bounds.");
            }
        }
    }

    internal class Result
    {
        public LinkedListNode Node { get; set; }
        public int Count { get; set; }

        public Result(LinkedListNode node, int count)
        {
            Node = node;
            Count = count;
        }
    }
}