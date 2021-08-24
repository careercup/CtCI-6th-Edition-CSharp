using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter02
{
    public class Q2_03_Delete_Middle_Node : Question
    {
        // 要刪除的節點為最後一個節點時無解
        private bool DeleteNode(LinkedListNode node)
        {
            // Time complexity: O(1)
            // Space complexity: O(1)
            if (node == null || node.Next == null)
            {
                return false; // Failure
            }

            var next = node.Next;
            node.Data = next.Data;
            node.Next = next.Next;

            return true;
        }

        public override void Run()
        {
            var head = AssortedMethods.RandomLinkedList(10, 0, 10);
            Console.WriteLine(head.PrintForward());

            var deleted = DeleteNode(head.Next.Next.Next.Next); // delete node 4
            Console.WriteLine("deleted? {0}", deleted);
            Console.WriteLine(head.PrintForward());
        }
    }
}