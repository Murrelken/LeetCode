using System;

namespace LeetCode.Problems._15
{
	internal class Problem1578
	{
		public int MinCost(string colors, int[] neededTime)
		{
			var iteratingOverTheSameColor = false;
			var max = int.MinValue;
			var tempCost = 0;
			var totalCost = 0;

			for (var i = 0; i < colors.Length - 1; i++)
			{
				if (colors[i] == colors[i + 1] || iteratingOverTheSameColor)
				{
					max = Math.Max(max, neededTime[i]);
					tempCost += neededTime[i];
					iteratingOverTheSameColor = true;
					if (colors[i] != colors[i + 1])
					{
						iteratingOverTheSameColor = false;
						totalCost += tempCost - max;
						tempCost = 0;
						max = int.MinValue;
					}
				}
			}

			if (iteratingOverTheSameColor)
			{
				max = Math.Max(max, neededTime[^1]);
				tempCost += neededTime[^1];
				totalCost += tempCost - max;
			}

			return totalCost;
		}
	}
}
