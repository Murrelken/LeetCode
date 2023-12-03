using System;

namespace LeetCode.Problems._12
{
	internal class Problem1266
	{
		public int MinTimeToVisitAllPoints(int[][] points)
		{
			var res = 0;
			for (var i = 0; i < points.Length - 1; i++)
			{
				var current = points[i];
				var next = points[i + 1];
				var xDiff = Math.Abs(current[0] - next[0]);
				var yDiff = Math.Abs(current[1] - next[1]);
				res += Math.Min(xDiff, yDiff);
				res += Math.Abs(xDiff - yDiff);
			}
			return res;
		}
	}
}
