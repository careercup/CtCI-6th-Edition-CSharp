using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_24_Max_Submatrix
{
    // 最佳化方案
    // Time complexity: O(N^3) 
    // Space complexity: O(N)
    public class Q17_24_Max_SubmatrixC : Question
    {
		public static SubMatrix GetMaxMatrixC(int[][] matrix)
		{
			int rowCount = matrix.Length;
			int colCount = matrix[0].Length;

			SubMatrix best = null;

			for (int rowStart = 0; rowStart < rowCount; rowStart++)
			{
				int[] partialSum = new int[colCount];

				for (int rowEnd = rowStart; rowEnd < rowCount; rowEnd++)
				{
					/* Add values at row rowEnd. */
					for (int i = 0; i < colCount; i++)
					{
						partialSum[i] += matrix[rowEnd][i];
					}

					Range bestRange = MaxSubArray(partialSum, colCount);
					if (best == null || best.GetSum() < bestRange.Sum)
					{
						best = new SubMatrix(rowStart, bestRange.Start, rowEnd, bestRange.End, bestRange.Sum);
					}
				}
			}
			return best;
		}

		public static Range MaxSubArray(int[] array, int N)
		{
			Range best = null;
			int start = 0;
			int sum = 0;

			for (int i = 0; i < N; i++)
			{
				sum += array[i];
				if (best == null || sum > best.Sum)
				{
					best = new Range(start, i, sum);
				}

				/* If running_sum is < 0 no point in trying to continue the 
				 * series. Reset. */
				if (sum < 0)
				{
					start = i + 1;
					sum = 0;
				}
			}
			return best;
		}

		public override void Run()
        {
            int[][] matrix = AssortedMethods.RandomMatrix(10, 10, -5, 5);
            AssortedMethods.PrintMatrix(matrix);
            Console.WriteLine(GetMaxMatrixC(matrix));
        }
    }
}
