using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter04
{
    public class Q4_04_CheckBalanced: Question
    {
        public static bool IsBalancedBruteA(TreeNode root)
        {
            // Time complexity: O(nlogn)
            if (root == null) return true;
            var difference = Math.Abs(Height(root.Left) - Height(root.Right));
            if (difference > 1) return false;
            else return IsBalancedBruteA(root.Left) && IsBalancedBruteA(root.Right);
        }

        public static int Height(TreeNode root)
        {
            if (root == null) return -1;
            return Math.Max(Height(root.Left), Height(root.Right)) + 1;
        }

        public static bool IsBalancedImprovedB(TreeNode root)
        {
            return CheckHeight(root) != int.MinValue;
        }

        private static int CheckHeight(TreeNode root)
        {
            if (root == null) return -1;
            var leftHeight = CheckHeight(root.Left);
            if (leftHeight == int.MinValue) return int.MinValue;

            var rightHeight = CheckHeight(root.Right);
            if (rightHeight == int.MinValue) return int.MinValue;

            if (Math.Abs(leftHeight - rightHeight) > 1) return int.MinValue; // Found error -> pass it back
            else return (Math.Max(leftHeight, rightHeight) + 1);
        }

        public override void Run()
        {
            var root = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            PrintTree(root);

            root = new TreeNode(2);
            root.SetLeftChild(new TreeNode(1));
            root.Left.SetLeftChild(new TreeNode(3));
            PrintTree(root);
        }

        private static void PrintTree(TreeNode root)
        {
            BTreePrinter.Print(root);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var isBalanced1 = IsBalancedBruteA(root);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            if (isBalanced1)
                Console.WriteLine("Tree is balanced");
            else
                Console.WriteLine("Tree is not balalnced");
            Console.WriteLine($"Elapsed milliconds {elapsedMs}");

            watch = System.Diagnostics.Stopwatch.StartNew();
            var isBalanced2 = IsBalancedImprovedB(root);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            if (IsBalancedImprovedB(root))
                Console.WriteLine("Tree is balanced");
            else
                Console.WriteLine("Tree is not balalnced");
            Console.WriteLine($"Elapsed milliconds {elapsedMs}");
        }
    }
}