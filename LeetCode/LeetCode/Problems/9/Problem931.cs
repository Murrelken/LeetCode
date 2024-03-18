using System;
using System.Linq;

namespace LeetCode.Problems._9
{
	internal class Problem931
	{
		public int MinFallingPathSum(int[][] matrix)
		{
			var n = matrix.Length;
			var m = matrix[0].Length;
			var res = new int[matrix.Length][];
			res[0] = matrix[0];
			for (var i = 1; i < n; i++)
			{
				res[i] = new int[m];
				for (var j = 0; j < m; j++)
				{
					var min = res[i - 1][j];
					if (j > 0)
						min = Math.Min(min, res[i - 1][j - 1]);
					if (j < m - 1)
						min = Math.Min(min, res[i - 1][j + 1]);
					res[i][j] = min + matrix[i][j];
				}
			}
			return res.Last().Min();
		}
	}
}
