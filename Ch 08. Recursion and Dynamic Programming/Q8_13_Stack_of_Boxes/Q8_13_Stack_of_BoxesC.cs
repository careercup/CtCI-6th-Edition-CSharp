using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_13_Stack_of_Boxes
{
	// Solution 2
	// memo
	public class Q8_13_Stack_of_BoxesC : Question
    {
		public static int CreateStackC(List<Box> boxes)
		{
			boxes.Sort((a, b) => b.Height - a.Height);
			int[] stackMap = new int[boxes.Count];
			return CreateStack(boxes, null, 0, stackMap);
		}

		public static int CreateStack(IList<Box> boxes, Box bottom, int offset, int[] stackMap)
		{
			if (offset >= boxes.Count)
			{
				return 0;
			}

			/* height with this bottom */
			Box newBottom = boxes[offset];
			int heightWithBottom = 0;
			if (bottom == null || newBottom.CanBeAbove(bottom))
			{
				if (stackMap[offset] == 0)
				{
					stackMap[offset] = CreateStack(boxes, newBottom, offset + 1, stackMap);
					stackMap[offset] += newBottom.Height;
				}
				heightWithBottom = stackMap[offset];
			}

			/* without this bottom */
			int heightWithoutBottom = CreateStack(boxes, bottom, offset + 1, stackMap);

			return Math.Max(heightWithBottom, heightWithoutBottom);
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

			int height = CreateStackC(boxes);
			Console.WriteLine(height);
		}
    }
}
