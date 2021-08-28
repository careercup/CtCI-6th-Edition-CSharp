using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;

namespace Chapter04
{
    public class Q4_03_List_of_Depths: Question
    {

        public override void Run()
        {
            var tree = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var listOfDepths = ListOfDepthsDFS(tree);

            BTreePrinter.Print(tree);
            foreach(var list in listOfDepths)
            {
                foreach (var sbList in list)
                    Console.Write($"{sbList.Data},");
                Console.WriteLine();
            }
        }
        public List<List<TreeNode>> ListOfDepthsDFS(TreeNode root)
        {
            // Time complexity: O(n)
            // Space complexity: O(logn)
            var ans = new List<List<TreeNode>>();
            ListOfDepthsDFS(root, 0, ans);
            return ans;
        }

        public void ListOfDepthsDFS(TreeNode root, int depth, List<List<TreeNode>> ans)
        {
            if (root != null)
            {
                if (ans.Count == depth)// Level not contained in list
                {
                    /* Levels are always traversed in order. So, if this is the first time we've visited level i,
			 * we must have seen levels 0 through i - 1. We can therefore safely add the level at the end. */
                    ans.Add(new List<TreeNode>());
                }
                ans[depth].Add(root);
                ListOfDepthsDFS(root.Left, depth + 1, ans);
                ListOfDepthsDFS(root.Right, depth + 1, ans);
            }
        }


        public List<List<TreeNode>> ListOfDepthsBFS(TreeNode root)
        {
            // Time complexity: O(n)
            // Space complexity: O(1)
            var ans = new List<List<TreeNode>>();
            if (root != null)
            {
                /* "Visit" the root */               
                var current = new List<TreeNode> { root };
                while (current.Count > 0)
                {
                    ans.Add(current); // Add previous level

                    var parents = current; // Go to next level
                    current = new List<TreeNode>();
                    /* Visit the children */
                    foreach (var parent in parents)
                        AddChildren(parent, current);
                }
            }
            return ans;
        }

        private static void AddChildren(TreeNode node, List<TreeNode> list)
        {
            if (node.Left != null) list.Add(node.Left);
            if (node.Right != null) list.Add(node.Right);
        }
    }
}