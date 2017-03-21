﻿using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter02
{
    public class Q2_08_Loop_Detection : Question
    {
        private LinkedListNode FindBeginning(LinkedListNode head)
        {
            var slow = head;
            var fast = head;

            // Find meeting point
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    break;
                }
            }

            // Error check - there is no meeting point, and therefore no loop
            if (fast == null || fast.Next == null)
            {
                return null;
            }

            /* Move slow to Head. Keep fast at Meeting Point. Each are k steps
            /* from the Loop Start. If they move at the same pace, they must
             * meet at Loop Start. */
            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            // Both now point to the start of the loop.
            return fast;
        }

        public override void Run()
        {
            const int listLength = 10;
            const int k = 3;

            // Create linked list
            var nodes = new LinkedListNode[listLength];

            for (var i = 1; i <= listLength; i++)
            {
                nodes[i - 1] = new LinkedListNode(i, null, i - 1 > 0 ? nodes[i - 2] : null);
                Console.Write("{0} -> ", nodes[i - 1].Data);
            }
            Console.WriteLine();

            // Create loop;
            nodes[listLength - 1].Next = nodes[listLength - k - 1];
            Console.WriteLine("{0} -> {1}", nodes[listLength - 1].Data, nodes[listLength - k - 1].Data);

            var loop = FindBeginning(nodes[0]);

            if (loop == null)
            {
                Console.WriteLine("No Cycle.");
            }
            else
            {
                Console.WriteLine(loop.Data);
            }
        }
    }
}