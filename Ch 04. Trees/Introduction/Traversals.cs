using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Introduction
{
    public class Traversals : Question
    {
		public static void Visit(TreeNode node)
		{
			if (node != null)
			{
				Console.WriteLine(node.Data);
			}
		}

		public static void InOrderTraversal(TreeNode node)
		{
			if (node != null)
			{
				InOrderTraversal(node.Left);
				Visit(node);
				InOrderTraversal(node.Right);
			}
		}

		public static void PreOrderTraversal(TreeNode node)
		{
			if (node != null)
			{
				Visit(node);
				InOrderTraversal(node.Left);
				InOrderTraversal(node.Right);
			}
		}

		public static void PostOrderTraversal(TreeNode node)
		{
			if (node != null)
			{
				InOrderTraversal(node.Left);
				InOrderTraversal(node.Right);
				Visit(node);
			}
		}

		public override void Run()
        {
			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			// We needed this code for other files, so check out the code in the library
			TreeNode root = TreeNode.CreateMinimalBst(array);
			InOrderTraversal(root);
		}
    }
}
