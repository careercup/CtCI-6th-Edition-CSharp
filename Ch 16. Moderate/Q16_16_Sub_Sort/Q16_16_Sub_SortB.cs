using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_16_Sub_Sort
{
    public class Q16_16_Sub_SortB : Question
    {
		public static Range FindUnsortedSequenceB(int[] array)
		{
			int rightSequenceStart = FindRightSequenceStart(array);
			int leftSequenceEnd = FindLeftSequenceEnd(array);
			return new Range(leftSequenceEnd, rightSequenceStart);
		}

		public static int FindRightSequenceStart(int[] array)
		{
			int max = int.MinValue;
			int lastNo = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (max > array[i])
				{
					lastNo = i;
				}
				max = Math.Max(array[i], max);
			}
			return lastNo;
		}

		public static int FindLeftSequenceEnd(int[] array)
		{
			int min = int.MaxValue;
			int lastNo = 0;
			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (min < array[i])
				{
					lastNo = i;
				}
				min = Math.Min(array[i], min);
			}
			return lastNo;
		}

		public override void Run()
        {
			int[] array = { 1, 2, 4, 7, 10, 11, 8, 12, 5, 6, 16, 18, 19 };
			Range r = FindUnsortedSequenceB(array);
			Console.WriteLine(r.ToString());
			Console.WriteLine(array[r.Start] + ", " + array[r.End]);
		}
    }
}
