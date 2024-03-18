using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._12
{
	internal class Problem1239
	{
		public int MaxLength(IList<string> arr)
		{
			var combinations = Enumerable.Range(0, 1 << (arr.Count)).Select(index => arr.Where((v, i) => (index & (1 << i)) != 0).ToArray());

			int ret = 0;
			foreach (var c in combinations)
			{
				string temp = string.Join("", c);
				if (Unique(temp) && temp.Length > ret)
					ret = temp.Length;
			}

			return ret;
		}

		public bool Unique(String temp)
		{
			string str = "";
			for (int i = 0; i < temp.Length; i++)
			{
				if (str.Contains(temp[i]))
					return false;

				str += temp[i].ToString();
			}

			return true;
		}
	}
}
