﻿using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._2
{
	internal class Problem242
	{
		public bool IsAnagram(string s, string t)
		{
			var dic = new Dictionary<char, int>();
			foreach (var c in s)
				if (!dic.TryAdd(c, 1))
					dic[c]++;

			foreach (var c in t)
			{
				if (!dic.ContainsKey(c) || dic[c] == 0)
					return false;

				dic[c]--;
			}

			return dic.All(x => x.Value == 0);
		}
	}
}
