using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_24_Max_Submatrix
{
    // 動態規劃方案
    // Time complexity: O(N^4) 
    // Space complexity: O(N^2)
    public class Q17_24_Max_SubmatrixB : Question
    {
		public static SubMatrix GetMaxMatrixB(int[][] matrix)
		{
			SubMatrix best = null;
			int rowCount = matrix.Length;
			int columnCount = matrix[0].Length;
			int[][] sumThrough = PrecomputeSums(matrix);

			for (int row1 = 0; row1 < rowCount; row1++)
			{
				for (int row2 = row1; row2 < rowCount; row2++)
				{
					for (int col1 = 0; col1 < columnCount; col1++)
					{
						for (int col2 = col1; col2 < columnCount; col2++)
						{
							int sum = Sum(sumThrough, row1, col1, row2, col2);
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

		private static int[][] PrecomputeSums(int[][] matrix)
		{
			int[][] sumThrough = new int[matrix.Length][];
			for (int r = 0; r < matrix.Length; r++)
			{
				sumThrough[r] = new int[matrix[0].Length];
				for (int c = 0; c < matrix[0].Length; c++)
				{
					int left = c > 0 ? sumThrough[r][c - 1] : 0;
					int top = r > 0 ? sumThrough[r - 1][c] : 0;
					int overlap = r > 0 && c > 0 ? sumThrough[r - 1][c - 1] : 0;
					sumThrough[r][c] = left + top - overlap + matrix[r][c];
				}
			}
			return sumThrough;
		}

		private static int Sum(int[][] sumThrough, int r1, int c1, int r2, int c2)
		{
			int topAndLeft = r1 > 0 && c1 > 0 ? sumThrough[r1 - 1][c1 - 1] : 0;
			int left = c1 > 0 ? sumThrough[r2][c1 - 1] : 0;
			int top = r1 > 0 ? sumThrough[r1 - 1][c2] : 0;
			int full = sumThrough[r2][c2];
			return full - left - top + topAndLeft;
		}

		public override void Run()
        {
			int[][] matrix = AssortedMethods.RandomMatrix(10, 10, -5, 5);
			AssortedMethods.PrintMatrix(matrix);
			Console.WriteLine(GetMaxMatrixB(matrix));
		}
    }
}
