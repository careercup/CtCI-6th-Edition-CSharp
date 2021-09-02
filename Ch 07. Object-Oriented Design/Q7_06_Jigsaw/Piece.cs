using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_06_Jigsaw
{
	public class Piece
	{
		private readonly static int NUMBER_OF_EDGES = 4;
		private Dictionary<Orientation, Edge> edges = new Dictionary<Orientation, Edge>();

		public Piece(Edge[] edgeList)
		{
			Orientation[] orientations = Enum.GetValues<Orientation>();
			for (int i = 0; i < edgeList.Length; i++)
			{
				Edge edge = edgeList[i];
				edge.SetParentPiece(this);
				edges[orientations[i]] = edge;
			}
		}

		/* Set this edge in the appropriate orientation, rotating the piece as necessary. */
		public void SetEdgeAsOrientation(Edge edge, Orientation orientation)
		{
			Orientation currentOrientation = GetOrientation(edge);
			RotateEdgesBy((int)orientation - (int)currentOrientation);
		}

		/* Return the current orientation of the edge. */
		private Orientation GetOrientation(Edge edge)
		{
			foreach (var entry in edges)
			{
				if (entry.Value == edge)
				{
					return entry.Key;
				}
			}
			return Orientation.Error;
		}

		/* Rotate edges by "numberRotations". */
		public void RotateEdgesBy(int numberRotations)
		{
			Orientation[] orientations = Enum.GetValues<Orientation>();
			Dictionary<Orientation, Edge> rotated = new Dictionary<Orientation, Edge>();

			numberRotations = numberRotations % NUMBER_OF_EDGES;
			if (numberRotations < 0) numberRotations += NUMBER_OF_EDGES;

			for (int i = 0; i < orientations.Length; i++)
			{
				Orientation oldOrientation = orientations[(i - numberRotations + NUMBER_OF_EDGES) % NUMBER_OF_EDGES];
				Orientation newOrientation = orientations[i];
				rotated[newOrientation]= edges[oldOrientation];
			}
			edges = rotated;
		}

		/* Check if this piece is a corner piece. */
		public bool IsCorner()
		{
			Orientation[] orientations = Enum.GetValues<Orientation>();
			for (int i = 0; i < orientations.Length; i++)
			{
				Shape current = edges[orientations[i]].GetShape();
				Shape next = edges[orientations[(i + 1) % NUMBER_OF_EDGES]].GetShape();
				if (current == Shape.FLAT && next == Shape.FLAT)
				{
					return true;
				}
			}
			return false;
		}

		/* Check if this piece has a border edge. */
		public bool IsBorder()
		{
			Orientation[] orientations = Enum.GetValues<Orientation>();
			for (int i = 0; i < orientations.Length; i++)
			{
				if (edges[orientations[i]].GetShape() == Shape.FLAT)
				{
					return true;
				}
			}
			return false;
		}

		/* Get edge at this orientation. */
		public Edge GetEdgeWithOrientation(Orientation orientation)
		{
			return edges[orientation];
		}

		/* Return the edge that matches targetEdge. Returns null if there is no match. */
		public Edge GetMatchingEdge(Edge targetEdge)
		{
			foreach (Edge e in edges.Values)
			{
				if (targetEdge.FitsWith(e))
				{
					return e;
				}
			}
			return null;
		}

		public string ToString()
		{
			StringBuilder sb = new StringBuilder();
			Orientation[] orientations = Enum.GetValues<Orientation>();
			foreach (Orientation o in orientations)
			{
				sb.Append(edges[o].ToString() + ",");
			}
			return "[" + sb.ToString() + "]";
		}
	}
}
