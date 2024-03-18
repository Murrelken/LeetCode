using System.Collections.Generic;

namespace LeetCode.Problems._1
{
	internal class Problem125
	{
		public bool IsPalindrome(string s)
		{
			s = s.ToLower();
			var trimmed = new List<char>();
			for (var ii  = 0; ii < s.Length; ii++)
				if (char.IsLetterOrDigit(s[ii]))
					trimmed.Add(s[ii]);
			var n = trimmed.Count;
			var i = 0;
			while (i < n - 1 - i)
			{
				if (trimmed[i] != trimmed[n - 1 - i])
					return false;
				i++;
			}
			return true;
		}
	}
}
