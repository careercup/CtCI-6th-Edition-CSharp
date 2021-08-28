using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_11_Random_Node
{

    // Solution A

    // 在平衡樹中
    // Time complexity: O(logn)
    // n: 節點數量

    /* One node of a binary tree. The data element stored is a single 
     * character.
     */
    public class TreeNode
    {
        public int Data { get; private set; }
        public TreeNode Left { get; private set; }
        public TreeNode Right { get; private set; }
        private int size = 0;

        public TreeNode(int d)
        {
            Data = d;
            size = 1;
        }

        public void InsertInOrder(int d)
        {
            if (d <= Data)
            {
                if (Left == null)
                {
                    Left = new TreeNode(d);
                }
                else
                {
                    Left.InsertInOrder(d);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode(d);
                }
                else
                {
                    Right.InsertInOrder(d);
                }
            }
            size++;
        }

        public int Size()
        {
            return size;
        }

        public TreeNode Find(int d)
        {
            if (d == Data)
            {
                return this;
            }
            else if (d <= Data)
            {
                return Left != null ? Left.Find(d) : null;
            }
            else if (d > Data)
            {
                return Right != null ? Right.Find(d) : null;
            }
            return null;
        }

        public TreeNode GetRandomNode()
        {
            int leftSize = Left == null ? 0 : Left.Size();
            Random random = new Random();
            int index = random.Next(size);
            if (index < leftSize)
            {
                return Left.GetRandomNode();
            }
            else if (index == leftSize)
            {
                return this;
            }
            else
            {
                return Right.GetRandomNode();
            }
        }

        public TreeNode GetIthNode(int i)
        {
            int leftSize = Left == null ? 0 : Left.Size();
            if (i < leftSize)
            {
                return Left.GetIthNode(i);
            }
            else if (i == leftSize)
            {
                return this;
            }
            else
            {
                return Right.GetIthNode(i - (leftSize + 1));
            }
        }
    }
}
