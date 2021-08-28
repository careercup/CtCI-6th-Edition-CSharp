using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_12_Paths_with_Sum
{
    // 平衡樹
    // Time complexity: O(nlogn)
    // 非平衡樹
    // Time complexity: O(n^2)
    // n: 節點數量
    public class Q4_12_Paths_with_SumA : Question
    {
        public static int CountPathsWithSumA(TreeNode root, int targetSum)
        {
            if (root == null) return 0;

            /* Count paths with sum starting from the root. */
            int pathsFromRoot = CountPathsWithSumFromNode(root, targetSum, 0);

            /* Try the nodes on the Left and Right. */
            int pathsOnLeft = CountPathsWithSumA(root.Left, targetSum);
            int pathsOnRight = CountPathsWithSumA(root.Right, targetSum);

            return pathsFromRoot + pathsOnLeft + pathsOnRight;
        }

        /* Returns the number of paths with this sum starting from this node. */
        public static int CountPathsWithSumFromNode(TreeNode node, int targetSum, int currentSum)
        {
            if (node == null) return 0;

            currentSum += node.Data;

            int totalPaths = 0;
            if (currentSum == targetSum)
            { // Found a path from the root
                totalPaths++;
            }

            totalPaths += CountPathsWithSumFromNode(node.Left, targetSum, currentSum); // Go Left
            totalPaths += CountPathsWithSumFromNode(node.Right, targetSum, currentSum); // Go Right

            return totalPaths;
        }

        public override void Run()
        {
            /*
            TreeNode root = new TreeNode(5);
            root.Left = new TreeNode(3);
            root.Right = new TreeNode(1);
            root.Left.Left = new TreeNode(-8);
            root.Left.Right = new TreeNode(8);
            root.Right.Left = new TreeNode(2);
            root.Right.Right = new TreeNode(6);
            Console.WriteLine(CountPathsWithSumA(root, 0));
            */

            /*
            TreeNode root = new TreeNode(-7);
			root.Left = new TreeNode(-7);
			root.Left.Right = new TreeNode(1);
			root.Left.Right.Left = new TreeNode(2);
			root.Right = new TreeNode(7);
			root.Right.Left = new TreeNode(3);
			root.Right.Right = new TreeNode(20);
			root.Right.Right.Left = new TreeNode(0);
			root.Right.Right.Left.Left = new TreeNode(-3);
			root.Right.Right.Left.Left.Right = new TreeNode(2);
			root.Right.Right.Left.Left.Right.Left = new TreeNode(1);
            Console.WriteLine(CountPathsWithSumA(root, -14));
            */

            TreeNode root = new TreeNode(0);
            root.Left = new TreeNode(0);
            root.Right = new TreeNode(0);
            root.Right.Left = new TreeNode(0);
            root.Right.Left.Right = new TreeNode(0);
            root.Right.Right = new TreeNode(0);
            Console.WriteLine(CountPathsWithSumA(root, 0));
            Console.WriteLine(CountPathsWithSumA(root, 4));
        }
    }
}
