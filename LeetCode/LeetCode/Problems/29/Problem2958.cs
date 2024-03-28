using System;
using System.Collections.Generic;

namespace LeetCode.Problems._29
{
	internal class Problem2958
	{
		public int MaxSubarrayLength(int[] nums, int k)
		{
			var left = 0;
			var right = 0;
			var res = 0;
			var count = new Dictionary<int, int>();

			while (right < nums.Length)
			{
				if (!count.TryAdd(nums[right], 1))
					count[nums[right]]++;

				if (count[nums[right]] > k)
				{
					res = Math.Max(res, right - left);
					while (nums[left] != nums[right])
					{
						count[nums[left]]--;
						left++;
					}
					count[nums[left]]--;
					left++;
				}

				right++;
			}

			res = Math.Max(res, right - left);
			return res;
		}
	}
}
