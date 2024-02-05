using System.Collections.Generic;

namespace LeetCode.Problems._3
{
	internal class Problem387
	{
		public int FirstUniqChar(string s)
		{
			var map = new Dictionary<char, int>();
            foreach (var item in s)
                if (!map.TryAdd(item, 1))
					map[item]++;

			for (var i = 0; i < s.Length; i++)
				if (map[s[i]] == 1)
					return i;

			return -1;
		}
	}
}
