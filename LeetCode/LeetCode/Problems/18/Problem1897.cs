using System.Collections.Generic;

namespace LeetCode.Problems._18
{
	internal class Problem1897
	{
		public bool MakeEqual(string[] words)
		{
			var n = words.Length;
			var dic = new Dictionary<char, int>();
			foreach (var word in words)
				foreach (var c in word)
					if (!dic.TryAdd(c, 1))
						dic[c]++;
			foreach (var count in dic.Values)
				if (count % n != 0)
					return false;
			return true;
		}
	}
}
