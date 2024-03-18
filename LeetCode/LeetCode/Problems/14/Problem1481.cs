using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._14
{
	internal class Problem1481
	{
		public int FindLeastNumOfUniqueInts(int[] arr, int k)
		{
			var counts = new Dictionary<int, int>();
            foreach (var item in arr)
                if (!counts.TryAdd(item, 1))
					counts[item]++;

			var removed = 0;
            foreach (var item in counts.Select(x => x.Value).OrderBy(x => x))
            {
				k -= item;
				if (k >= 0)
					removed++;
				else
					break;
            };

			return counts.Count - removed;
        }
	}
}
