using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._3
{
	internal class Problem3005
	{
		public int MaxFrequencyElements(int[] nums)
		{
			var dic = new Dictionary<int, int>();
			foreach (var n in nums)
				if (!dic.TryAdd(n, 1))
					dic[n]++;
			var res = 0;
			var counts = dic.Values.OrderByDescending(x => x);
			var max = counts.First();
			foreach (var c in counts)
				if (c == max)
					res += c;
				else
					break;
			return res;
		}
	}
}
