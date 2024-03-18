using System;

namespace LeetCode.Problems._13
{
	internal class Problem1347
	{
		public int MinSteps(string s, string t)
		{
			var sHash = new int[26];
			var tHash = new int[26];

			foreach (char sChar in s)
				sHash[sChar - 'a']++;
			foreach (char tChar in t)
				tHash[tChar - 'a']++;

			var count = 0;

			for (int i = 0; i < 26; i++)
				count += Math.Abs(sHash[i] - tHash[i]);

			return count / 2;
		}
	}
}
