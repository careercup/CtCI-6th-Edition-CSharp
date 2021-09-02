using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_06_Jigsaw
{
    public enum Shape
    {
        INNER, 
        OUTER,
        FLAT,
		Error,
	}

	static class ShapeMethod
	{
		public static Shape GetOpposite(this Shape s)
		{
			switch (s)
			{
				case Shape.INNER: return Shape.OUTER;
				case Shape.OUTER: return Shape.INNER;
				default: return Shape.Error;
			}
		}
	}
}
