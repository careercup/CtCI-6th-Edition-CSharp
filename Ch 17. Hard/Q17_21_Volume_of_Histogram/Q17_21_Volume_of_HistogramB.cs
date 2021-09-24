using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_21_Volume_of_Histogram
{
	// 方案2(最佳化)
	// Time complexity: O(N) 
	// Space complexity: O(N)
	// N: 長條圖中長條數量(矩陣長度)
	public class Q17_21_Volume_of_HistogramB : Question
    {
		public static int ComputeHistogramVolumeB(int[] histogram)
		{
			int start = 0;
			int end = histogram.Length - 1;

			HistogramData[] data = CreateHistogramData(histogram);

			int max = data[0].GetRightMaxIndex();

			int leftVolume = SubgraphVolume(data, start, max, true);
			int rightVolume = SubgraphVolume(data, max, end, false);

			return leftVolume + rightVolume;
		}	

		public static HistogramData[] CreateHistogramData(int[] histo)
		{
			HistogramData[] histogram = new HistogramData[histo.Length];
			for (int i = 0; i < histo.Length; i++)
			{
				histogram[i] = new HistogramData(histo[i]);
			}

			/* Set left max index. */
			int maxIndex = 0;
			for (int i = 0; i < histo.Length; i++)
			{
				if (histo[maxIndex] < histo[i])
				{
					maxIndex = i;
				}
				histogram[i].SetLeftMaxIndex(maxIndex);
			}

			/* Set right max index. */
			maxIndex = histogram.Length - 1;
			for (int i = histogram.Length - 1; i >= 0; i--)
			{
				if (histo[maxIndex] < histo[i])
				{
					maxIndex = i;
				}
				histogram[i].SetRightMaxIndex(maxIndex);
			}

			return histogram;
		}

		public static int SubgraphVolume(HistogramData[] histogram, int start, int end, bool isLeft)
		{
			if (start >= end) return 0;
			int sum = 0;
			if (isLeft)
			{
				int max = histogram[end - 1].GetLeftMaxIndex();
				sum += BorderedVolume(histogram, max, end);
				sum += SubgraphVolume(histogram, start, max, isLeft);
			}
			else
			{
				int max = histogram[start + 1].GetRightMaxIndex();
				sum += BorderedVolume(histogram, start, max);
				sum += SubgraphVolume(histogram, max, end, isLeft);
			}

			return sum;
		}

		public static int BorderedVolume(HistogramData[] data, int start, int end)
		{
			if (start >= end) return 0;

			int min = Math.Min(data[start].GetHeight(), data[end].GetHeight());
			int sum = 0;
			for (int i = start + 1; i < end; i++)
			{
				sum += min - data[i].GetHeight();
			}
			return sum;
		}


		public override void Run()
        {
			int[] histogram = { 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 8, 0, 2, 0, 5, 2, 0, 3, 0, 0 };
			int result = ComputeHistogramVolumeB(histogram);
			Console.WriteLine(result);
		}
    }
}
