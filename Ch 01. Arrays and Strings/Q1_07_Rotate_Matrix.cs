using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter01
{
    public class Q1_07_Rotate_Matrix : Question
    {
		public static bool Rotate(int[][] matrix)
		{
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

		public override void Run()
        {
            const int size = 3;

            var matrix = AssortedMethods.RandomMatrix(size, size, 0, 9);

            AssortedMethods.PrintMatrix(matrix);

            Rotate(matrix);
            Console.WriteLine();
            AssortedMethods.PrintMatrix(matrix);
        }
    }
}
