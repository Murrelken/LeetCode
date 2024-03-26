using System.Collections.Generic;

namespace LeetCode.Problems._4
{
	internal class Problem442
	{
		public IList<int> FindDuplicates(int[] nums)
		{
			var unique = new HashSet<int>();
			var res = new List<int>();
			foreach (var n in nums)
				if (!unique.Add(n))
					res.Add(n);
			return res;
		}
	}
}
