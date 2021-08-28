using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_08_First_Common_Ancestor
{
	// 最佳化
	public class Q4_08_First_Common_Ancestor_E : Question
    {
		public class Result
		{
			public TreeNode Node { get; private set; }
			public bool IsAncestor { get; private set; }
			public Result(TreeNode n, bool isAnc)
			{
				Node = n;
				IsAncestor = isAnc;
			}
		}

		public TreeNode CommonAncestorE(TreeNode root, TreeNode p, TreeNode q)
		{
			Result r = CommonAncestorHelper(root, p, q);
			if (r.IsAncestor)
			{
				return r.Node;
			}
			return null;
		}

		public Result CommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null)
			{
				return new Result(null, false);
			}
			if (root == p && root == q)
			{
				return new Result(root, true);
			}

			Result rx = CommonAncestorHelper(root.Left, p, q);
			if (rx.IsAncestor)
			{ // Found common ancestor
				return rx;
			}

			Result ry = CommonAncestorHelper(root.Right, p, q);
			if (ry.IsAncestor)
			{ // Found common ancestor
				return ry;
			}

			if (rx.Node != null && ry.Node != null)
			{
				return new Result(root, true); // This is the common ancestor
			}
			else if (root == p || root == q)
			{
				/* If we're currently at p or q, and we also found one of those
				 * nodes in a subtree, then this is truly an ancestor and the
				 * flag should be true. */
				bool isAncestor = rx.Node != null || ry.Node != null;
				return new Result(root, isAncestor);
			}
			else
			{
				return new Result(rx.Node != null ? rx.Node : ry.Node, false);
			}
		}

		public override void Run()
        {
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			TreeNode root = TreeNode.CreateMinimalBst(array);
			TreeNode n3 = root.Find(10);
			TreeNode n7 = root.Find(6);
			TreeNode ancestor = CommonAncestorE(root, n3, n7);
			if (ancestor != null)
			{
				Console.WriteLine(ancestor.Data);
			}
			else
			{
				Console.WriteLine("null");
			}
		}
    }
}
