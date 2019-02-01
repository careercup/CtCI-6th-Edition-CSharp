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
            Console.WriteLine("Solution 1");
            var sol1 = new Solution1();
            var result = sol1.Convert(root);
            Display(result.Head);

            Console.WriteLine("Solution 2");
            root = Create(0, 1, 2, 3, 4, 5, 6);
            var sol2 = new Solution2();
            var result2 = sol2.Convert(root);
            Display(result2);

            Console.WriteLine("Solution 3");
            root = Create(0, 1, 2, 3, 4, 5, 6);
            var sol3 = new Solution3();
            var result3 = sol3.Convert(root);
            Display(result3);
        }

        private static void Display(TreeNode curr)
        {
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

        public class Solution2
        {
            public TreeNode Convert(TreeNode root)
            {
                if (root == null) return null;

                var part1 = Convert(root.Left);
                var part2 = Convert(root.Right);

                if (part1 != null)
                {
                    Concat(GetTail(part1), root);
                }

                if (part2 != null)
                {
                    Concat(root, part2);
                }

                return part1 == null ? root : part1;
            }

            private TreeNode GetTail(TreeNode part1)
            {
                if (part1 == null) return null;
                while (part1.Right != null) part1 = part1.Right;
                return part1;
            }

            private void Concat(TreeNode x, TreeNode y)
            {
                x.Right = y;
                y.Left = x;
            }
        }

        public class Solution3
        {
            public TreeNode Convert(TreeNode root)
            {
                TreeNode head = ConvertToCircular(root);
                head.Left.Right = null;
                head.Left = null;
                return head;
            }

            private TreeNode ConvertToCircular(TreeNode root)
            {
                if (root == null) return null;
                var part1 = ConvertToCircular(root.Left);
                var part3 = ConvertToCircular(root.Right);

                if (part1 == null && part3 == null)
                {
                    root.Left = root;
                    root.Right = root;
                    return root;
                }

                var tail3 = part3 == null ? null : part3.Left;

                // Join left to root.
                if (part1 == null)
                {
                    Concat(part3.Left, root);
                }
                else
                {
                    Concat(part1.Left, root);
                }

                // Join right to root.
                if (part3 == null)
                {
                    Concat(root, part1);
                }
                else
                {
                    Concat(root, part3);
                }

                // join right to left
                if (part1 != null && part3 != null)
                {
                    Concat(tail3, part1);
                }

                return part1 == null ? root : part1;
            }

            private void Concat(TreeNode x, TreeNode y)
            {
                x.Right = y;
                y.Left = x;
            }
        }
    }
}
