using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05.Q5_03_Flip_Bit_to_Win
{
	// 最佳化演算法
	// Time complexity: O(b)
	// Space complexity: O(1)
	// b: 序列長度
	public class Q5_03_Flip_Bit_to_Win_D : Question
    {
		public static int FlipBit(int a)
		{
			/* If all 1s, this is already the longest sequence. */
			if (~a == 0) return 32;

			int currentLength = 0;
			int previousLength = 0;
			int maxLength = 1; // We can always have a sequence of at least one 1
			while (a != 0) 
			{
				if ((a & 1) == 1)
				{
					currentLength++;
				}
				else if ((a & 1) == 0)
				{
					/* Update to 0 (if next bit is 0) or currentLength (if next bit is 1). */
					previousLength = (a & 2) == 0 ? 0 : currentLength;
					currentLength = 0;
				}
				maxLength = Math.Max(previousLength + currentLength + 1, maxLength);
				a >>= 1;
				if (a == -1) break;
			}
			return maxLength;
		}
		public override void Run()
        {
			int[][] cases = {
				new int[]{-1, 32},
				new int[]{int.MaxValue, 32},
				new int[]{-10, 31},
				new int[]{0, 1},
				new int[]{1, 2},
				new int[]{15, 5},
				new int[]{1775, 8}};
			foreach (int[] c in cases)
			{
				int x = FlipBit(c[0]);
				bool r = (c[1] == x);
				Console.WriteLine(c[0] + ": " + x + ", " + c[1] + " " + r);
			}
		}
    }
}
