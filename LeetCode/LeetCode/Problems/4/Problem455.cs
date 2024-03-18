using System;

namespace LeetCode.Problems._4
{
	internal class Problem455
	{
		public int FindContentChildren(int[] g, int[] s)
		{
			Array.Sort(g);
			Array.Sort(s);

			var gi = 0;
			var si = 0;

			while (gi < g.Length && si < s.Length)
			{
				if (g[gi] <= s[si])
				{
					gi++;
					si++;
				}
				else
					si++;
			}

			return gi;
		}
	}
}
