using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._12
{
	internal class Problem1207
	{
		public bool UniqueOccurrences(int[] arr)
		{
			var dic = new Dictionary<int, int>();
			foreach (int i in arr)
			{
				if (dic.ContainsKey(i))
					dic[i]++;
				else
					dic.Add(i, 1);
			}
			var set = new HashSet<int>();
			return dic.Values.Distinct().Count() == dic.Count;
		}
	}
}
