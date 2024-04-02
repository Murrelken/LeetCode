using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._2
{
	internal class Problem205
	{
		public bool IsIsomorphic(string s, string t)
		{
			var sIndexesSum = new Dictionary<char, string>();
			var tIndexesSum = new Dictionary<char, string>();

			for (var i = 0; i < s.Length; i++)
			{
				if (!sIndexesSum.TryAdd(s[i], i.ToString()))
					sIndexesSum[s[i]] += i.ToString();
				if (!tIndexesSum.TryAdd(t[i], i.ToString()))
					tIndexesSum[t[i]] += i.ToString();
			}

			var orderedS = sIndexesSum.Values.Order();
			var orderedT = tIndexesSum.Values.Order();

			return orderedS.SequenceEqual(orderedT);
		}
	}
}
