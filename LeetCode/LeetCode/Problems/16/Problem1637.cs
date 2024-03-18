using System;

namespace LeetCode.Problems._16
{
	internal class Problem1637
	{
		public int MaxWidthOfVerticalArea(int[][] points)
		{
			Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
			var max = 0;
			for (var i = 1; i < points.Length; i++)
				max = Math.Max(points[i][0] - points[i - 1][0], max);
			return max;
		}
	}
}
