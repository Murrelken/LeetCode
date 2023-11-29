using System;
using System.Collections.Generic;

namespace LeetCode.Problems._9
{
	internal class Problem935
	{
		private const int MOD = 1_000_000_007;

		public int KnightDialer(int n)
		{
			var availableMoves = new[] { new[] { 4, 6 }, new [] { 6, 8 }, new[] { 7, 9 }, new[] { 4, 8 }, new[] { 3, 9, 0 } , Array.Empty<int>(),
				new[] { 1, 7, 0 }, new[] { 2, 6 }, new[] { 1, 3 }, new[] { 2, 4 } };
			var memo = new Dictionary<int, Dictionary<int, int>>();
			var res = 0;
			for (int i = 0; i < availableMoves.Length; i++)
			{
				res += CountByCurrentNumberAndStep(n - 1, i, memo, availableMoves) % MOD;
				res %= MOD;
			}
			
			return res;
		}

		private int CountByCurrentNumberAndStep(int n, int num, Dictionary<int, Dictionary<int, int>> memo, int[][] availableMoves)
		{
			if (memo.ContainsKey(num) && memo[num].ContainsKey(n)) return memo[num][n];
			if (n == 0) return 1;

			var res = 0;
            foreach (var availableMove in availableMoves[num])
			{
				res += CountByCurrentNumberAndStep(n - 1, availableMove, memo, availableMoves) % MOD;
				res %= MOD;
			}

			memo.TryAdd(num, new Dictionary<int, int>());
			memo[num].Add(n, res);
			return res;
		}
	}
}
