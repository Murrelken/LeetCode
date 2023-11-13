using System.Collections.Generic;

namespace LeetCode.Problems._27
{
	public class Problem2785
	{
		public string SortVowels(string s)
		{
			var res = new char[s.Length];
			const string totalVowels = "aeiouAEIOU";
			var vowels = new List<char>();
			foreach (var c in s)
			{
				if (totalVowels.Contains(c))
				{
					vowels.Add(c);
				}
			}

			var vowelsI = 0;
			vowels.Sort();
			for (var i = 0; i < s.Length; i++)
			{
				res[i] = totalVowels.Contains(s[i]) ? vowels[vowelsI++] : s[i];
			}

			return res.ToString();
		}
	}
}
