namespace LeetCode.Problems._3
{
	internal class Problem392
	{
		public bool IsSubsequence(string s, string t)
		{
			if (s.Length == 0) return true;
			var lookupI = 0;
			for (var i = 0; i < t.Length; i++) 
			{
				if (t[i] == s[lookupI])
				{
					lookupI++;
					if (lookupI == s.Length)
						return true;
				}
			}
			return false;
		}
	}
}
