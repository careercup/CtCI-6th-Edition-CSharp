using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter17
{
    public class Q17_12_BiNode : Question
    {
        public override void Run()
        {
            var root = Create(0, 1, 2, 3, 4, 5, 6);
            BTreePrinter.Print(root);
            var sol1 = new Solution1();
            var result = sol1.Convert(root);

            var curr = result.Head;

            while (curr.Right != null)
            {
                Console.Write($"{curr.Data} ");
                curr = curr.Right;
            }
            Console.WriteLine($"{curr.Data} ");

            while (curr.Left != null)
            {
                Console.Write($"{curr.Data} ");
                curr = curr.Left;
            }
            Console.WriteLine($"{curr.Data} ");
        }

        public static TreeNode Create(params int[] sortedArray)
        {
            return Create(sortedArray, 0, sortedArray.Length - 1);
        }

        private static TreeNode Create(int[] sortedArray, int left, int right)
        {
            if (left > right) return null;
            var mid = left + (right - left) / 2;
            var treeNode = new TreeNode(sortedArray[mid]);
            treeNode.SetLeftChild(Create(sortedArray, left, mid - 1));
            treeNode.SetRightChild(Create(sortedArray, mid + 1, right));
            return treeNode;
        }

        public class Solution1
        {
            public NodePair Convert(TreeNode root)
            {
                if (root == null) return null;

                var part1 = Convert(root.Left);
                var part2 = Convert(root.Right);

                if (part1 != null)
                {
                    Concat(part1.Tail, root);
                }

                if (part2 != null)
                {
                    Concat(root, part2.Head);
                }

                return new NodePair(part1 == null ? root : part1.Head, part2 == null ? root : part2.Tail);
            }

            private void Concat(TreeNode x, TreeNode y)
            {
                x.Right = y;
                y.Left = x;
            }

            public class NodePair
            {
                public TreeNode Head { get; private set; }
                public TreeNode Tail { get; private set; }

                public NodePair(TreeNode head, TreeNode tail)
                {
                    this.Head = head;
                    this.Tail = tail;
                }

            }
        }
    }
}
