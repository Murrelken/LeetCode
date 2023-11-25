using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._16
{
	internal class Problem1685
	{
		public int[] GetSumAbsoluteDifferences(int[] nums)
		{
			var n = nums.Length;
			var results = new Dictionary<int, int>();
			var sumToTheLeft = 0;
			var sumToTheRight = nums.Sum();
			var prev = 0;

			for (var i = 0; i < n; i++)
			{
				var currentEl = nums[i];

				sumToTheLeft += prev;
				prev = currentEl;
				sumToTheRight -= currentEl;

				if (results.ContainsKey(currentEl))
					continue;

				var currentRes = 0;
				currentRes += currentEl * i - sumToTheLeft;
				currentRes += sumToTheRight - currentEl * (n - 1 - i);

				results.Add(currentEl, currentRes);
			}

			for (var i = 0; i < n; i++)
				nums[i] = results[nums[i]];

			return nums;
		}
	}
}
