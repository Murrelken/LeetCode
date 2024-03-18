using System;

namespace LeetCode.Problems._18
{
	internal class Problem1838
	{
		public int MaxFrequency(int[] nums, int k)
		{
			Array.Sort(nums);
			var left = 0;
			var ans = 0;
			var curr = 0;

			for (var right = 0; right < nums.Length; right++)
			{
				var target = nums[right];
				curr += target;

				while ((right - left + 1) * target - curr > k)
				{
					curr -= nums[left];
					left++;
				}

				ans = Math.Max(ans, right - left + 1);
			}

			return ans;
		}
	}
}
