using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_12_BiNode
{
	// 方案2: 讀取尾部
	// 深度為 n 的子節點會被 GetTail 方法碰 d 次(上面的每個節點一次)
	// Time complexity: O(N^2)
	// N: 樹節點數量
	public class Q17_12_BiNodeB : Question
    {
		static int count = 0;
		public static BiNode ConvertB(BiNode root)
		{
			if (root == null)
			{
				return null;
			}

			BiNode part1 = ConvertB(root.Node1);
			BiNode part2 = ConvertB(root.Node2);

			if (part1 != null)
			{
				Concat(GetTail(part1), root);
			}

			if (part2 != null)
			{
				Concat(root, part2);
			}

			return part1 == null ? root : part1;
		}

		public static BiNode GetTail(BiNode node)
		{
			if (node == null)
			{
				return null;
			}
			while (node.Node2 != null)
			{
				count++;
				node = node.Node2;
			}
			return node;
		}

		public static void Concat(BiNode x, BiNode y)
		{
			x.Node2 = y;
			y.Node1 = x;
		}

		public static void PrintLinkedListTree(BiNode root)
		{
			for (BiNode node = root; node != null; node = node.Node2)
			{
				if (node.Node2 != null && node.Node2.Node1 != node)
				{
					Console.Write("inconsistent node: " + node);
				}
				Console.Write(node.Data + "->");
			}
			Console.WriteLine();
		}

		public static BiNode CreateTree()
		{
			BiNode[] nodes = new BiNode[7];
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i] = new BiNode(i);
			}
			nodes[4].Node1 = nodes[2];
			nodes[4].Node2 = nodes[5];
			nodes[2].Node1 = nodes[1];
			nodes[2].Node2 = nodes[3];
			nodes[5].Node2 = nodes[6];
			nodes[1].Node1 = nodes[0];
			return nodes[4];
		}

		public static void PrintAsTree(BiNode root, string spaces)
		{
			if (root == null)
			{
				Console.WriteLine(spaces + "- null");
				return;
			}
			Console.WriteLine(spaces + "- " + root.Data);
			PrintAsTree(root.Node1, spaces + "   ");
			PrintAsTree(root.Node2, spaces + "   ");
		}

		public override void Run()
        {
			BiNode root = CreateTree();
			PrintAsTree(root, "");
			BiNode n = ConvertB(root);
			PrintLinkedListTree(n);
			Console.WriteLine(count);
		}
    }
}
