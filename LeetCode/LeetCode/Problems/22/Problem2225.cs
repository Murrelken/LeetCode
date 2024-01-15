using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._22
{
	internal class Problem2225
	{
		public IList<IList<int>> FindWinners(int[][] matches)
		{
			var winners = new HashSet<int>();
			var losers = new HashSet<int>();
			var totalLosers = new HashSet<int>();
			foreach (var match in matches)
			{
				var w = match[0];
				var l = match[1];

				if (!totalLosers.Contains(w) && !losers.Contains(w))
					winners.Add(w);
				if (!totalLosers.Contains(l))
					if (losers.Contains(l))
					{
						losers.Remove(l);
						totalLosers.Add(l);
					}
					else if (winners.Contains(l))
					{
						winners.Remove(l);
						losers.Add(l);
					}
					else losers.Add(l);
			}

			var ww = winners.ToList();
			ww.Sort();
			var ll = losers.ToList(); ll.Sort();
			return new[] { ww, ll };
		}
	}
}
