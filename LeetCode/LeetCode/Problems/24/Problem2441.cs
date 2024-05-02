using System;

namespace LeetCode.Problems._24
{
	internal class Problem2441
	{
		public int FindMaxK(int[] nums)
		{
			Array.Sort(nums);
			var maxK = -1;

			var left = 0;
			var right = nums.Length - 1;
			while (left < right)
			{
				var sum = nums[left] + nums[right];
				if (sum == 0)
				{
					maxK = Math.Max(maxK, Math.Abs(nums[right]));
					left++;
					right--;
				}
				else if (sum < 0)
					left++;
				else
					right--;
			}

			return maxK;
		}
	}
}
