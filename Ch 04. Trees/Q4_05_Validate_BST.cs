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


        public bool IsValidBST_A(TreeNode root)
        {
            // Time complexity: O(n)
            // Space complexity: O(logn)
            TreeNode prev = null;
            return IsValidBST_A(root, ref prev);
        }

        // Allow "equal" value only for left child. This validates the BST property.
        public bool IsValidBST_A(TreeNode root, ref TreeNode prev)
        {
            if (root == null) return true;
            else
            {
                // Check / recurse left
                if (!IsValidBST_A(root.Left, ref prev)) return false;
                else
                {
                    // Check current
                    if (prev != null && root.Data <= prev.Data) return false;
                    else
                    {
                        prev = root;
                        // Check / recurse right
                        return IsValidBST_A(root.Right, ref prev);
                    }
                }
            }
        }


        public bool IsValidBST_B(TreeNode root)
        {
            // Time complexity: O(n)
            // Space complexity: O(logn)
            return IsValidBST_B(root, null, null);
        }

        private bool IsValidBST_B(TreeNode root, int? min, int? max)
        {
            if (root == null) return true;
            else if (min.HasValue && min > root.Data) return false;
            else if (max.HasValue && max < root.Data) return false;
            else return IsValidBST_B(root.Left, min, root.Data) && IsValidBST_B(root.Right, root.Data, max);
        }

        private void PrintTree(TreeNode root)
        {
            BTreePrinter.Print(root);
            CheckPrint(IsValidBST_A(root));
            CheckPrint(IsValidBST_B(root));
        }

        private void CheckPrint(bool flag)
        {
            if (flag)
                Console.WriteLine("Tree is a valid BST");
            else
                Console.WriteLine("Tree is not a valid BST");
        }
    }
}