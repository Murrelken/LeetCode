using System;
using System.Linq;

namespace LeetCode.Problems._4
{
	internal class Problem452
	{
		public int FindMinArrowShots(int[][] points)
		{
			Array.Sort(points, (x, y) => x[0].CompareTo(y[0]));
			// Equals to 1 because at the end you stop without counting the last interval in anyway
			var res = 1;
			var interval = points[0];

            foreach (var item in points.Skip(1))
			{
				if (item[0] <= interval[1])
				{
					interval[0] = Math.Max(interval[0], item[0]);
					interval[1] = Math.Min(interval[1], item[1]);
				}
				else
				{
					res++;
					interval = item;
				}
			}

			return res;
        }
	}
}
