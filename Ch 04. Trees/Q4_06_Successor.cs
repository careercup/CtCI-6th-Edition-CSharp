using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;

namespace Chapter04
{
    static partial class TreeNodeExtension
    {
        static public TreeNode Successor(this TreeNode node)
        {
            if (node == null) return null;
            if (node.Right != null) return LeftMost(node.Right);

            var current = node;
            var parent = current.Parent;
            // go up until we're on left instead of right
            while (parent != null && parent.Right == current)
            {
                current = parent;
                parent = current.Parent;
            }
            return parent;
        }

        private static TreeNode LeftMost(TreeNode node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }
    }

    public class Q4_06_Successor : Question
    {

        public override void Run()
        {
            var root = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var node = root.Find(6);
            var successorNode = node.Successor();
            Console.WriteLine($"Successor node of {node.Data} is { successorNode.Data}");

            node = root.Find(1);
            successorNode = node.Successor();
            Console.WriteLine($"Successor node of {node.Data} is { successorNode.Data}");

            node = root.Find(7);
            successorNode = node.Successor();
            Console.WriteLine($"Successor node of {node.Data} is { successorNode.Data}");
        }
    }
}