using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_11_Random_Node
{
	// Solution B

	// 在平衡樹中
	// Time complexity: O(logn)
	// n: 節點數量

	// 更精確的時間描述
	// Time complexity: O(D)
	// D: 樹的最大深度

	public class Tree
	{
		TreeNode root = null;

		public void InsertInOrder(int value)
		{
			if (root == null)
			{
				root = new TreeNode(value);
			}
			else
			{
				root.InsertInOrder(value);
			}
		}

		public int Size()
		{
			return root == null ? 0 : root.Size();
		}

		public TreeNode GetRandomNode()
		{
			if (root == null) return null;

			Random random = new Random();
			int i = random.Next(Size());
			return root.GetIthNode(i);
		}
	}
}
