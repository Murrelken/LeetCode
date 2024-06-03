namespace LeetCode.Problems._24
{
	internal class Problem2486
	{
		public int AppendCharacters(string s, string t)
		{
			var ti = 0;
			var si = 0;

			while (si < s.Length && ti < t.Length)
			{
				if (s[si] == t[ti])
					ti++;
				si++;
			}

			return t.Length - ti;
		}
	}
}
