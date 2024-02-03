using System;

namespace LeetCode.Problems._10
{
	internal class Problem1043
	{
		public int MaxSumAfterPartitioning(int[] arr, int k)
		{
			var n = arr.Length;
			var dp = new int[n + 1];
			for (var i = 0; i < n; i++)
			{
				int curMax = 0, curSum = 0;
				for (var j = i; j > Math.Max(-1, i - k); j--)
				{
					if (curMax < arr[j])
						curMax = arr[j];
					var temp = curMax * (i - j + 1) + dp[j];
					if (curSum < temp)
						curSum = temp;
				}
				dp[i + 1] = curSum;
			}
			return dp[n];
		}
	}
}
