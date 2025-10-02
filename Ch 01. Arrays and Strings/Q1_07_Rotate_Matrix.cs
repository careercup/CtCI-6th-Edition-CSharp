using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter01
{
    public class Q1_07_Rotate_Matrix : Question
    {
        private bool IsSquareMatrix(int[][] matrix)
        {
            int matrixSize = matrix.Length;  // The 'amount of rows in the matrix' is the 'matrixSize'.
            int minNumberOfRowsNeededForSquareMatrix = 2;
            if (matrixSize < minNumberOfRowsNeededForSquareMatrix)
            {
                return false;
            }

            // Now, check the length of all the rows to make sure we have a
            // square matrix, as 1 or more rows may be too small or too big.
            for (int row = 0; row < matrix[row].Length; row++)
            {
                if (matrixSize != matrix[row].Length)
                {
                    return false;
                }
            }
            return true;  // No errors so far, so we must have a square matrix.
        }

        private void Rotate(int[][] matrix)
        {
            if (!IsSquareMatrix(matrix))  // Edge case + error checking.
            {
                return;
            }

            int matrixSize = matrix.Length;
            for (int layer = 0; layer < matrixSize / 2; layer++)
            {
                int startIndex = layer;
                int lastIndex = (matrixSize - 1) - layer;

                for (int elementIndex = startIndex; elementIndex < lastIndex; elementIndex++)
                {
                    // Need this offset so we don't reference the incorrect rows and columns when more layers occur.
                    int offset = elementIndex - layer;

                    // Write a diagram to help visualise and understand what occurs below:
                    int topRowElement = matrix[startIndex][elementIndex]; // save top

                    // left -> top
                    matrix[startIndex][elementIndex] = matrix[lastIndex - offset][startIndex];

                    // bottom -> left
                    matrix[lastIndex - offset][startIndex] = matrix[lastIndex][lastIndex - offset];

                    // right -> bottom
                    matrix[lastIndex][lastIndex - offset] = matrix[elementIndex][lastIndex];

                    // top -> right
                    matrix[elementIndex][lastIndex] = topRowElement; // right <- saved top
                }
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
