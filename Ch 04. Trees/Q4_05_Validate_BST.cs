using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;

namespace Chapter04
{
    public class Q4_05_Validate_BST: Question
    {

        public override void Run()
        {
            var root = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            PrintTree(root);

            root = new TreeNode(2);
            root.SetLeftChild(new TreeNode(1));
            root.Left.SetLeftChild(new TreeNode(3));
            PrintTree(root);
        }
        public static bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        private static bool IsValidBST(TreeNode root, int? min, int? max)
        {
            if (root == null) return true;
            if (min.HasValue && min > root.Data) return false;
            if (max.HasValue && max < root.Data) return false;
            return IsValidBST(root.Left, min, root.Data) && IsValidBST(root.Right, root.Data, max);
        }

        private static void PrintTree(TreeNode root)
        {
            BTreePrinter.Print(root);
            var isValidBST = IsValidBST(root);

            if (isValidBST)
                Console.WriteLine("Tree is a valid BST");
            else
                Console.WriteLine("Tree is not a valid BST");
        }


    }
}