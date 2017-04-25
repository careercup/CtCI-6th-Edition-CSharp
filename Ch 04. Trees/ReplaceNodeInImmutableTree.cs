using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter04
{
    static class TreeNodeExtension
    {
        static public TreeNode Replace(this TreeNode node, int value)
        {
            if (node == null) return null;
            var newNode = new TreeNode(node);
            newNode.Data = value;
            TreeNode newParent = newNode;
            while (node.Parent != null)
            {
                newParent = new TreeNode(node.Parent);
                newNode.Parent = newParent;
                if (newParent.Left == node)
                    newParent.Left = newNode;
                if (newParent.Right == node)
                    newParent.Right = newNode;
                node = node.Parent;
                newNode = newParent;
            }
            return newParent;
        }
    }
    public class ReplaceNodeInImmutableTree : Question
    {
        public override void Run()
        {
            var tree = Q4_2_CreateMinimalBSTfromSortedUniqueArray.Create(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var nodeToReplace = tree.Find(6);
            TreeNode newTree = nodeToReplace.Replace(11);
            BTreePrinter.Print(tree);
            BTreePrinter.Print(newTree);
        }
    }
}