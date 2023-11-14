using System.Collections.Generic;

namespace LeetCode.Problems._19
{
	internal class Problem1930
	{
		public int CountPalindromicSubsequence(string s)
		{
			var uniqueElementsWindow = new HashSet<char>();
			var res = 0;
			for (char ch = 'a'; ch <= 'z'; ch++)
			{
				var first = s.IndexOf(ch);
				if (first == -1)
					continue;
				var last = s.LastIndexOf(ch);
				if (last - first < 2)
					continue;

				uniqueElementsWindow.Clear();

				for (var j = first + 1; j < last; j++)
					uniqueElementsWindow.Add(s[j]);

				res += uniqueElementsWindow.Count;
			}

			return res;
		}
	}
}
