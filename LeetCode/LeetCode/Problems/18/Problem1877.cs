using System;

namespace LeetCode.Problems._18
{
	internal class Problem1877
	{
		public int MinPairSum(int[] nums)
		{
			Array.Sort(nums);

			var maxSum = 0;
			for (var i = 0; i < nums.Length / 2; i++)
				maxSum = Math.Max(maxSum, nums[i] + nums[nums.Length - 1 - i]);

			return maxSum;
		}
	}
}
