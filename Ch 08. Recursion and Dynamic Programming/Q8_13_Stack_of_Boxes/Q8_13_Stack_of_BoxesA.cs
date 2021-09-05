using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_13_Stack_of_Boxes
{
    // Solution 1
    public class Q8_13_Stack_of_BoxesA : Question
    {
        public static int CreateStackA(List<Box> boxes)
        {
            boxes.Sort((a, b) => b.Height - a.Height);
            int maxHeight = 0;
            for (int i = 0; i < boxes.Count; i++)
            {
                int height = CreateStack(boxes, i);
                maxHeight = Math.Max(maxHeight, height);
            }
            return maxHeight;
        }

        public static int CreateStack(IList<Box> boxes, int bottomIndex)
        {
            Box bottom = boxes[bottomIndex];
            int maxHeight = 0;
            for (int i = bottomIndex + 1; i < boxes.Count; i++)
            {
                if (boxes[i].CanBeAbove(bottom))
                {
                    int height = CreateStack(boxes, i);
                    maxHeight = Math.Max(height, maxHeight);
                }
            }
            maxHeight += bottom.Height;
            return maxHeight;
        }
        public override void Run()
        {
            List<Box> boxes = new List<Box>()
            {
                new Box(6, 4, 4),
                new Box(8, 6, 2),
                new Box(5, 3, 3),
                new Box(7, 8, 3),
                new Box(4, 2, 2),
                new Box(9, 7, 3)
            };

            int height = CreateStackA(boxes);
            Console.WriteLine(height);
        }
    }
}
