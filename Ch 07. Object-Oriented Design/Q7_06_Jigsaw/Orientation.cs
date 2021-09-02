using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_06_Jigsaw
{
	public enum Orientation
	{
		LEFT, 
		TOP, 
		RIGHT, 
		BOTTOM, // Should stay in this order 
		Error,
	}

	static class OrientationMethod
    {
		public static Orientation GetOpposite(this Orientation o)
		{
			switch (o)
			{
				case Orientation.LEFT: return Orientation.RIGHT;
				case Orientation.RIGHT: return Orientation.LEFT;
				case Orientation.TOP: return Orientation.BOTTOM;
				case Orientation.BOTTOM: return Orientation.TOP;
				default: return Orientation.Error;
			}
		}
	}
}
