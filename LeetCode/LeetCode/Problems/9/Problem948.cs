using System;

namespace LeetCode.Problems._9
{
	internal class Problem948
	{
		public int BagOfTokensScore(int[] t, int power)
		{
			Array.Sort(t);
			var n = t.Length;
			var l = 0;
			var r = n - 1;
			var res = 0;

			while (l < n)
			{
				if (t[l] <= power)
				{
					res++;
					power -= t[l];
					l++;
				}
				else if (l < r && t[l] <= power + t[r] && res > 0)
				{
					res--;
					power += t[r];
					r--;
				}
				else break;
			}

			return res;
		}
	}
}
