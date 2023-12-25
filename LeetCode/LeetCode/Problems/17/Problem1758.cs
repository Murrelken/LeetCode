using System;

namespace LeetCode.Problems._17
{
	internal class Problem1758
	{
		public int MinOperations(string s)
		{
			var n = s.Length;
			var operationsCount = 0;

			for (int i = 0; i < n; i++)
				if (s[i] - '0' != i % 2)
					operationsCount++;

			return Math.Min(operationsCount, n - operationsCount);
		}
	}
}
