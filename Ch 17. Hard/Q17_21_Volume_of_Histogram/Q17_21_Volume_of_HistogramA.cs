using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_21_Volume_of_Histogram
{
	// 方案1
	// Time complexity: O(N^2) 最差情況
	// Space complexity: O(1)
	// N: 長條圖中長條數量(矩陣長度)
	public class Q17_21_Volume_of_HistogramA : Question
    {
		public static int ComputeHistogramVolumeA(int[] histogram)
		{
			int start = 0;
			int end = histogram.Length - 1;

			int max = FindIndexOfMax(histogram, start, end);

			int leftVolume = SubgraphVolume(histogram, start, max, true);
			int rightVolume = SubgraphVolume(histogram, max, end, false);

			return leftVolume + rightVolume;
		}

		public static int SubgraphVolume(int[] histogram, int start, int end, bool isLeft)
		{
			if (start >= end) return 0;
			int sum = 0;
			if (isLeft)
			{
				int max = FindIndexOfMax(histogram, start, end - 1);
				sum += BorderedVolume(histogram, max, end);
				sum += SubgraphVolume(histogram, start, max, isLeft);
			}
			else
			{
				int max = FindIndexOfMax(histogram, start + 1, end);
				sum += BorderedVolume(histogram, start, max);
				sum += SubgraphVolume(histogram, max, end, isLeft);
			}

			return sum;
		}


		public static int FindIndexOfMax(int[] histogram, int start, int end)
		{
			int indexOfMax = start;
			for (int i = start + 1; i <= end; i++)
			{
				if (histogram[i] > histogram[indexOfMax])
				{
					indexOfMax = i;
				}
			}
			return indexOfMax;
		}

		public static int BorderedVolume(int[] histogram, int start, int end)
		{
			if (start >= end) return 0;

			int min = Math.Min(histogram[start], histogram[end]);
			int sum = 0;
			for (int i = start + 1; i < end; i++)
			{
				sum += min - histogram[i];
			}
			return sum;
		}

		

		

		public override void Run()
        {
			int[] histogram = { 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 8, 0, 2, 0, 5, 2, 0, 3, 0, 0 };
			int result = ComputeHistogramVolumeA(histogram);
			Console.WriteLine(result);
		}
    }
}
