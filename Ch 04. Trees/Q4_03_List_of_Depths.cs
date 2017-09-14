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
            var listOfDepths = ListOfDepths(tree);

            BTreePrinter.Print(tree);
            foreach(var list in listOfDepths)
            {
                foreach (var sbList in list)
                    Console.Write($"{sbList.Data},");
                Console.WriteLine();
            }
        }

        public List<List<TreeNode>> ListOfDepths(TreeNode root)
        {
            if (root == null) return null;
            var list = new List<List<TreeNode>>();
            var sbList = new List<TreeNode> { root };
            while (sbList.Count > 0)
            {
                list.Add(sbList);

                var prevList = sbList;
                sbList = new List<TreeNode>();
                foreach (var node in prevList)
                    AddChildren(node, sbList);
            }
            return list;
        }

        private static void AddChildren(TreeNode node, List<TreeNode> list)
        {
            if (node.Left != null) list.Add(node.Left);
            if (node.Right != null) list.Add(node.Right);
        }
    }
}