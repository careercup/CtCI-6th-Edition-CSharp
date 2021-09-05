using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_02_Robot_in_a_Grid
{
	// Time complexity: O(2^(r+c))
	public class Q8_02_Robot_in_a_GridA : Question
    {
		public static IList<Point> GetPath(bool[][] maze)
        {
			if (maze == null || maze.Length == 0) return null;
			IList<Point> path = new List<Point>();
			if (GetPath(maze, maze.Length - 1, maze[0].Length - 1, path))
			{
				return path;
			}
			return null;
		}

		public static bool GetPath(bool[][] maze, int row, int col, IList<Point> path)
		{
			// If out of bounds or not available, return.
			if (col < 0 || row < 0 || !maze[row][col])
			{
				return false;
			}

			bool isAtOrigin = (row == 0) && (col == 0);

			// If there's a path from the start to my current location, add my location.
			if (isAtOrigin || GetPath(maze, row, col - 1, path) || GetPath(maze, row - 1, col, path))
			{
				Point p = new Point(row, col);
				path.Add(p);
				return true;
			}

			return false;
		}

		public override void Run()
        {
			int size = 5;
			bool[][] maze = AssortedMethods.RandomBooleanMatrix(size, size, 70);

			AssortedMethods.PrintMatrix(maze);

			IList<Point> path = GetPath(maze);
			if (path != null)
			{
                foreach (var point in path)
                {
					Console.Write($"{point} => ");
                }
				Console.WriteLine("");
			}
			else
			{
				Console.WriteLine("No path found.");
			}
		}
    }
}
