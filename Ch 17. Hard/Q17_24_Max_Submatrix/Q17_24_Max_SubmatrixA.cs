using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_24_Max_Submatrix
{
	// 暴力解
	// Time complexity: O(N^6) 
	// Space complexity: O(1)
	public class Q17_24_Max_SubmatrixA : Question
    {
		public static SubMatrix GetMaxMatrix(int[][] matrix)
		{
			int rowCount = matrix.Length;
			int columnCount = matrix[0].Length;
			SubMatrix best = null;
			for (int row1 = 0; row1 < rowCount; row1++)
			{
				for (int row2 = row1; row2 < rowCount; row2++)
				{
					for (int col1 = 0; col1 < columnCount; col1++)
					{
						for (int col2 = col1; col2 < columnCount; col2++)
						{
							int sum = Sum(matrix, row1, col1, row2, col2);
							if (best == null || best.GetSum() < sum)
							{
								best = new SubMatrix(row1, col1, row2, col2, sum);
							}
						}
					}
				}
			}
			return best;
		}

		private static int Sum(int[][] matrix, int row1, int col1, int row2, int col2)
		{
			int sum = 0;
			for (int r = row1; r <= row2; r++)
			{
				for (int c = col1; c <= col2; c++)
				{
					sum += matrix[r][c];
				}
			}
			return sum;
		}

		public override void Run()
        {
			int[][] matrix = AssortedMethods.RandomMatrix(10, 10, -5, 5);
			AssortedMethods.PrintMatrix(matrix);
			SubMatrix sub = GetMaxMatrix(matrix);
			Console.WriteLine(sub.ToString());
		}
    }
}
