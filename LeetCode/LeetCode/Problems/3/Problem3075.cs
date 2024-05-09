using System;

namespace LeetCode.Problems._3
{
	internal class Problem3075
	{
		public long MaximumHappinessSum(int[] happiness, int k)
		{
			Array.Sort(happiness);
			Array.Reverse(happiness);

			var rounds = 0;
			var totalHappySum = 0;

			for (var i = 0; i < k && i < happiness.Length; i++)
			{
				var selected = happiness[i] - rounds;
				if (selected > 0)
				{
					totalHappySum += selected;
					rounds++;
				}
			}

			return totalHappySum;
		}
	}
}
