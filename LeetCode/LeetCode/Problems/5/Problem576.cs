namespace LeetCode.Problems._5
{
	internal class Problem576
	{
		private const int MOD = 1_000_000_000 + 7;
		private int _m, _n;
		public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
		{
			int[,,] dp = new int[m, n, maxMove + 1];
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					for (int k = 0; k <= maxMove; k++)
					{
						dp[i, j, k] = -1;
					}
				}
			}

			_m = m;
			_n = n;
			return Helper(maxMove, startRow, startColumn, dp);
		}

		private int Helper(int maxMove, int x, int y, int[,,] dp)
		{
			if (x < 0 || x >= _m || y < 0 || y >= _n) return 1;
			if (maxMove <= 0) return 0;
			if (dp[x, y, maxMove] != -1)
			{
				return dp[x, y, maxMove];
			}
			int res = 0;

			res = (res + Helper(maxMove - 1, x + 1, y, dp)) % MOD;
			res = (res + Helper(maxMove - 1, x, y - 1, dp)) % MOD;
			res = (res + Helper(maxMove - 1, x - 1, y, dp)) % MOD;
			res = (res + Helper(maxMove - 1, x, y + 1, dp)) % MOD;

			dp[x, y, maxMove] = res;

			return res;
		}
	}
}
