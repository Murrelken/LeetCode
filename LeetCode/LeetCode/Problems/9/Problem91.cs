namespace LeetCode.Problems._9
{
	internal class Problem91
	{
		public int NumDecodings(string s)
		{
			if (string.IsNullOrEmpty(s) || s[0] == '0')
			{
				return 0;
			}

			var n = s.Length;
			var dp = new int[n + 1];
			dp[0] = 1;
			dp[1] = 1;

			for (int i = 2; i <= n; ++i)
			{
				var oneDigit = s[i - 1] - '0';
				var twoDigits = int.Parse(s.Substring(i - 2, 2));

				if (oneDigit != 0)
					dp[i] += dp[i - 1];

				if (10 <= twoDigits && twoDigits <= 26)
					dp[i] += dp[i - 2];
			}

			return dp[n];
		}
	}
}
