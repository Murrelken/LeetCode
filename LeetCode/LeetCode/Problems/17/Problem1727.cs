using System;

namespace LeetCode.Problems._17
{
	internal class Problem1727
	{
		public int LargestSubmatrix(int[][] matrix)
		{
			var m = matrix.Length;
			var n = matrix[0].Length;
			var res = 0;

			for (var i = 0; i < m; i++)
			{
				if (i > 0)
					for (var j = 0; j < n; j++)
						if (matrix[i][j] != 0)
							matrix[i][j] += matrix[i - 1][j];

				var sortedRow = new int[n];
				matrix[i].CopyTo(sortedRow, 0);
				Array.Sort(sortedRow);
				for (var ii = 0; ii < n; ii++)
					res = Math.Max(res, sortedRow[ii] * (n - ii));
			}

			return res;
		}
	}
}
