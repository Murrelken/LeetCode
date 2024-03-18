using System;
using System.Linq;

namespace LeetCode.Problems._16
{
	internal class Problem1657
	{
		public bool CloseStrings(string word1, string word2)
		{
			if (word1.Length != word2.Length) return false;

			var count1 = new int[26];
			var count2 = new int[26];

			foreach (char sChar in word1)
				count1[sChar - 'a']++;
			foreach (char tChar in word2)
				count2[tChar - 'a']++;

			for (int i = 0; i < 26; i++)
				if (count1[i] == 0 && count2[i] != 0 || count1[i] != 0 && count2[i] == 0)
					return false;

			Array.Sort(count1);
			Array.Sort(count2);

			return count1.SequenceEqual(count2);
		}
	}
}
