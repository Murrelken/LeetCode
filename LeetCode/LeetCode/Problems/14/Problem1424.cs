using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._14
{
	internal class Problem1424
	{
		public int[] FindDiagonalOrder(IList<IList<int>> nums)
		{
			var ordered = new List<LinkedList<int>>();
			
			for (int i = 0; i < nums.Count; i++)
			{
				for (int j = 0; j < nums[i].Count; j++)
				{
					var n = i + j;
					if (ordered.Count <= n)
						ordered.Add(new LinkedList<int>());

					ordered[n].AddFirst(nums[i][j]);
				}
			}

			var res = ordered.SelectMany(x => x).ToArray();

			return res;
		}
	}
}
