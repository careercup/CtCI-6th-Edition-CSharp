using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_23_Max_Black_Square
{
	// 預先處理方案
	// Time complexity: O(N^3) 
	public class Q17_23_Max_Black_Square_EfficiencyB : Question
    {
		public static Subsquare FindSquareB(int[][] matrix)
		{

			SquareCell[][] processed = ProcessSquare(matrix);

			for (int i = matrix.Length; i >= 1; i--)
			{
				Subsquare square = FindSquareWithSize(processed, i);
				if (square != null)
				{
					return square;
				}
			}
			return null;
		}

		public static Subsquare FindSquareWithSize(SquareCell[][] processed, int square_size)
		{
			// On an edge of length N, there are (N - sz + 1) squares of length sz.
			int count = processed.Length - square_size + 1;

			// Iterate through all squares with side length square_size.
			for (int row = 0; row < count; row++)
			{
				for (int col = 0; col < count; col++)
				{
					if (IsSquare(processed, row, col, square_size))
					{
						return new Subsquare(row, col, square_size);
					}
				}
			}
			return null;
		}

		

		private static bool IsSquare(SquareCell[][] matrix, int row, int col, int size)
		{
			SquareCell topLeft = matrix[row][col];
			SquareCell topRight = matrix[row][col + size - 1];
			SquareCell bottomRight = matrix[row + size - 1][col];
			if (topLeft.ZerosRight < size)
			{ // Check top edge
				return false;
			}
			if (topLeft.ZerosBelow < size)
			{ // Check left edge
				return false;
			}
			if (topRight.ZerosBelow < size)
			{ // Check right edge
				return false;
			}
			if (bottomRight.ZerosRight < size)
			{ // Check bottom edge
				return false;
			}
			return true;
		}

		public static SquareCell[][] ProcessSquare(int[][] matrix)
		{
			SquareCell[][] processed = new SquareCell[matrix.Length][];

			for (int r = matrix.Length - 1; r >= 0; r--)
			{
				processed[r] = new SquareCell[matrix.Length];
				for (int c = matrix.Length - 1; c >= 0; c--)
				{
					int rightZeros = 0;
					int belowZeros = 0;
					if (matrix[r][c] == 0)
					{ // only need to process if it's a black cell
						rightZeros++;
						belowZeros++;
						if (c + 1 < matrix.Length)
						{ // next column over is on same row
							SquareCell previous = processed[r][c + 1];
							rightZeros += previous.ZerosRight;
						}
						if (r + 1 < matrix.Length)
						{
							SquareCell previous = processed[r + 1][c];
							belowZeros += previous.ZerosBelow;
						}
					}
					processed[r][c] = new SquareCell(rightZeros, belowZeros);
				}
			}
			return processed;
		}

		public override void Run()
        {
			int[][] matrix = AssortedMethods.RandomMatrix(7, 7, 0, 1);
			AssortedMethods.PrintMatrix(matrix);
			Subsquare square = FindSquareB(matrix);
			square.Print();
		}
    }
}
