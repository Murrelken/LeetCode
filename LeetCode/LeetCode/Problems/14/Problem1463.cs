using System;

namespace LeetCode.Problems._14
{
	internal class Problem1463
	{
		public int CherryPickup(int[][] grid)
		{
			int n = grid.Length;
			int m = grid[0].Length;

			int[][][] dp = new int[n][][];
			for (int i = 0; i < n; i++)
			{
				dp[i] = new int[m][];
				for (int j = 0; j < m; j++)
				{
					dp[i][j] = new int[m];
				}
			}

			int cherries = 0;
			dp[0][0][m - 1] = grid[0][0] + grid[0][m - 1];

			for (int i = 1; i < n; ++i)
				for (int j = 0; j < m; ++j)
					for (int k = 0; k < m; ++k)
					{
						if (j > i || k < m - i - 1 || j > k) continue;
						dp[i][j][k] = dp[i - 1][j][k];
						if (j - 1 >= 0)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j - 1][k]);
						if (j - 1 >= 0 && k - 1 >= 0)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j - 1][k - 1]);
						if (j - 1 >= 0 && k + 1 < m)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j - 1][k + 1]);
						if (j + 1 < m)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j + 1][k]);
						if (j + 1 < m && k - 1 >= 0)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j + 1][k - 1]);
						if (j + 1 < m && k + 1 < m)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j + 1][k + 1]);
						if (k - 1 >= 0)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j][k - 1]);
						if (k + 1 < m)
							dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j][k + 1]);
						if (j != k)
							dp[i][j][k] += grid[i][j] + grid[i][k];
						else
							dp[i][j][k] += grid[i][j];
						cherries = Math.Max(cherries, dp[i][j][k]);
					}

			return cherries;
		}
	}
}
