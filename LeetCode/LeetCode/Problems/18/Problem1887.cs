using System;

namespace LeetCode.Problems._18
{
	internal class Problem1887
	{
		public int ReductionOperations(int[] nums)
		{
			Array.Sort(nums);
			var currItem = nums[0];
			var currStep = 0;
			var res = 0;

			for (var i = 1; i < nums.Length; i++)
			{
				if (nums[i] == currItem)
					res += currStep;
				else
				{
					currItem = nums[i];
					currStep++;
					res += currStep;
				}
			}

			return res;
		}
	}
}
