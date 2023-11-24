using System;

namespace LeetCode.Problems._15
{
	internal class Problem1561
	{
		public int MaxCoins(int[] piles)
		{
			Array.Sort(piles);

			var n = piles.Length;
			var third = n / 3;
			var currMultiplier = 1;
			var res = 0;

			while (third > 0)
			{
				res += piles[n - currMultiplier * 2];
				currMultiplier++;
				third--;
			}

			return res;
		}
	}
}
