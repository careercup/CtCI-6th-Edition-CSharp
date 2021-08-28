using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_08_First_Common_Ancestor
{
	// 有父節點的連結
	// Time complexity: O(d)，d是較深的節點深度
	public class Q4_08_First_Common_Ancestor_B : Question
    {
		public static TreeNode CommonAncestorB(TreeNode p, TreeNode q)
		{
			int delta = Depth(p) - Depth(q); // get difference in depths
			TreeNode first = delta > 0 ? q : p; // get shallower node
			TreeNode second = delta > 0 ? p : q; // get deeper node
			second = GoUpBy(second, Math.Abs(delta)); // move shallower node to depth of deeper
			while (first != second && first != null && second != null)
			{
				first = first.Parent;
				second = second.Parent;
			}
			return first == null || second == null ? null : first;
		}

		public static TreeNode GoUpBy(TreeNode node, int delta)
		{
			while (delta > 0 && node != null)
			{
				node = node.Parent;
				delta--;
			}
			return node;
		}

		public static int Depth(TreeNode node)
		{
			int depth = 0;
			while (node != null)
			{
				node = node.Parent;
				depth++;
			}
			return depth;
		}


		public override void Run()
        {
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			TreeNode root = TreeNode.CreateMinimalBst(array); 
			TreeNode n3 = root.Find(3);
			TreeNode n7 = root.Find(7);
			TreeNode ancestor = CommonAncestorB(n3, n7);
			Console.WriteLine(ancestor.Data);
		}
    }
}
