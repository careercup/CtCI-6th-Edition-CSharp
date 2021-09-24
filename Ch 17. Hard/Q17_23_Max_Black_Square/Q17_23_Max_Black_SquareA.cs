using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_23_Max_Black_Square
{
	// "簡單"方案
	// Time complexity: O(N^4) 
	public class Q17_23_Max_Black_SquareA : Question
    {
		public static Subsquare FindSquareA(int[][] matrix)
		{
			for (int i = matrix.Length; i >= 1; i--)
			{
				Subsquare square = FindSquareWithSize(matrix, i);
				if (square != null)
				{
					return square;
				}
			}
			return null;
		}

		public static Subsquare FindSquareWithSize(int[][] matrix, int squareSize)
		{
			// On an edge of length N, there are (N - sz + 1) squares of length sz.
			int count = matrix.Length - squareSize + 1;

			// Iterate through all squares with side length square_size.
			for (int row = 0; row < count; row++)
			{
				for (int col = 0; col < count; col++)
				{
					if (IsSquare(matrix, row, col, squareSize))
					{
						return new Subsquare(row, col, squareSize);
					}
				}
			}
			return null;
		}

		private static bool IsSquare(int[][] matrix, int row, int col, int size)
		{
			// Check top and bottom border.
			for (int j = 0; j < size; j++)
			{
				if (matrix[row][col + j] == 1)
				{
					return false;
				}
				if (matrix[row + size - 1][col + j] == 1)
				{
					return false;
				}
			}

			// Check left and right border.
			for (int i = 1; i < size - 1; i++)
			{
				if (matrix[row + i][col] == 1)
				{
					return false;
				}
				if (matrix[row + i][col + size - 1] == 1)
				{
					return false;
				}
			}
			return true;
		}

		public override void Run()
        {
			int[][] matrix = AssortedMethods.RandomMatrix(7, 7, 0, 1);
			AssortedMethods.PrintMatrix(matrix);
			Subsquare square = FindSquareA(matrix);
			square.Print();
		}
    }
}
