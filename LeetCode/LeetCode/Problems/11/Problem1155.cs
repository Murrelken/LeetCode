namespace LeetCode.Problems._11
{
	internal class Problem1155
	{
		public int NumRollsToTarget(int n, int k, int target)
		{
			int[,] dp = new int[n + 1, target + 1];
			dp[0, 0] = 1;

			for (var dice = 1; dice <= n; dice++)
				for (var sum = 1; sum <= target; sum++)
					for (int face = 1; face <= sum && face <= k; face++)
					{
						dp[dice, sum] += dp[dice - 1, sum - face];
						dp[dice, sum] %= 1000000007;
					}
			return dp[n, target];
		}
	}
}
