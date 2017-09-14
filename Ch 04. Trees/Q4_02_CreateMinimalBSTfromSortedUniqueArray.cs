using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter04
{
    public class Q4_02_CreateMinimalBSTfromSortedUniqueArray: Question
    {
        public static TreeNode Create(params int[] sortedArray)
        {
            return Create(sortedArray, 0, sortedArray.Length - 1);
        }

        private static TreeNode Create(int[] sortedArray, int left, int right)
        {
            if (left > right) return null;
            var mid = left + (right - left) / 2;
            var treeNode = new TreeNode(sortedArray[mid]);
            treeNode.SetLeftChild(Create(sortedArray, left, mid - 1));
            treeNode.SetRightChild(Create(sortedArray, mid + 1, right));
            return treeNode;
        }


        public override void Run()
        {
            var root = Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            BTreePrinter.Print(root);
        }
    }
}