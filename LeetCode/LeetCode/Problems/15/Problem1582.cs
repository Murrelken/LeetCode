using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._15
{
	internal class Problem1582
	{
		public int NumSpecial(int[][] mat)
		{
			var m = mat.Length;
			var n = mat[0].Length;
			var columnsWhereOnesExist = new HashSet<int>();
			var columnsWhereOnesExistMoreThanOnce = new HashSet<int>();
			var positionOfOneInRowsToCheck = new List<int>();

			for (var i = 0; i < m; i++)
			{
				var tempJ = -1;
				var found = 0;
				for (var j = 0; j < n; j++)
				{
					if (mat[i][j] == 1)
					{
						tempJ = j;
						found++;
						if (columnsWhereOnesExist.Contains(j))
							columnsWhereOnesExistMoreThanOnce.Add(j);
						else
							columnsWhereOnesExist.Add(j);
					}
				}
				if (found == 1)
					positionOfOneInRowsToCheck.Add(tempJ);
			}

			return positionOfOneInRowsToCheck.Count(x => !columnsWhereOnesExistMoreThanOnce.Contains(x));
		}
	}
}
