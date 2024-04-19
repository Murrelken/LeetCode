using System.Collections.Generic;

namespace LeetCode.Problems._2
{
	internal class Problem200
	{
		public int NumIslands(char[][] grid)
		{
			if (grid == null || grid.Length == 0)
				return 0;

			var count = 0;
			var rows = grid.Length;
			var cols = grid[0].Length;

			for (var i = 0; i < rows; i++)
				for (var j = 0; j < cols; j++)
					if (grid[i][j] == '1')
					{
						BFS(grid, i, j);
						count++;
					}

			return count;
		}

		private void BFS(char[][] grid, int row, int col)
		{
			var rows = grid.Length;
			var cols = grid[0].Length;

			var queue = new Queue<(int, int)>();
			queue.Enqueue((row, col));

			while (queue.Count > 0)
			{
				(var r, var c) = queue.Dequeue();

				if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == '0')
					continue;

				grid[r][c] = '0';

				queue.Enqueue((r + 1, c));
				queue.Enqueue((r - 1, c));
				queue.Enqueue((r, c + 1));
				queue.Enqueue((r, c - 1));
			}
		}
	}
}
