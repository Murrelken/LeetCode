namespace LeetCode.Problems._16
{
	internal class Problem1688
	{
		public int NumberOfMatches(int n)
		{
			var res = 0;
			while (n > 1)
			{
				res += n / 2;
				n = n / 2 + n % 2;
			}
			return res;
		}
	}
}
