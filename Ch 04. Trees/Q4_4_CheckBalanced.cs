using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter04
{
    public class Q4_4_CheckBalanced: Question
    {
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var difference = Math.Abs(Height(root.Left) - Height(root.Right));
            if (difference > 1) return false;
            else return IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        public static int Height(TreeNode root, int height = 0)
        {
            if (root == null) return height;
            return Math.Max(Height(root.Left, height), Height(root.Right, height)) + 1;
        }

        public override void Run()
        {
            var root = new TreeNode(2);
            root.SetLeftChild(new TreeNode(1));
            root.SetRightChild(new TreeNode(3));
            PrintTree(root);
        }

        private static void PrintTree(TreeNode root)
        {
            BTreePrinter.Print(root);
            if (IsBalanced(root))
                Console.WriteLine("Tree is balanced");
            else
                Console.WriteLine("Tree is not balalnced");
        }
    }
}