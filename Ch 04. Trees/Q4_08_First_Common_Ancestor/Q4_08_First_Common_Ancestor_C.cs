using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_08_First_Common_Ancestor
{
    public class Q4_08_First_Common_Ancestor_C : Question
    {
		// 有父節點的連結(更好的最差狀況執行時間)
		// Time complexity: O(t)，，t是低一個共用祖先的子數大小。最差情況下，他會是O(n)，n 是樹的節點數量
		public static TreeNode CommonAncestorC(TreeNode root, TreeNode p, TreeNode q)
		{
			if (!Covers(root, p) || !Covers(root, q))
			{
				return null;
			}
			else if (Covers(p, q))
			{
				return p;
			}
			else if (Covers(q, p))
			{
				return q;
			}

			TreeNode sibling = GetSibling(p);
			TreeNode parent = p.Parent;
			while (!Covers(sibling, q))
			{
				sibling = GetSibling(parent);
				parent = parent.Parent;
			}
			return parent;
		}

		public static bool Covers(TreeNode root, TreeNode p)
		{
			if (root == null) return false;
			if (root == p) return true;
			return Covers(root.Left, p) || Covers(root.Right, p);
		}

		public static TreeNode GetSibling(TreeNode node)
		{
			if (node == null || node.Parent == null)
			{
				return null;
			}

			TreeNode parent = node.Parent;
			return parent.Left == node ? parent.Right : parent.Left;
		}


		public override void Run()
        {
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			TreeNode root = TreeNode.CreateMinimalBst(array);
			TreeNode n3 = root.Find(1);
			TreeNode n7 = root.Find(7);
			TreeNode ancestor = CommonAncestorC(root, n3, n7);
			Console.WriteLine(ancestor.Data);
		}
    }
}
