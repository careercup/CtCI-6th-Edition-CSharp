using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_17_Contiguous_Sequence
{
    public class Q16_17_Contiguous_Sequence : Question
    {
        // Time complexity: O(n)
        public static int GetMaxSum(int[] nums)
		{
            // f[i] // MaxSubArray(0....i)
            // f[i]= f[i - 1] > 0 ? nums[i] + f[i - 1] : nums[i];
            // Time complexity: O(n)

            #region Space complexity: O(n)
            /*
            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
            }
            return dp.Max();
            */
            #endregion

            // Space complexity: O(1)
            int sum = nums[0];
            int ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(sum + nums[i], nums[i]);
                if (sum > ans) ans = sum;
            }
            return ans;
        }

		public override void Run()
        {
			int[] a = { 2, -8, 3, -2, 4, -10 };
			Console.WriteLine(GetMaxSum(a));
		}
    }
}
