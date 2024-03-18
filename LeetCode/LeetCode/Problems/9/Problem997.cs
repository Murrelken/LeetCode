namespace LeetCode.Problems._9
{
	internal class Problem997
	{
		public int FindJudge(int n, int[][] trust)
		{
			var countTrust = new int[n + 1];

			foreach (var judge in trust)
			{
				countTrust[judge[0]]--;
				countTrust[judge[1]]++;
			}

			for (int i = 1; i <= n; i++)
				if (countTrust[i] == n - 1)
					return i;

			return -1;
		}
	}
}
