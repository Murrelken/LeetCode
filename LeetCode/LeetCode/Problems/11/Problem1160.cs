using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._11
{
	internal class Problem1160
	{
		public int CountCharacters(string[] words, string chars)
		{
			var map = new Dictionary<char, int>();
			foreach (var c in chars)
				if (!map.TryAdd(c, 1))
					map[c]++;
			var result = 0;
			foreach (var word in words)
			{
				var tempMap = map.ToDictionary(x => x.Key, x => x.Value);
				var wordIsOkaySoFar = true;
				foreach (var c in word)
				{
					if (!tempMap.ContainsKey(c) || tempMap[c] == 0)
					{
						wordIsOkaySoFar = false;
						break;
					}
					tempMap[c]--;
				}

				if (wordIsOkaySoFar)
					result += word.Length;
			}

			return result;
		}
	}
}
