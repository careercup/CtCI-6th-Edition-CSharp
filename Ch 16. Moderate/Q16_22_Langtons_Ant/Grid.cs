using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_22_Langtons_Ant
{
	// 方案2: 可調整大小的矩陣
	public class Grid
	{
		private bool[][] grid; // false is white, true is black
		private Ant ant = new Ant();

		public Grid()
		{
			grid = new bool[1][];
            for (int i = 0; i < grid.Length; i++)
            {
				grid[i] = new bool[1];
            }
		}

		/* Copy old values into new array, with an offset/shift applied to the row and columns. */
		private void CopyWithShift(bool[][] oldGrid, bool[][] newGrid, int shiftRow, int shiftColumn)
		{
			for (int r = 0; r < oldGrid.Length; r++)
			{
				for (int c = 0; c < oldGrid[0].Length; c++)
				{
					newGrid[r + shiftRow][c + shiftColumn] = oldGrid[r][c];
				}
			}
		}

		/* Ensure that the given position will fit on the array. If 
		 * necessary, double the size of the matrix, copy the old values 
		 * over, and adjust the ant's position so that it's in a positive
		 * ranges.
		 */
		private void EnsureFit(Position position)
		{
			int shiftRow = 0;
			int shiftColumn = 0;

			/* Calculate new number of rows. */
			int numRows = grid.Length;
			if (position.Row < 0)
			{
				shiftRow = numRows;
				numRows *= 2;
			}
			else if (position.Row >= numRows)
			{
				numRows *= 2;
			}

			/* Calculate new number of columns. */
			int numColumns = grid[0].Length;
			if (position.Column < 0)
			{
				shiftColumn = numColumns;
				numColumns *= 2;
			}
			else if (position.Column >= numColumns)
			{
				numColumns *= 2;
			}

			/* Grow array, if necessary. Shift ant's position too. */
			if (numRows != grid.Length || numColumns != grid[0].Length)
			{
				bool[][] newGrid = new bool[numRows][];
				for (int i = 0; i < numRows; i++)
				{
					newGrid[i] = new bool[numColumns];
				}

				CopyWithShift(grid, newGrid, shiftRow, shiftColumn);
				ant.AdjustPosition(shiftRow, shiftColumn);
				grid = newGrid;
			}
		}

		/* Flip color of cells. */
		private void Flip(Position position)
		{
			int row = position.Row;
			int column = position.Column;
			grid[row][column] = grid[row][column] ? false : true;
		}

		/* Move ant. */
		public void Move()
		{
			ant.Turn(!grid[ant.Position.Row][ant.Position.Column]); // Turn clockwise on white, counterclockwise on black
			Flip(ant.Position); // flip
			ant.Move(); // move
			EnsureFit(ant.Position); // grow
		}

		/* Print board. The first loop of this is a "compression" which only prints the active parts of the board. The active
		 * board is the smallest rectangle that contains all the black cells and the ant. This is fairly optional. Nice to do
		 * but also not essential. 
		 * FULL BOARD:    ACTIVE BOARD:
		 *  _____          _X
		 *  ___X_          XX
		 *  __XX_           X
		 *  ___X_
		 *  _____
		 *  _____*/
		public override string ToString()
		{
			int firstActiveRow = grid.Length;
			int firstActiveColumn = grid[0].Length;
			int lastActiveRow = 0;
			int lastActiveColumn = 0;
			for (int r = 0; r < grid.Length; r++)
			{
				for (int c = 0; c < grid[r].Length; c++)
				{
					if (grid[r][c] || (ant.Position.Row == r && ant.Position.Column == c))
					{ // If there's something there
						firstActiveRow = Math.Min(firstActiveRow, r);
						firstActiveColumn = Math.Min(firstActiveColumn, c);
						lastActiveRow = Math.Max(lastActiveRow, r);
						lastActiveColumn = Math.Max(lastActiveColumn, c);
					}
				}
			}

			StringBuilder sb = new StringBuilder();
			for (int r = firstActiveRow; r <= lastActiveRow; r++)
			{
				for (int c = firstActiveColumn; c <= lastActiveColumn; c++)
				{
					if (r == ant.Position.Row && c == ant.Position.Column)
					{
						sb.Append(ant.Orientation);
					}
					else if (grid[r][c])
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
