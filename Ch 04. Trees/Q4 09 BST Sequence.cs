using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ctci.Contracts;
using ctci.Library;

namespace Chapter04
{
    /// <summary>
    /// Given a binary search tree with distinct elements,
    /// print all possible arrays that could have lead to this tree.
    /// </summary>
    public class Q4_09_BST_Sequence : Question
    {

        public override void Run()
        {
            var root = Q4_02_CreateMinimalBSTfromSortedUniqueArray.Create(1, 2, 3);
            BTreePrinter.Print(root);
            var results = AllSequences(root);
            foreach (var list in results)
                AssortedMethods.PrintIntList(list);
        }

        public List<List<int>> AllSequences(TreeNode node)
        {
            var result = new List<List<int>>();

            if (node == null)
            {
                result.Add(new List<int>());
                return result;
            }

            var prefix = new List<int>();
            prefix.Add(node.Data);

            var leftSeq = AllSequences(node.Left);
            var rightSeq = AllSequences(node.Right);

            Weave(result, leftSeq, rightSeq, prefix);

            return result;
        }


        private void Weave(List<List<int>> result, List<List<int>> leftSeq, List<List<int>> rightSeq, List<int> prefix)
        {
            foreach (var left in leftSeq)
                foreach (var right in rightSeq)
                {
                    var weaved = new List<List<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    result.AddRange(weaved);
                }
        }

        /// <summary>
        /// Weave lists together in all possible ways. This algorithm works by removing the head from one list,
        /// recursing, and then doing the same thing wigth the other list.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="weaved"></param>
        /// <param name="prefix"></param>
        private void WeaveLists(List<int> first, List<int> second, List<List<int>> weaved, List<int> prefix)
        {
            // One list is empty. Add reminder to [a cloned] prefix and store result.
            if (first.Count == 0 || second.Count == 0)
            {
                var result = prefix.ToList();
                result.AddRange(first);
                result.AddRange(second);
                weaved.Add(result);
                return;
            }

            // Recurse with head of first added to the prefix. Removing the head will damage
            // first, so we'll need to put it back where we found it afterwards
            MoveItemFromFirstListToPrefixAndWeave(first, second, weaved, prefix);

            // Do the same thing with second, damaging and then restoring the list
            MoveItemFromFirstListToPrefixAndWeave(second, first, weaved, prefix);
        }

        private void MoveItemFromFirstListToPrefixAndWeave(List<int> first, List<int> second, List<List<int>> weaved, List<int> prefix)
        {
            var headFirst = first[0];
            first.RemoveAt(0);
            prefix.Add(headFirst);
            WeaveLists(first, second, weaved, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            first.Insert(0, headFirst);
        }
    }
}
