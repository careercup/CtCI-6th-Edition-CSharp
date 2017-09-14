using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter02
{
    public class Q2_07_Intersection : Question
    {
        public class TailAndSize
        {
            public LinkedListNode tail;
            public int size;

            public TailAndSize(LinkedListNode tail, int size)
            {
                this.tail = tail;
                this.size = size;
            }
        }

        public static TailAndSize getTailAndSize(LinkedListNode list)
        {
            if (list == null) return null;

            int size = 1;
            LinkedListNode current = list;
            while (current.Next != null)
            {
                size++;
                current = current.Next;
            }
            return new TailAndSize(current, size);
        }

        public static LinkedListNode getKthNode(LinkedListNode head, int k)
        {
            LinkedListNode current = head;
            while (k > 0 && current != null)
            {
                current = current.Next;
                k--;
            }
            return current;
        }

        public static LinkedListNode findIntersection(LinkedListNode list1, LinkedListNode list2)
        {
            if (list1 == null || list2 == null) return null;

            /* Get tail and sizes. */
            TailAndSize result1 = getTailAndSize(list1);
            TailAndSize result2 = getTailAndSize(list2);

            /* If different tail nodes, then there's no intersection. */
            if (result1.tail != result2.tail)
            {
                return null;
            }

            /* Set pointers to the start of each linked list. */
            LinkedListNode shorter = result1.size < result2.size ? list1 : list2;
            LinkedListNode longer = result1.size < result2.size ? list2 : list1;

            /* Advance the pointer for the longer linked list by the difference in lengths. */
            longer = getKthNode(longer, Math.Abs(result1.size - result2.size));

            /* Move both pointers until you have a collision. */
            while (shorter != longer)
            {
                shorter = shorter.Next;
                longer = longer.Next;
            }

            /* Return either one. */
            return longer;
        }

        public override void Run()
        {
            /* Create linked list */
            int[] vals = { -1, -2, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            LinkedListNode list1 = AssortedMethods.CreateLinkedListFromArray(vals);

            int[] vals2 = { 12, 14, 15 };
            LinkedListNode list2 = AssortedMethods.CreateLinkedListFromArray(vals2);

            list2.Next.Next = list1.Next.Next.Next.Next;

            Console.WriteLine(list1.PrintForward());
            Console.WriteLine(list2.PrintForward());

            LinkedListNode intersection = findIntersection(list1, list2);

            Console.WriteLine(intersection.PrintForward());
        }
    }
}