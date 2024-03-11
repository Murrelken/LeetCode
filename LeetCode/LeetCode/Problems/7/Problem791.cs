using System.Text;

namespace LeetCode.Problems._7
{
	internal class Problem791
	{
		public string CustomSortString(string order, string s)
		{
			var map = new int[26];
			foreach (var c in s)
				map[c - 'a']++;

			var result = new StringBuilder();

			foreach (var c in order)
			{
				result.Append(new string(c, map[c - 'a']));
				map[c - 'a'] = 0;
			}

			for (int i = 0; i < 26; i++)
				result.Append(new string((char)('a' + i), map[i]));

			return result.ToString();
		}
	}
}
