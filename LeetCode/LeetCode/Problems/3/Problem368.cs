using System;
using System.Collections.Generic;

namespace LeetCode.Problems._3
{
	internal class Problem368
	{
		public List<int> LargestDivisibleSubset(int[] nums)
		{
			Array.Sort(nums);
			var n = nums.Length;
			var a = new int[n];
			var prev = new int[n];
			var max_len = 0;
			var max_index = -1;

			for (var i = 0; i < n; i++)
			{
				a[i] = 1;
				prev[i] = -1;

				for (var j = i - 1; j >= 0; j--)
				{
					if (nums[i] % nums[j] == 0 && a[j] + 1 > a[i])
					{
						a[i] = a[j] + 1;
						prev[i] = j;
					}
				}

				if (a[i] > max_len)
				{
					max_len = a[i];
					max_index = i;
				}
			}

			var result = new List<int>();
			while (max_index != -1)
			{
				result.Add(nums[max_index]);
				max_index = prev[max_index];
			}

			result.Reverse();
			return result;
		}
	}
}
