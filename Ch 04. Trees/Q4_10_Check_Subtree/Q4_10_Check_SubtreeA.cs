using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_10_Check_Subtree
{
    public class Q4_10_Check_SubtreeA : Question
    {
		// Time complexity: O(n + m)
		// Space complexity: O(n + m)
		// n 與 m 是 T1 與 T2 的節點數量 
		public static bool ContainsTreeA(TreeNode t1, TreeNode t2)
		{
			StringBuilder string1 = new StringBuilder();
			StringBuilder string2 = new StringBuilder();

			GetOrderString(t1, string1);
			GetOrderString(t2, string2);

			return string1.ToString().IndexOf(string2.ToString()) != -1;
		}

		public static void GetOrderString(TreeNode node, StringBuilder sb)
		{
			if (node == null)
			{
				sb.Append("X");             // Add null indicator
				return;
			}
			sb.Append(node.Data);           // Add root 
			GetOrderString(node.Left, sb);  // Add left
			GetOrderString(node.Right, sb); // Add right
		}


		public override void Run()
        {
			// t2 is a subtree of t1
			int[] array1 = { 1, 2, 1, 3, 1, 1, 5 };
			int[] array2 = { 2, 3, 1 };

			TreeNode t1 = AssortedMethods.CreateTreeFromArray(array1);
			TreeNode t2 = AssortedMethods.CreateTreeFromArray(array2);

			if (ContainsTreeA(t1, t2))
			{
				Console.WriteLine("t2 is a subtree of t1");
			}
			else
			{
				Console.WriteLine("t2 is not a subtree of t1");
			}

			// t4 is not a subtree of t3
			int[] array3 = { 1, 2, 3 };
			TreeNode t3 = AssortedMethods.CreateTreeFromArray(array1);
			TreeNode t4 = AssortedMethods.CreateTreeFromArray(array3);

			if (ContainsTreeA(t3, t4))
			{
				Console.WriteLine("t4 is a subtree of t3");
			}
			else
			{
				Console.WriteLine("t4 is not a subtree of t3");
			}
		}
    }
}
