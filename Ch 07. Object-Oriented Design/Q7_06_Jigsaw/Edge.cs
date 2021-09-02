using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_06_Jigsaw
{
	public class Edge
	{
		private Shape shape;
		private string code; // used to mock how pieces would fit together.
		private Piece parentPiece;

		public Edge(Shape shape, string code)
		{
			this.shape = shape;
			this.code = code;
		}

		private string GetCode()
		{
			return code;
		}

		public Edge CreateMatchingEdge()
		{
			if (shape == Shape.FLAT) return null;
			return new Edge(shape.GetOpposite(), GetCode());
		}

		/* Check if this edge fits into the other one. */
		public bool FitsWith(Edge edge)
		{
			return edge.GetCode().Equals(GetCode());
		}

		/* Set parent piece. */
		public void SetParentPiece(Piece parentPiece)
		{
			this.parentPiece = parentPiece;
		}

		/* Get the parent piece. */
		public Piece getParentPiece()
		{
			return parentPiece;
		}

		/* Return the shape of the edge. */
		public Shape GetShape()
		{
			return shape;
		}

		public string ToString()
		{
			return code;
		}
	}
}
