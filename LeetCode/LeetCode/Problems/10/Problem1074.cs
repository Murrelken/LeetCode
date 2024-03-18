using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems._10
{
	internal class Problem1074
	{
		public int NumSubmatrixSumTarget(int[][] matrix, int target)
		{
			int m = matrix.Length, n = matrix[0].Length, res = 0;

			for (var l = 0; l < n; l++)
			{
				var sums = new int[105];
				for (var r = l; r < n; r++)
				{
					for (var i = 0; i < m; i++)
					{
						sums[i] += matrix[i][r];
					}
					for (var i = 0; i < m; i++)
					{
						var sum = 0;
						for (var j = i; j < m; j++)
						{
							sum += sums[j];
							if (sum == target)
								res++;
						}
					}
				}
			}

			return res;
		}
	}
}
