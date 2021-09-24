using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_12_BiNode
{
	// 方案1: 額外的資料結構
    public class Q17_12_BiNodeA : Question
    {
		public NodePair ConvertA(BiNode root)
		{
			if (root == null)
			{
				return null;
			}

			NodePair part1 = ConvertA(root.Node1);
			NodePair part2 = ConvertA(root.Node2);

			if (part1 != null)
			{
				Concat(part1.Tail, root);
			}

			if (part2 != null)
			{
				Concat(root, part2.Head);
			}

			return new NodePair(part1 == null ? root : part1.Head, part2 == null ? root : part2.Tail);
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
			NodePair n = ConvertA(root);
			PrintLinkedListTree(n.Head);
		}
    }
}
