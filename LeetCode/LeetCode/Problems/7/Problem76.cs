namespace LeetCode.Problems._7
{
	internal class Problem76
	{
		public string MinWindow(string s, string t)
		{
			if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
				return string.Empty;

			var map = new int[128];
			int start = 0, end = 0, minLen = int.MaxValue, startIndex = 0, count = t.Length;
			foreach (char c in t)
				map[c]++;

			char[] chS = s.ToCharArray();

			while (end < chS.Length)
			{
				if (map[chS[end++]]-- > 0)
					count--;

				while (count == 0)
				{
					if (end - start < minLen)
					{
						startIndex = start;
						minLen = end - start;
					}

					if (map[chS[start++]]++ == 0)
						count++;
				}
			}

			return minLen == int.MaxValue ? string.Empty : new string(chS, startIndex, minLen);
		}
	}
}
