using System.Collections.Generic;

namespace LeetCode.Problems._6
{
	internal class Problem645
	{
		public int[] FindErrorNums(int[] nums)
		{
			var res = new int[2];
			var set = new HashSet<int>();
			foreach (var item in nums)
				if (set.Contains(item)) res[0] = item;
				else set.Add(item);
			for (int i = 1; i <= nums.Length; i++)
				if (!set.Contains(i)) res[1] = i;
			return res;
		}
	}
}
