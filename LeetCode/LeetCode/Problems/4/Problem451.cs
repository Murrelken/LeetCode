using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems._4
{
	internal class Problem451
	{
		public string FrequencySort(string s)
		{
			var dic = new Dictionary<char, int>();
            foreach (var item in s)
				if (!dic.TryAdd(item, 1))
					dic[item]++;

			var sb = new StringBuilder();
            foreach (var (k, v) in dic.OrderByDescending(x => x.Value))
                sb.Append(k, v);

            return sb.ToString();
		}
	}
}
