using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter01
{
    public class Q1_07_Rotate_Matrix : Question
    {
		public static bool RotateA(int[][] matrix)
		{
			// Time complexity: O(n^2)
			// Space complexity: O(1)
			if (matrix.Length == 0 || matrix.Length != matrix[0].Length) return false; // Not a square
			else
            {
				int n = matrix.Length;

				for (int layer = 0; layer < n / 2; layer++)
				{
					int first = layer;
					int last = n - 1 - layer;
					for (int i = first; i < last; i++)
					{
						int offset = i - first;
						int top = matrix[first][i]; // save top

						// left -> top
						matrix[first][i] = matrix[last - offset][first];

						// bottom -> left
						matrix[last - offset][first] = matrix[last][last - offset];

						// right -> bottom
						matrix[last][last - offset] = matrix[i][last];

						// top -> right
						matrix[i][last] = top; // right <- saved top
					}
				}
				return true;
			}
		}

		public bool RotateB(int[][] matrix)
		{
			// Time complexity: O(n^2)
			// Space complexity: O(1)
			if (matrix.Length == 0 || matrix.Length != matrix[0].Length) return false; // Not a square
			else
			{
				#region 旋轉2維矩陣問題
				// -90度(順時針90度)：轉置左對角線，再對 Y 軸 反轉
				// 90度(逆時針90度)：轉置左對角線，再對 X 軸 反轉
				// 180度：轉置左對角線，再轉置右對角線
				#endregion

				Transpose(matrix);
				Reflect(matrix);
				return true;

			}
		}
		// mirror around diagonal
		private void Transpose(int[][] matrix) 
		{
			int n = matrix.Length;
			for (int r = 0; r < n; r++)
			{
				for (int c = r + 1; c < n; c++) // +1 為不需要做自己的互換
				{
					int temp = matrix[r][c];
					matrix[r][c] = matrix[c][r];
					matrix[c][r] = temp;
				}
			}
		}

		// mirror around y axis
		private void Reflect(int[][] matrix) 
		{
			int n = matrix.Length;
			/*
			for (int r = 0; r < n; r++)
			{
				Array.Reverse(matrix[r]);
			}
			*/
			for (int r = 0; r < n; r++)
			{
				for (int c = 0; c < n / 2; c++)
				{
					int tmp = matrix[r][c];
					matrix[r][c] = matrix[r][n - c - 1];
					matrix[r][n - c - 1] = tmp;
				}
			}
		}

		public override void Run()
        {
            const int size = 3;

            var matrix = AssortedMethods.RandomMatrix(size, size, 0, 9);

            AssortedMethods.PrintMatrix(matrix);

            RotateB(matrix);
            Console.WriteLine();
            AssortedMethods.PrintMatrix(matrix);
        }
    }
}
