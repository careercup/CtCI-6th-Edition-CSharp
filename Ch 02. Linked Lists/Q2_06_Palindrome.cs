using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;

namespace Chapter02
{
    public class Q2_06_Palindrome : Question
    {
        private class Result
        {
            public LinkedListNode Node;
            public bool result;

            public Result(LinkedListNode node, bool res)
            {
                Node = node;
                result = res;
            }
        }

        private Result IsPalindromeRecurse(LinkedListNode head, int length)
        {
            if (head == null || length == 0)
            {
                return new Result(null, true);
            }

            if (length == 1)
            {
                return new Result(head.Next, true);
            }

            if (length == 2)
            {
                return new Result(head.Next.Next, head.Data == head.Next.Data);
            }

            var res = IsPalindromeRecurse(head.Next, length - 2);

            if (!res.result || res.Node == null)
            {
                return res; // Only "result" member is actually used in the call stack.
            }

            res.result = head.Data == res.Node.Data;
            res.Node = res.Node.Next;

            return res;
        }

        private bool IsPalindrome(LinkedListNode head)
        {
            var size = 0;
            var node = head;

            while (node != null)
            {
                size++;
                node = node.Next;
            }

            var palindrome = IsPalindromeRecurse(head, size);

            return palindrome.result;
        }

        private bool IsPalindrome2(LinkedListNode head)
        {
            var fast = head;
            var slow = head;

            var stack = new Stack<int>();

            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Data);
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            /* Has odd number of elements, so skip the middle */
            if (fast != null)
            {
                slow = slow.Next;
            }

            while (slow != null)
            {
                var top = stack.Pop();
                Console.WriteLine(slow.Data + " " + top);

                if (top != slow.Data)
                {
                    return false;
                }
                slow = slow.Next;
            }

            return true;
        }

        /// <summary>
        /// Another recursive approach.
        /// 
        /// We traverse the Linked List to the end while keeping a reference of the first node.
        /// Palindrome check begins when we recurse to the end of the Linked List:
        /// 1) Compare the two nodes (one from start and one from the back)
        /// 2) Advance the "front" node because by recursing back we get the node before "back"
        /// 3) Return isPalindrome
        /// </summary>
        /// <param name="head">First node of the Linked List</param>
        /// <returns></returns>
        private bool IsPalindrome3(LinkedListNode head)
        {
            return (head == null) || (head.Next == null) || IsPalindrome3Recurse(ref head, head.Next);
        }

        private bool IsPalindrome3Recurse(ref LinkedListNode front, LinkedListNode back)
        {
            bool isPalindrome = true;

            if (back.Next != null)
                isPalindrome = IsPalindrome3Recurse(ref front, back.Next);

            isPalindrome &= front.Data == back.Data;
            front = front.Next;
            return isPalindrome;
        }

        /// <summary>
        /// This solution takes advantage of the LIFO (Last In First Out) and FIFO (First In First Out) buffers.
        /// 
        /// The idea is that we fill both of the buffers with the same nodes
        /// and then we take the nodes back from each and compare them. 
        /// Since LIFO will return a node from the end of the list and
        /// FIFO will return the node from the start, we are able to check if 
        /// the Linked List is a palindrome.
        /// 
        /// Also this solution can be further improved by comparing only the half of the nodes from each buffer,
        /// because right now we unnecessarily continue to compare nodes after we hit the middle of the Linked List.
        /// </summary>
        /// <param name="head">First node of the Linked List</param>
        /// <returns></returns>
        private bool IsPalindrome4(LinkedListNode head)
        {
            Stack<LinkedListNode> lifo = new Stack<LinkedListNode>();
            Queue<LinkedListNode> fifo = new Queue<LinkedListNode>();

            // Fill the buffers
            while (head != null)
            {
                lifo.Push(head);
                fifo.Enqueue(head);
                head = head.Next;
            }

            // Each cycle compare a node from start with the node from the end
            while (lifo.Count > 0 && fifo.Count > 0)
            {
                if (lifo.Pop().Data != fifo.Dequeue().Data)
                {
                    return false;
                }
            }
            return true;
        }

        public override void Run()
        {
            const int length = 10;
            var nodes = new LinkedListNode[length];

            for (var i = 0; i < length; i++)
            {
                nodes[i] = new LinkedListNode(i >= length / 2 ? length - i - 1 : i, null, null);
            }

            for (var i = 0; i < length; i++)
            {
                if (i < length - 1)
                {
                    nodes[i].SetNext(nodes[i + 1]);
                }

                if (i > 0)
                {
                    nodes[i].SetPrevious(nodes[i - 1]);
                }
            }
            // nodes[length - 2].data = 9; // Uncomment to ruin palindrome

            var head = nodes[0];
            Console.WriteLine(head.PrintForward());
            Console.WriteLine(IsPalindrome(head));
            Console.WriteLine(IsPalindrome2(head));
            Console.WriteLine(IsPalindrome3(head));
            Console.WriteLine(IsPalindrome4(head));
        }
    }
}