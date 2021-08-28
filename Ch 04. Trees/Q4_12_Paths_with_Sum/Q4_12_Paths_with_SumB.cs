using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_12_Paths_with_Sum
{
    // Time complexity: O(n)
    // 平衡樹
    // Space complexity: O(log(n))
    // 非平衡樹
    // // Space complexity: O(n)
    // n: 節點數量
    public class Q4_12_Paths_with_SumB : Question
    {
        public static int CountPathsWithSumB(TreeNode root, int targetSum)
        {
            return CountPathsWithSum(root, targetSum, 0, new Dictionary<int, int>());
        }

        public static int CountPathsWithSum(TreeNode node, int targetSum, int runningSum, Dictionary<int, int> pathCount)
        {
            if (node == null) return 0; // Base case

            runningSum += node.Data;

            /* Count paths with sum ending at the current node. */
            int sum = runningSum - targetSum;
            int totalPaths = pathCount.ContainsKey(sum) ? pathCount[sum] : 0;

            /* If runningSum equals targetSum, then one additional path starts at root. Add in this path.*/
            if (runningSum == targetSum)
            {
                totalPaths++;
            }

            /* Add runningSum to pathCounts. */
            IncrementHashTable(pathCount, runningSum, 1);

            /* Count paths with sum on the Left and Right. */
            totalPaths += CountPathsWithSum(node.Left, targetSum, runningSum, pathCount);
            totalPaths += CountPathsWithSum(node.Right, targetSum, runningSum, pathCount);

            IncrementHashTable(pathCount, runningSum, -1); // Remove runningSum
            return totalPaths;
        }

        public static void IncrementHashTable(Dictionary<int, int> hashTable, int key, int delta)
        {
            int newCount = (hashTable.ContainsKey(key) ? hashTable[key] : 0) + delta;
            if (newCount == 0)
            { // Remove when zero to reduce space usage
                hashTable.Remove(key);
            }
            else
            {
                hashTable[key] = newCount;
            }
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
            root.Right.Left.Left = new TreeNode(0);
            Console.WriteLine(CountPathsWithSumB(root, 0));
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
            Console.WriteLine(CountPathsWithSumB(root, 0));
            */

            TreeNode root = new TreeNode(0);
            root.Left = new TreeNode(0);
            root.Right = new TreeNode(0);
            root.Right.Left = new TreeNode(0);
            root.Right.Left.Right = new TreeNode(0);
            root.Right.Right = new TreeNode(0);
            Console.WriteLine(CountPathsWithSumB(root, 0));
            Console.WriteLine(CountPathsWithSumB(root, 4));
        }
    }
}
