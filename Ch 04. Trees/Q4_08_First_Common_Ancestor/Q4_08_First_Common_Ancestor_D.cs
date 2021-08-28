using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_08_First_Common_Ancestor
{
	// 沒有父節點的連結
	// Time complexity: O(n)
	public class Q4_08_First_Common_Ancestor_D : Question
    {
		public static TreeNode CommonAncestorD(TreeNode root, TreeNode p, TreeNode q)
		{
			if (!Covers(root, p) || !Covers(root, q))
			{ // Error check - one node is not in tree
				return null;
			}
			return AncestorHelper(root, p, q);
		}

		public static TreeNode AncestorHelper(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null || root == p || root == q)
			{
				return root;
			}

			bool pIsOnLeft = Covers(root.Left, p);
			bool qIsOnLeft = Covers(root.Left, q);
			if (pIsOnLeft != qIsOnLeft)
			{ // Nodes are on different side
				return root;
			}
			TreeNode childSide = pIsOnLeft ? root.Left : root.Right;
			return AncestorHelper(childSide, p, q);
		}

		public static bool Covers(TreeNode root, TreeNode p)
		{
			if (root == null) return false;
			if (root == p) return true;
			return Covers(root.Left, p) || Covers(root.Right, p);
		}

		public override void Run()
        {
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			TreeNode root = TreeNode.CreateMinimalBst(array);
			TreeNode n3 = root.Find(1);
			TreeNode n7 = root.Find(7);
			TreeNode ancestor = CommonAncestorD(root, n3, n7);
			Console.WriteLine(ancestor.Data);
		}
    }
}
