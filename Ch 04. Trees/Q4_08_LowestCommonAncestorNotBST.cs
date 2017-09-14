using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;

namespace Chapter04
{
    static partial class TreeNodeExtension
    {
        static public TreeNode LowestCommonAncestor(this TreeNode root, TreeNode p, TreeNode q)
        {
            if (!root.Covers(p) || !root.Covers(q)) return null;

            return LowestCommonAncestorHelper(root, p, q);
        }

        static private TreeNode LowestCommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root == p) return root;
            if (root == q) return root;

            var pIsOnLeft = root.Left.Covers(p);
            var qIsOnLeft = root.Left.Covers(q);
            if (pIsOnLeft != qIsOnLeft) return root;
            if (pIsOnLeft && qIsOnLeft) return LowestCommonAncestorHelper(root.Left, p, q);
            return LowestCommonAncestorHelper(root.Right, p, q);
        }

        static private bool Covers(this TreeNode root, TreeNode node)
        {
            if (root == null) return false;
            if (root == node) return true;
            return (root.Left.Covers(node) || root.Right.Covers(node));
        }
    }

    public class Q4_08_LowestCommonAncestorNotBST : Question
    {

        public override void Run()
        {
            var root = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var p = root.Find(1);
            var q = root.Find(3);
            var lca = root.LowestCommonAncestor(p, q);
            Console.WriteLine($"LCA for {p.Data},{q.Data} is {lca.Data}"); // 2

            p = root.Find(4);
            q = root.Find(7);
            lca = root.LowestCommonAncestor(p, q);
            Console.WriteLine($"LCA for {p.Data},{q.Data} is {lca.Data}"); // 5

            p = root.Find(7);
            q = root.Find(9);
            lca = root.LowestCommonAncestor(p, q);
            Console.WriteLine($"LCA for {p.Data},{q.Data} is {lca.Data}"); // 8
        }
    }
}