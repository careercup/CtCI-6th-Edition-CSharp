using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_06_Jigsaw
{
	public class Puzzle
	{
		private IList<Piece> pieces; /* Remaining pieces left to put away. */
		private Piece[][] solution;
		private int size;

		public Puzzle(int size, IList<Piece> pieces)
		{
			this.pieces = pieces;
			this.size = size;
		}

		/* Group pieces into border pieces (including corners) and inside pieces. */
		public void GroupPieces(LinkedList<Piece> cornerPieces, LinkedList<Piece> borderPieces, LinkedList<Piece> insidePieces)
		{
			foreach (Piece p in pieces)
			{
				if (p.IsCorner())
				{
					cornerPieces.AddLast(p);
				}
				else if (p.IsBorder())
				{
					borderPieces.AddLast(p);
				}
				else
				{
					insidePieces.AddLast(p);
				}
			}
		}

		/* Orient this corner piece so that its flat edges are on the top and left. */
		public void OrientTopLeftCorner(Piece piece)
		{
			if (!piece.IsCorner()) return;

			Orientation[] orientations = Enum.GetValues<Orientation>();
			for (int i = 0; i < orientations.Length; i++)
			{
				Edge current = piece.GetEdgeWithOrientation(orientations[i]);
				Edge next = piece.GetEdgeWithOrientation(orientations[(i + 1) % orientations.Length]);
				if (current.GetShape() == Shape.FLAT && next.GetShape() == Shape.FLAT)
				{
					piece.SetEdgeAsOrientation(current, Orientation.LEFT);
					return;
				}
			}
		}

		/* Bounds check. Check if this index is on a border (0 or size - 1) */
		public bool IsBorderIndex(int location)
		{
			return location == 0 || location == size - 1;
		}

		/* Given a list of pieces, check if any have an edge that matches this piece. Return the edge*/
		private Edge GetMatchingEdge(Edge targetEdge, LinkedList<Piece> pieces)
		{
			foreach (Piece piece in pieces)
			{
				Edge matchingEdge = piece.GetMatchingEdge(targetEdge);
				if (matchingEdge != null)
				{
					return matchingEdge;
				}
			}
			return null;
		}

		/* Put the edge/piece into the solution, turn it appropriately, and remove from list. */
		private void SetEdgeInSolution(LinkedList<Piece> pieces, Edge edge, int row, int column, Orientation orientation)
		{
			Piece piece = edge.getParentPiece();
			piece.SetEdgeAsOrientation(edge, orientation);
			pieces.Remove(piece);
			solution[row][column] = piece;
		}

		/* Return the list where a piece with this index would be found. */
		private LinkedList<Piece> GetPieceListToSearch(LinkedList<Piece> cornerPieces, LinkedList<Piece> borderPieces, LinkedList<Piece> insidePieces, int row, int column)
		{
			if (IsBorderIndex(row) && IsBorderIndex(column))
			{
				return cornerPieces;
			}
			else if (IsBorderIndex(row) || IsBorderIndex(column))
			{
				return borderPieces;
			}
			else
			{
				return insidePieces;
			}
		}

		/* Find the matching piece within piecesToSearch and insert it at row, column. */
		private bool FitNextEdge(LinkedList<Piece> piecesToSearch, int row, int column)
		{
			if (row == 0 && column == 0)
			{

				Piece p = piecesToSearch.First();
				piecesToSearch.RemoveFirst();
				OrientTopLeftCorner(p);
				solution[0][0] = p;
			}
			else
			{
				/* Get the right edge and list to match. */
				Piece pieceToMatch = column == 0 ? solution[row - 1][0] : solution[row][column - 1];
				Orientation orientationToMatch = column == 0 ? Orientation.BOTTOM : Orientation.RIGHT;
				Edge edgeToMatch = pieceToMatch.GetEdgeWithOrientation(orientationToMatch);

				/* Get matching edge. */
				Edge edge = GetMatchingEdge(edgeToMatch, piecesToSearch);
				if (edge == null) return false; // Can't solve

				Orientation orientation = orientationToMatch.GetOpposite();
				SetEdgeInSolution(piecesToSearch, edge, row, column, orientation);
			}
			return true;
		}

		public bool Solve()
		{
			/* Group pieces. */
			LinkedList<Piece> cornerPieces = new LinkedList<Piece>();
			LinkedList<Piece> borderPieces = new LinkedList<Piece>();
			LinkedList<Piece> insidePieces = new LinkedList<Piece>();
			GroupPieces(cornerPieces, borderPieces, insidePieces);

			/* Walk through puzzle, finding the piece that joins the previous one. */
			solution = new Piece[size][];
			for (int row = 0; row < size; row++)
			{
				solution[row] = new Piece[size];
				for (int column = 0; column < size; column++)
				{
					LinkedList<Piece> piecesToSearch = GetPieceListToSearch(cornerPieces, borderPieces, insidePieces, row, column);
					if (!FitNextEdge(piecesToSearch, row, column))
					{
						return false;
					}
				}
			}

			return true;
		}

		public Piece[][] GetCurrentSolution()
		{
			return solution;
		}
	}
}
