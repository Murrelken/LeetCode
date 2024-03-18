using System;
using System.Collections.Generic;

namespace LeetCode.Problems._16
{
	internal class Problem1624
	{
		public int MaxLengthBetweenEqualCharacters(string s)
		{
			var result = -1;
			var chars = new HashSet<char>(s.ToCharArray());
			foreach (var c in chars)
			{
				var first = s.IndexOf(c);
				var last = s.LastIndexOf(c);
				if (first != last)
					result = Math.Max(result, last - first - 1);
			}
			return result;
		}
	}
}
