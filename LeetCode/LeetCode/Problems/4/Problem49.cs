using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._4
{
	internal class Problem49
	{
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			var dic = new Dictionary<string, IList<string>>();

			foreach (var str in strs)
			{
				var chars = str.ToCharArray();
				Array.Sort(chars);
				var nstr = new string(chars);
				if (!dic.TryAdd(nstr, new List<string> { str }))
					dic[nstr].Add(str);
			}

			var result = dic.Values.ToList();
			return result;
		}
	}
}
