using System;
using System.Linq;

namespace LeetCode.Problems._9
{
	internal class Problem977
	{
		public int[] SortedSquares(int[] nums)
		{
			var res = nums.Select(x => x * x).ToArray();
			Array.Sort(res);
			return res;
		}
	}
}
