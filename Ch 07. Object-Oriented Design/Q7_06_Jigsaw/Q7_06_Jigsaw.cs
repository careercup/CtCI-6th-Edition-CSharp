using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_06_Jigsaw
{
    public class Q7_06_Jigsaw : Question
    {

		public static Edge CreateRandomEdge(String code)
		{
			Random random = new Random();
			Shape type = Shape.INNER;
			if (random.Next(2) == 1) 
			{
				type = Shape.OUTER;
			}
			return new Edge(type, code);
		}

		public static Edge[] CreateEdges(Piece[][] puzzle, int column, int row)
		{
			string key = column + ":" + row + ":";
			/* Get left edge */
			Edge left = column == 0 ? new Edge(Shape.FLAT, key + "h|e") : puzzle[row][column - 1].GetEdgeWithOrientation(Orientation.RIGHT).CreateMatchingEdge();

			/* Get top edge */
			Edge top = row == 0 ? new Edge(Shape.FLAT, key + "v|e") : puzzle[row - 1][column].GetEdgeWithOrientation(Orientation.BOTTOM).CreateMatchingEdge();

			/* Get right edge */
			Edge right = column == puzzle[row].Length - 1 ? new Edge(Shape.FLAT, key + "h|e") : CreateRandomEdge(key + "h");

			/* Get bottom edge */
			Edge bottom = row == puzzle.Length - 1 ? new Edge(Shape.FLAT, key + "v|e") : CreateRandomEdge(key + "v");

			Edge[] edges = { left, top, right, bottom };
			return edges;
		}

		public static IList<Piece> InitializePuzzle(int size)
		{
			/* Create completed puzzle. */
			Piece[][] puzzle = new Piece[size][];
			for (int row = 0; row < size; row++)
			{
				puzzle[row] = new Piece[size];
				for (int column = 0; column < size; column++)
				{
					Edge[] edges = CreateEdges(puzzle, column, row);
					puzzle[row][column] = new Piece(edges);
				}
			}

			/* Shuffle and rotate pieces. */
			IList<Piece> pieces = new List<Piece>();
			Random r = new Random();
			for (int row = 0; row < size; row++)
			{
				for (int column = 0; column < size; column++)
				{
					int rotations = r.Next(4);
					Piece piece = puzzle[row][column];
					piece.RotateEdgesBy(rotations);
					int index = pieces.Count == 0 ? 0 : r.Next(pieces.Count);

					pieces.Insert(index, piece);
				}
			}

			return pieces;
		}

		public static string SolutionToString(Piece[][] solution)
		{
			StringBuilder sb = new StringBuilder();
			for (int h = 0; h < solution.Length; h++)
			{
				for (int w = 0; w < solution[h].Length; w++)
				{
					Piece p = solution[h][w];
					if (p == null)
					{
						sb.Append("null");
					}
					else
					{
						sb.Append(p.ToString());
					}
				}
				sb.Append("\n");
			}
			return sb.ToString();
		}

		/* Used for testing. Check if puzzle is solved. */
		public static bool Validate(Piece[][] solution)
		{
			if (solution == null) return false;
			for (int r = 0; r < solution.Length; r++)
			{
				for (int c = 0; c < solution[r].Length; c++)
				{
					Piece piece = solution[r][c];
					if (piece == null) return false;
					if (c > 0)
					{ /* match left */
						Piece left = solution[r][c - 1];
						if (!left.GetEdgeWithOrientation(Orientation.RIGHT).FitsWith(piece.GetEdgeWithOrientation(Orientation.LEFT)))
						{
							return false;
						}
					}
					if (c < solution[r].Length - 1)
					{ /* match right */
						Piece right = solution[r][c + 1];
						if (!right.GetEdgeWithOrientation(Orientation.LEFT).FitsWith(piece.GetEdgeWithOrientation(Orientation.RIGHT)))
						{
							return false;
						}
					}
					if (r > 0)
					{ /* match top */
						Piece top = solution[r - 1][c];
						if (!top.GetEdgeWithOrientation(Orientation.BOTTOM).FitsWith(piece.GetEdgeWithOrientation(Orientation.TOP)))
						{
							return false;
						}
					}
					if (r < solution.Length - 1)
					{ /* match bottom */
						Piece bottom = solution[r + 1][c];
						if (!bottom.GetEdgeWithOrientation(Orientation.TOP).FitsWith(piece.GetEdgeWithOrientation(Orientation.BOTTOM)))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		public static bool TestSize(int size)
		{
			IList<Piece> pieces = InitializePuzzle(size);
			Puzzle puzzle = new Puzzle(size, pieces);
			puzzle.Solve();
			Piece[][] solution = puzzle.GetCurrentSolution();
			Console.WriteLine(SolutionToString(solution));
			bool result = Validate(solution);
			Console.WriteLine(result);
			return result;
		}

		public override void Run()
        {
			for (int size = 1; size < 10; size++)
			{
				if (!TestSize(size))
				{
					Console.WriteLine("ERROR: " + size);
				}
			}
		}
    }
}
