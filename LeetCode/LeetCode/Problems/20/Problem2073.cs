using System;

namespace LeetCode.Problems._20
{
	internal class Problem2073
	{
		public int TimeRequiredToBuy(int[] tickets, int k)
		{
			var kth = tickets[k];
			var res = 0;

			for (var i = 0; i <= k; i++)
				res += Math.Min(tickets[i], kth);

			for (var i = k + 1; i < tickets.Length; i++)
				res += Math.Min(tickets[i], kth - 1);

			return res;
		}
	}
}
