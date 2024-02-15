using System;

namespace LeetCode.Problems._29
{
	internal class Problem2971
	{
		public long LargestPerimeter(int[] nums)
		{
			Array.Sort(nums);
			var prefix = new long[nums.Length + 1];
			var i = 1;
			while (i < prefix.Length)
				prefix[i] = prefix[i - 1] + nums[i++ - 1];

			i = nums.Length - 1;

			while (i > 1)
				if (prefix[i] > nums[i--])
					return prefix[i + 2];
			return -1;
		}
	}
}
