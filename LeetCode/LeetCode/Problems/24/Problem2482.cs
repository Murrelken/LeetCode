namespace LeetCode.Problems._24
{
	internal class Problem2482
	{
		public int[][] OnesMinusZeros(int[][] grid)
		{
			var m = grid.Length;
			var n = grid[0].Length;
			var rowOnes = new int[m];
			var rowZeroes = new int[m];
			var columnOnes = new int[n];
			var columnZeroes = new int[n];

			for (var i = 0; i < m; i++)
				for (var j = 0; j < n; j++)
					if (grid[i][j] == 0)
					{
						rowZeroes[i]++;
						columnZeroes[j]++;
					}
					else
					{
						rowOnes[i]++;
						columnOnes[j]++;
					}

			for (var i = 0; i < m; i++)
				for (var j = 0; j < n; j++)
					grid[i][j] = rowOnes[i] + columnOnes[j] - rowZeroes[i] - columnZeroes[j];

			return grid;
		}
	}
}
