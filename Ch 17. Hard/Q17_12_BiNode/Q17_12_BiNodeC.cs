using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_12_BiNode
{
	// 方案3: 建構環狀鏈結清單
	// Time complexity: O(N)
	// 每個節點平均碰到一次(或更精確的說是 O(1) 時間)
	public class Q17_12_BiNodeC : Question
    {
		public static BiNode ConvertC(BiNode root)
		{
			BiNode head = ConvertToCircular(root);
			// 打斷環狀連結
			head.Node1.Node2 = null;
			head.Node1 = null;
			return head;
		}

		public static BiNode ConvertToCircular(BiNode root)
		{
			if (root == null)
			{
				return null;
			}

			BiNode part1 = ConvertToCircular(root.Node1);
			BiNode part3 = ConvertToCircular(root.Node2);

			if (part1 == null && part3 == null)
			{
				root.Node1 = root;
				root.Node2 = root;
				return root;
			}
			BiNode tail3 = part3 == null ? null : part3.Node1;

			/* join left to root */
			if (part1 == null)
			{
				Concat(part3.Node1, root);
			}
			else
			{
				Concat(part1.Node1, root);
			}

			/* join right to root */
			if (part3 == null)
			{
				Concat(root, part1);
			}
			else
			{
				Concat(root, part3);
			}

			/* join right to left */
			if (part1 != null && part3 != null)
			{
				Concat(tail3, part1);
			}

			return part1 == null ? root : part1;
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
			BiNode r = ConvertC(root);
			PrintLinkedListTree(r);
		}
    }
}
