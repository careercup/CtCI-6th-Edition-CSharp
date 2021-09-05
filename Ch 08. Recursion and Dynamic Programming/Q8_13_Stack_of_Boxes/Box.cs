using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_13_Stack_of_Boxes
{
	public class Box
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int Depth { get; private set; }
		public Box(int w, int h, int d)
		{
			Width = w;
			Height = h;
			Depth = d;
		}

		public bool CanBeUnder(Box b)
		{
			if (Width > b.Width && Height > b.Height && Depth > b.Depth)
			{
				return true;
			}
			return false;
		}

		public bool CanBeAbove(Box b)
		{
			if (b == null)
			{
				return true;
			}
			if (Width < b.Width && Height < b.Height && Depth < b.Depth)
			{
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return "Box(" + Width + "," + Height + "," + Depth + ")";
		}
	}
}
