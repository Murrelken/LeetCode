using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
	public class Problem1642
	{
		public int FurthestBuilding(int[] heights, int bricks, int ladders)
		{
			var heightsNeededToCover = new SortedList<int, int>();
			var totalCount = 0;

			int i;
			for (i = 0; i < heights.Length - 1; i++)
			{
				if (heights[i + 1] <= heights[i]) continue;

				var diff = heights[i + 1] - heights[i];
				if (heightsNeededToCover.ContainsKey(diff))
					heightsNeededToCover[diff]++;
				else
					heightsNeededToCover.Add(diff, 1);
				totalCount++;

				if (totalCount <= ladders) continue;

				var min = heightsNeededToCover.First().Key;
				bricks -= min;

				if (bricks < 0) break;

				totalCount--;
				if (heightsNeededToCover[min] == 1)
					heightsNeededToCover.Remove(min);
				else
					heightsNeededToCover[min]--;
			}

			return i;
		}

		public int FurthestBuilding_v2(int[] heights, int bricks, int ladders)
		{
			var heightsCoveredWithLadders = new SortedList<int, int>();

			for (var i = 1; i < heights.Length; i++)
			{
				var h = heights[i] - heights[i - 1];

				if (h <= 0) continue;

				if (ladders > 0)
				{
					ladders--;
					heightsCoveredWithLadders.Add(h, h);
				}
				else
				{
					var min = heightsCoveredWithLadders.Count == 0
						? h
						: Math.Min(heightsCoveredWithLadders.GetKeyAtIndex(0), h);
					var coveringForLadder = heightsCoveredWithLadders.Count != 0 && heightsCoveredWithLadders.GetKeyAtIndex(0) < h;

					if (bricks >= min)
					{
						bricks -= min;
						if (coveringForLadder)
						{
							heightsCoveredWithLadders.Remove(min);
							heightsCoveredWithLadders.Add(h, h);
						}
					}
					else return i - 1;
				}
			}

			return heights.Length - 1;
		}
	}
}