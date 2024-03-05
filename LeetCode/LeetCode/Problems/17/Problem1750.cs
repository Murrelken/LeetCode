namespace LeetCode.Problems._17
{
	internal class Problem1750
	{
		public int MinimumLength(string s)
		{
			var n = s.Length;
			var l = 0;
			var r = n - 1;

			while (l < r && s[l] == s[r])
			{
				var current = s[l];

				while (l <= r && s[l] == current)
					l++;
				while (l <= r && s[r] == current)
					r--;
			}
			return r - l + 1;
		}
	}
}
