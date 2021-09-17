using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_22_Langtons_Ant
{
	// 方案3: HashSet
	public class Board
	{
		private HashSet<Position> blackCells = new HashSet<Position>();
		private Ant ant = new Ant();
		private Position topLeftCorner = new Position(0, 0);
		private Position bottomRightCorner = new Position(0, 0);

		public Board() { }

		/* Move ant. */
		public void Move()
		{
			ant.Turn(!IsBlack(ant.Position)); // Turn clockwise on white, counter on black
			Flip(ant.Position); // flip
			ant.Move(); // move
			EnsureFit(ant.Position);
		}

		/* Flip color of cells. */
		private void Flip(Position position)
		{
			if (blackCells.Contains(position))
			{
				blackCells.Remove(position);
			}
			else
			{
				blackCells.Add(position.Clone());
			}
		}

		/* "Grow" the grid by tracking the most top-left and 
		 * bottom-right position that we've seen. */
		private void EnsureFit(Position position)
		{
			int row = position.Row;
			int column = position.Column;

			topLeftCorner.Row = Math.Min(topLeftCorner.Row, row);
			topLeftCorner.Column = Math.Min(topLeftCorner.Column, column);

			bottomRightCorner.Row = Math.Max(bottomRightCorner.Row, row);
			bottomRightCorner.Column = Math.Max(bottomRightCorner.Column, column);
		}

		/* Check if cell is white. */
		public bool IsBlack(Position p)
		{
			return blackCells.Contains(p);
		}

		/* Check if cell is white. */
		public bool IsBlack(int row, int column)
		{
			return blackCells.Contains(new Position(row, column));
		}

		/* Print board. */
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			int rowMin = topLeftCorner.Row;
			int rowMax = bottomRightCorner.Row;
			int colMin = topLeftCorner.Column;
			int colMax = bottomRightCorner.Column;
			for (int r = rowMin; r <= rowMax; r++)
			{
				for (int c = colMin; c <= colMax; c++)
				{
					if (r == ant.Position.Row && c == ant.Position.Column)
					{
						sb.Append(ant.Orientation);
					}
					else if (IsBlack(r, c))
					{
						sb.Append("X");
					}
					else
					{
						sb.Append("_");
					}
				}
				sb.Append("\n");
			}
			sb.Append("Ant: " + ant.Orientation + ". \n");
			return sb.ToString();
		}
	}
}
