using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter01
{
    public class Q1_07_Rotate_Matrix : Question
    {
        private void Rotate(int[,] matrix, int n)
        {
            for (var layer = 0; layer < n / 2; ++layer)
            {
                var first = layer;
                var last = n - 1 - layer;
                for (var i = first; i < last; ++i)
                {
                    var offset = i - first;
                    var top = matrix[first, i]; // save top, left

                    // top, left <- bottom, left 
                    matrix[first, i] = matrix[last - offset, first];

                    // bottom, left <- bottom, right
                    matrix[last - offset, first] = matrix[last, last - offset];

                    // bottom, right <- top, right
                    matrix[last, last - offset] = matrix[i, last];

                    // top, right <- top
                    matrix[i, last] = top;
                }
            }
        }

        public override void Run()
        {
            var matrix = new[,]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };

            AssortedMethods.PrintMatrix(matrix);

            Rotate(matrix, matrix.GetLength(0));
            Console.WriteLine();
            AssortedMethods.PrintMatrix(matrix);
        }
    }
}