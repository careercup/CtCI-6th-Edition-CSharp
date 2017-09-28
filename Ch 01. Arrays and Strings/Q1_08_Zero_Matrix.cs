using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter01
{
    public class Q1_08_Zero_Matrix : Question
    {
        private void NullifyRow(int[,] matrix, int row)
        {
            var width = matrix.GetLength(1);
            for (var column = 0; column < width; column++)
            {
                matrix[row, column] = 0;
            }
        }

        private void NullifyColumn(int[,] matrix, int col)
        {
            var height = matrix.GetLength(0);
            for (var row = 0; row < height; row++)
            {
                matrix[row, col] = 0;
            }
        }

        private int[,] CloneMatrix(int[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            var clone = new int[height, width];
            for (var row = 0; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    clone[row, column] = matrix[row, column];
                }
            }
            return clone;
        }

        private bool MatricesAreEqual(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                return false;
            }

            for (var row = 0; row < matrix1.GetLength(0); row++)
            {
                for (var column = 0; column < matrix1.GetLength(1); column++)
                {
                    if (matrix1[row, column] != matrix2[row, column])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void SetZeros(int[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            var rowArray = new bool[height];
            var columnArray = new bool[width];

            // Store the row and column index with value 0
            for (var row = 0; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        rowArray[row] = true;
                        columnArray[column] = true;
                    }
                }
            }

            // Nullify rows
            for (var i = 0; i < rowArray.Length; i++)
            {
                if (rowArray[i])
                {
                    NullifyRow(matrix, i);
                }
            }

            // Nullify columns
            for (var j = 0; j < columnArray.Length; j++)
            {
                if (columnArray[j])
                {
                    NullifyColumn(matrix, j);
                }
            }
        }

        public override void Run()
        {
            const int numberOfRows = 10;
            const int numberOfColumns = 15;
            var matrix1 = AssortedMethods.RandomMatrix(numberOfRows, numberOfColumns, 0, 100);
            AssortedMethods.PrintMatrix(matrix1);
            SetZeros(matrix1);
            Console.WriteLine();
            AssortedMethods.PrintMatrix(matrix1);
        }
    }
}