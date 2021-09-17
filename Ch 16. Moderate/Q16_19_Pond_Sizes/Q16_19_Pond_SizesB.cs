using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_19_Pond_Sizes
{
	// dfs
	// Time complexity: O(WH)
	// W: 矩陣寬
	// H: 矩陣高
	public class Q16_19_Pond_SizesB : Question
    {
		public static IList<int> ComputePondSizesB(int[][] land)
		{
			bool[][] visited = new bool[land.Length][];
            for (int i = 0; i < land.Length; i++)
            {
				visited[i] = new bool[land[0].Length];
            }
			IList<int> pondSizes = new List<int>();
			for (int r = 0; r < land.Length; r++)
			{
				for (int c = 0; c < land[r].Length; c++)
				{
					int size = ComputeSize(land, visited, r, c);
					if (size > 0)
					{
						pondSizes.Add(size);
					}
				}
			}
			return pondSizes;
		}

		public static int ComputeSize(int[][] land, bool[][] visited, int row, int col)
		{
			/* If out of bounds or already visited. */
			if (row < 0 || col < 0 || row >= land.Length || col >= land[row].Length || visited[row][col] || land[row][col] != 0)
			{
				return 0;
			}
			int size = 1;
			visited[row][col] = true;
			for (int dr = -1; dr <= 1; dr++)
			{
				for (int dc = -1; dc <= 1; dc++)
				{
					size += ComputeSize(land, visited, row + dr, col + dc);
				}
			}
			return size;
		}

		public override void Run()
        {
			int[][] land = {
				new int[] { 0, 2, 1, 0 },
				new int[] { 0, 1, 0, 1 },
				new int[] { 1, 1, 0, 1 },
				new int[] { 0, 1, 0, 1 }
			};
			IList<int> sizes = ComputePondSizesB(land);
			foreach (int sz in sizes)
			{
				Console.WriteLine(sz);
			}
		}
    }
}
