using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_21_Volume_of_Histogram
{
	// 方案3(最佳化與簡化)
	// Time complexity: O(N) 
	// Space complexity: O(N)
	// N: 長條圖中長條數量(矩陣長度)
	public class Q17_21_Volume_of_HistogramC : Question
    {
		/* Go through each bar and compute the volume of water above it. 
		 * Volume of water at a bar =
		 *   height - min(tallest bar on left, tallest bar on right)
		 *   [where above equation is positive]
		 * Compute the left max in the first sweep, then sweep again to 
		 * compute the right max, minimum of the bar heights, and the 
		 * delta. */
		public static int ComputeHistogramVolumeC(int[] histo)
		{
			/* Get left max */
			int[] leftMaxes = new int[histo.Length];
			int leftMax = histo[0];
			for (int i = 0; i < histo.Length; i++)
			{
				leftMax = Math.Max(leftMax, histo[i]);
				leftMaxes[i] = leftMax;
			}

			int sum = 0;

			/* Get right max */
			int rightMax = histo[histo.Length - 1];
			for (int i = histo.Length - 1; i >= 0; i--)
			{
				rightMax = Math.Max(rightMax, histo[i]);
				int secondTallest = Math.Min(rightMax, leftMaxes[i]);

				/* If there are taller things on the left and right side, then there is 
				 * water above this bar. Compute the volume and add to the sum. */
				if (secondTallest > histo[i])
				{
					sum += secondTallest - histo[i];
				}
			}

			return sum;
		}

		public override void Run()
        {
			int[] histogram = { 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 8, 0, 2, 0, 5, 2, 0, 3, 0, 0 };
			int result = ComputeHistogramVolumeC(histogram);
			Console.WriteLine(result);
		}
    }
}
