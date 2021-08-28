using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_08_First_Common_Ancestor
{
    public class Q4_08_First_Common_Ancestor_E_Bad : Question
    {
		// 最佳化
		// 節點不再樹中會發生錯誤
		public static TreeNode CommonAncestorBadE(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null)
			{
				return null;
			}
			if (root == p && root == q)
			{
				return root;
			}

			TreeNode x = CommonAncestorBadE(root.Left, p, q);
			if (x != null && x != p && x != q)
			{ // Found common ancestor
				return x;
			}

			TreeNode y = CommonAncestorBadE(root.Right, p, q);
			if (y != null && y != p && y != q)
			{
				return y;
			}

			if (x != null && y != null)
			{
				return root; // This is the common ancestor
			}
			else if (root == p || root == q)
			{
				return root;
			}
			else
			{
				return x == null ? y : x;
			}
		}


		public override void Run()
        {
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			TreeNode root = TreeNode.CreateMinimalBst(array);
			TreeNode n3 = root.Find(9);
			TreeNode n7 = new TreeNode(6);//root.find(10);
			TreeNode ancestor = CommonAncestorBadE(root, n3, n7);
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
