using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter04
{
    static partial class TreeNodeExtension
    {
        static public TreeNode Replace(this TreeNode node, int value)
        {
            if (node == null) return null;
            var newNode = new TreeNode(node);
            newNode.Data = value;
            var newRoot = newNode;
            while (node.Parent != null)
            {
                newRoot = new TreeNode(node.Parent);
                newNode.Parent = newRoot;
                if (newRoot.Left == node)
                    newRoot.Left = newNode;
                if (newRoot.Right == node)
                    newRoot.Right = newNode;
                node = node.Parent;
                newNode = newRoot;
            }
            return newRoot;
        }
    }
    public class ReplaceNodeInImmutableTree : Question
    {
        public override void Run()
        {
            var tree = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var nodeToReplace = tree.Find(6);
            TreeNode newTree = nodeToReplace.Replace(11);
            BTreePrinter.Print(tree);
            BTreePrinter.Print(newTree);
        }
    }
}