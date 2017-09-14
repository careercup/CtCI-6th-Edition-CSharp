using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;

namespace Chapter04
{
    public class Q4_10_Check_SubTree : Question
    {

        static public bool ContainsTree(TreeNode root, TreeNode p)
        {
            if (p == null) return true;
            if (root == null) return false;

            if (p.Data == root.Data && MatchTree(root, p)) return true;
            return ContainsTree(root.Left, p) || ContainsTree(root.Right, p);
        }

        static public bool MatchTree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return t1.Data == t2.Data && MatchTree(t1.Right, t2.Right) && MatchTree(t1.Left, t2.Left);
        }


        public override void Run()
        {
            var tree = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var subTree = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(6, 7, 8, 9, 10);

            Print(tree, subTree);
            subTree = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(7, 8, 9, 10);
            Print(tree, subTree);
        }

        private static void Print(TreeNode tree, TreeNode subTree)
        {
            BTreePrinter.Print(tree);
            BTreePrinter.Print(subTree);
            if (ContainsTree(tree, subTree))
                Console.WriteLine("It is a sub tree");
            else
                Console.WriteLine("It is not a sub tree");
        }
    }
}