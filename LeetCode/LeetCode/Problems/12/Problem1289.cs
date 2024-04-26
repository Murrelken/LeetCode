
namespace LeetCode.Problems._12
{
	internal class Problem1289
	{
		public int MinFallingPathSum(int[][] grid)
		{
			var n = grid.Length;
			var memo = new int[n, n];

			var next_min1_c = -1;
			var next_min2_c = -1;

			for (var col = 0; col < n; col++)
			{
				memo[n - 1, col] = grid[n - 1][col];
				if (next_min1_c == -1 || memo[n - 1, col] <= memo[n - 1, next_min1_c])
				{
					next_min2_c = next_min1_c;
					next_min1_c = col;
				}
				else if (next_min2_c == -1 || memo[n - 1, col] <= memo[n - 1, next_min2_c])
					next_min2_c = col;
			}

			for (var row = n - 2; row >= 0; row--)
			{
				var min1_c = -1;
				var min2_c = -1;

				for (var col = 0; col < n; col++)
				{
					if (col != next_min1_c)
						memo[row, col] = grid[row][col] + memo[row + 1, next_min1_c];
					else
						memo[row, col] = grid[row][col] + memo[row + 1, next_min2_c];

					if (min1_c == -1 || memo[row, col] <= memo[row, min1_c])
					{
						min2_c = min1_c;
						min1_c = col;
					}
					else if (min2_c == -1 || memo[row, col] <= memo[row, min2_c])
						min2_c = col;
				}

				next_min1_c = min1_c;
				next_min2_c = min2_c;
			}

			return memo[0, next_min1_c];
		}
	}
}
