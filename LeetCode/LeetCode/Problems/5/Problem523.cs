
using System.Collections.Generic;

namespace LeetCode.Problems._5
{
	internal class Problem523
	{
		public bool CheckSubarraySum(int[] nums, int k)
		{
			var remainderMap = new Dictionary<int, int>();
			remainderMap[0] = -1;

			int runningSum = 0;

			for (var i = 0; i < nums.Length; i++)
			{
				runningSum += nums[i];

				var remainder = runningSum % k;

				if (remainder < 0)
					remainder += k;

				if (remainderMap.ContainsKey(remainder))
				{
					if (i - remainderMap[remainder] > 1)
						return true;
				}
				else
					remainderMap[remainder] = i;
			}

			return false;
		}
	}
}
