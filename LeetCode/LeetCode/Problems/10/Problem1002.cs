using System;
using System.Collections.Generic;

namespace LeetCode.Problems._10
{
	internal class Problem1002
	{
		public IList<string> CommonChars(string[] words)
		{
			var result = new List<string>();
			if (words == null || words.Length == 0)
				return result;

			var minFreq = new int[26];
			Array.Fill(minFreq, int.MaxValue);

			foreach (var word in words)
			{
				var charCount = new int[26];
				foreach (var c in word)
					charCount[c - 'a']++;
				for (var i = 0; i < 26; i++)
					minFreq[i] = Math.Min(minFreq[i], charCount[i]);
			}

			for (int i = 0; i < 26; i++)
				for (int j = 0; j < minFreq[i]; j++)
					result.Add(((char)(i + 'a')).ToString());

			return result;
		}
	}
}
