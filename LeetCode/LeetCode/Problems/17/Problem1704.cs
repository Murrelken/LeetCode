using System.Collections.Generic;

namespace LeetCode.Problems._17
{
	internal class Problem1704
	{
		public bool HalvesAreAlike(string s)
		{
			var mid = s.Length / 2;
			return CountVowels(s[..mid]) == CountVowels(s[mid..]);
		}

		private int CountVowels(string str)
		{
			var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
			var count = 0;
			foreach (char c in str)
				if (vowels.Contains(c))
					count++;
			return count;
		}
	}
}
