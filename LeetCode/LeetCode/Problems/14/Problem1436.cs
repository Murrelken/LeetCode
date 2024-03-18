using System.Collections.Generic;

namespace LeetCode.Problems._14
{
	internal class Problem1436
	{
		public string DestCity(IList<IList<string>> paths)
		{
			var sourceCities = new HashSet<string>();

			foreach (var path in paths)
				sourceCities.Add(path[0]);

			foreach (var path in paths)
				if (!sourceCities.Contains(path[1]))
					return path[1];

			return string.Empty;
		}
	}
}
