using ctci.Contracts;
using System;
using System.Collections.Generic;

namespace Chapter16
{
    static class MatrixExtentsions
    {
        static public int Height(this char[,] matrix)
        {
            return matrix.GetLength(0);
        }
        static public int Width(this char[,] matrix)
        {
            return matrix.GetLength(1);
        }

        static public bool IsOutOfBounds(this char[,] matrix, int row, int column)
        {
            if (row < 0 || row >= matrix.Height()) return true;
            if (column < 0 || column >= matrix.Width()) return true;
            return false;
        }

        static public void PrintMatrix(this char[,] matrix)
        {
            for (var r = 0; r < matrix.Height(); r++)
            {
                for (var c = 0; c < matrix.Width(); c++)
                    Console.Write(matrix[r, c]);
                Console.WriteLine();
            }
        }
    }
    public class Q16_19_Pond_Sizes : Question
    {

        public override void Run()
        {
            var matrix = new char[,]
                {
                    {'w','h','l','w'},
                    {'w','l','w','1'},
                    {'l','l','w','l'},
                    {'w','l','w','l'},
                };

            matrix.PrintMatrix();

            var sizes = GetSizes(matrix, 'w');
            Console.WriteLine("Found w");
            foreach (var size in sizes)
                Console.WriteLine(size);
        }

        public IList<int> GetSizes(char[,] matrix, char type)
        {
            var sizes = new List<int>();
            var visited = new bool[matrix.Height(), matrix.Width()];
            for (var r = 0; r < matrix.Height(); r++)
            {
                for (var c = 0; c < matrix.Width(); c++)
                {
                    if (matrix[r, c] == type && !visited[r,c])
                        sizes.Add(GetSize(matrix, visited, r, c, type));
                }
            }
            return sizes;
        }

        private int GetSize(char[,] matrix, bool[,] visited, int r, int c, char type)
        {
            if (matrix.IsOutOfBounds(r, c)) return 0;
            if (visited[r, c]) return 0;
            if (matrix[r, c] != type) return 0;
            visited[r, c] = true;
            int size = 1;
            for (var dr = -1; dr < 2; dr++)
                for (var dc = -1; dc < 2; dc++)
                    size += GetSize(matrix, visited, r + dr, c + dc, type);
            return size;
        }
    }
}
