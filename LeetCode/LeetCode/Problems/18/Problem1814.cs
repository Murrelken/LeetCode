using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._18
{
	internal class Problem1814
	{
		public int CountNicePairs(int[] nums)
		{
			var revs = nums
				.Select(x => x - Rev(x))
				.ToArray();

			var res = 0;
			const int MOD = 1_000_000_007;
			var dictionary = new Dictionary<int, int>();
            foreach (var item in revs)
            {
				dictionary.TryAdd(item, 0);
				var existing = dictionary[item];
				res = (res + existing) % MOD;
				dictionary[item]++;
			}

			return res;
		}

		public int Rev(int num)
		{
			var result = 0;

			while (num > 0)
			{
				result = result * 10 + num % 10;
				num /= 10;
			}

			return result;
		}
	}
}
