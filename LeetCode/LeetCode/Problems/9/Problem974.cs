using System.Collections.Generic;

namespace LeetCode.Problems._9
{
	internal class Problem974
	{
		public int SubarraysDivByK(int[] nums, int k)
		{
			var count = 0;
			var prefixSum = 0;
			var remainderCounts = new Dictionary<int, int>
			{
				[0] = 1
			};

			foreach (var num in nums)
			{
				prefixSum += num;
				var mod = ((prefixSum % k) + k) % k;

				if (remainderCounts.ContainsKey(mod))
				{
					count += remainderCounts[mod];
					remainderCounts[mod]++;
				}
				else
					remainderCounts[mod] = 1;
			}

			return count;
		}
	}
}
